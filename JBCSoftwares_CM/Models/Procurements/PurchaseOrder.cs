using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using System.DirectoryServices.AccountManagement;
using MySql.Data.MySqlClient;

namespace JCSoftwares_CM.Models.Procurements
{
    public class PurchaseOrder
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Final { get; set; }
        public string Cancel { get; set; }
        public string Post { get; set; }
        public string PRId { get; set; }
        public string SRId { get; set; }
        public string Reference { get; set; }
        public string SupplierId { get; set; }
        public int Terms { get; set; }
        public DateTime DueDate { get; set; }
        public string Instructions { get; set; }
        public string RequestedBy { get; set; }
        public DateTime DateNeeded { get; set; }
        public decimal TotalPOQty { get; set; }
        public decimal TotalQtyIn { get; set; }
        public decimal TotalQtyVariance { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RunningBalance { get; set; }
        public string PreparedBy { get; set; }
        public string FinalizedBy { get; set; }
        public DateTime DateFinalized { get; set; }
        public string CancelledBy { get; set; }
        public string CancelledReason { get; set; }
        public DateTime DateCancelled { get; set; }
        public string PostedBy { get; set; }
        public DateTime DatePosted { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getPurchaseOrders(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseOrders('" + pDisplayType + "'," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ",'" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getPurchaseOrderBySupplier(string pSupplierId,string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseOrderBySupplier ('" + pSupplierId + "','" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getCashDisbursementPOBySupplier(string pSupplierId, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetCashDisbursementPOBySupplier('" + pSupplierId + "','" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getAccountPayables()
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetAccountPayables();", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getAccountPayablesOverdue()
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetAccountPayablesOverdue();", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getPurchaseOrderStatus(string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseOrderStatus('" + pId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertPurchaseOrder(PurchaseOrder pPurchaseOrder)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertPurchaseOrder('" + String.Format("{0:yyyy-MM-dd}", pPurchaseOrder.Date) +
                    "','" + pPurchaseOrder.PRId +
                    "','" + pPurchaseOrder.Reference +
                    "','" + pPurchaseOrder.SupplierId +
                    "','" + pPurchaseOrder.Terms +
                    "','" + String.Format("{0:yyyy-MM-dd}", pPurchaseOrder.DueDate) +
                    "','" + pPurchaseOrder.Instructions +
                    "','" + pPurchaseOrder.RequestedBy +
                    "','" + String.Format("{0:yyyy-MM-dd}", pPurchaseOrder.DateNeeded) +
                    "','" + pPurchaseOrder.TotalPOQty +
                    "','" + pPurchaseOrder.TotalQtyIn +
                    "','" + pPurchaseOrder.TotalQtyVariance + 
                    "','" + pPurchaseOrder.TotalAmount +
                    "','" + pPurchaseOrder.UserId +
                    "','" + pPurchaseOrder.Remarks +
                    "','" + pPurchaseOrder.UserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    _Id = _cmd.ExecuteScalar().ToString();
                    _trans.Commit();
                    _conn.Close();
                }
                catch
                {
                    _trans.Rollback();
                    _Id = "";
                }
            }
            return _Id;
        }

        public string updatePurchaseOrder(PurchaseOrder pPurchaseOrder)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdatePurchaseOrder('" + pPurchaseOrder.Id +
                    "','" + String.Format("{0:yyyy-MM-dd}", pPurchaseOrder.Date) +
                    "','" + pPurchaseOrder.PRId +
                    "','" + pPurchaseOrder.Reference +
                    "','" + pPurchaseOrder.SupplierId +
                    "','" + pPurchaseOrder.Terms +
                    "','" + String.Format("{0:yyyy-MM-dd}", pPurchaseOrder.DueDate) +
                    "','" + pPurchaseOrder.Instructions +
                    "','" + pPurchaseOrder.RequestedBy +
                    "','" + String.Format("{0:yyyy-MM-dd}", pPurchaseOrder.DateNeeded) +
                    "','" + pPurchaseOrder.TotalPOQty +
                    "','" + pPurchaseOrder.TotalQtyIn +
                    "','" + pPurchaseOrder.TotalQtyVariance +
                    "','" + pPurchaseOrder.TotalAmount +
                    "','" + pPurchaseOrder.UserId +
                    "','" + pPurchaseOrder.Remarks +
                    "','" + pPurchaseOrder.UserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    _Id = _cmd.ExecuteScalar().ToString();
                    _trans.Commit();
                    _conn.Close();
                }
                catch
                {
                    _trans.Rollback();
                    _Id = "";
                }
            }
            return _Id;
        }

        public bool removePurchaseOrder(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemovePurchaseOrder('" + pId +
                    "','" + pUserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    int _rowsAffected = _cmd.ExecuteNonQuery();
                    _trans.Commit();
                    _conn.Close();
                    if (_rowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _trans.Rollback();
                    _success = false;
                }
            }
            return _success;
        }

        public bool finalizePurchaseOrder(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spFinalizePurchaseOrder('" + pId +
                    "','" + pUserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    int _rowsAffected = _cmd.ExecuteNonQuery();
                    _trans.Commit();
                    _conn.Close();
                    if (_rowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _trans.Rollback();
                    _success = false;
                }
            }
            return _success;
        }

        public bool cancelPurchaseOrder(string pId,string pCancelledReason, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spCancelPurchaseOrder('" + pId +
                    "','" + pCancelledReason +
                    "','" + pUserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    int _rowsAffected = _cmd.ExecuteNonQuery();
                    _trans.Commit();
                    _conn.Close();
                    if (_rowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _trans.Rollback();
                    _success = false;
                }
            }
            return _success;
        }

        public bool postPurchaseOrder(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spPostPurchaseOrder(" + pId +
                    ",'" + pUserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    int _rowsAffected = _cmd.ExecuteNonQuery();
                    _trans.Commit();
                    _conn.Close();
                    if (_rowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _trans.Rollback();
                    _success = false;
                }
            }
            return _success;
        }

        public bool updatePORunningBalance(string pId, decimal pRunningBalance, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdatePORunningBalance('" + pId +
                    "','" + pRunningBalance +
                    "','" + pUserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    int _rowsAffected = _cmd.ExecuteNonQuery();
                    _trans.Commit();
                    _conn.Close();
                    if (_rowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _trans.Rollback();
                    _success = false;
                }
            }
            return _success;
        }

        public bool updatePOTotalAmount(string pId, decimal pTotalQtyIn, decimal pTotalVariance, decimal pTotalAmount, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdatePOTotalAmount('" + pId +
                    "','" + pTotalQtyIn +
                    "','" + pTotalVariance +
                    "','" + pTotalAmount +
                    "','" + pUserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    int _rowsAffected = _cmd.ExecuteNonQuery();
                    _trans.Commit();
                    _conn.Close();
                    if (_rowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _trans.Rollback();
                    _success = false;
                }
            }
            return _success;
        }
    }
}