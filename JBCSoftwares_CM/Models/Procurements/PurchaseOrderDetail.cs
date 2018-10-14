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
    public class PurchaseOrderDetail
    {
        public string DetailId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string StockId { get; set; }
        public string LocationId { get; set; }
        public decimal POQty { get; set; }
        public decimal QtyIn { get; set; }
        public decimal QtyVariance { get; set; }
        public decimal UnitPrice { get; set; }
        public string DiscountId { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getPurchaseOrderDetails(string pDisplayType, string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseOrderDetails('" + pDisplayType + "'," + pId + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getPurchaseOrderDetail(string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseOrderDetail(" + pId + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getPurchaseInventory(DateTime pStartDate, DateTime pEndDate)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseInventory('" + String.Format("{0:yyyy-MM-dd}", pStartDate) + "','" + String.Format("{0:yyyy-MM-dd}", pEndDate) + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getPurchaseInventoryBy(DateTime pStartDate, DateTime pEndDate)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseInventoryBy('" + String.Format("{0:yyyy-MM-dd}", pStartDate) + "','" + String.Format("{0:yyyy-MM-dd}", pEndDate) + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getStockPurchaseOrder(string pLocationId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetStockPurchaseOrder('" + pLocationId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getStockPurchaseOrderList(string pLocationId, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetStockPurchaseOrderList('" + pLocationId + "','" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertPurchaseOrderDetail(PurchaseOrderDetail pPurchaseOrderDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertPurchaseOrderDetail('" + pPurchaseOrderDetail.PurchaseOrderId +
                    "','" + pPurchaseOrderDetail.StockId +
                    "','" + pPurchaseOrderDetail.LocationId +
                    "','" + pPurchaseOrderDetail.POQty +
                    "','" + pPurchaseOrderDetail.QtyIn +
                    "','" + pPurchaseOrderDetail.QtyVariance +
                    "','" + pPurchaseOrderDetail.UnitPrice +
                    "','" + pPurchaseOrderDetail.DiscountId +
                    "','" + pPurchaseOrderDetail.DiscountAmount +
                    "','" + pPurchaseOrderDetail.TotalPrice +
                    "','" + pPurchaseOrderDetail.Remarks +
                    "','" + pPurchaseOrderDetail.UserId + "');", _conn);
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

        public bool updatePurchaseOrderDetail(PurchaseOrderDetail pPurchaseOrderDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdatePurchaseOrderDetail('" + pPurchaseOrderDetail.DetailId +
                    "','" + pPurchaseOrderDetail.PurchaseOrderId +
                    "','" + pPurchaseOrderDetail.StockId +
                    "','" + pPurchaseOrderDetail.LocationId +
                    "','" + pPurchaseOrderDetail.POQty +
                    "','" + pPurchaseOrderDetail.QtyIn +
                    "','" + pPurchaseOrderDetail.QtyVariance +
                    "','" + pPurchaseOrderDetail.UnitPrice +
                    "','" + pPurchaseOrderDetail.DiscountId +
                    "','" + pPurchaseOrderDetail.DiscountAmount +
                    "','" + pPurchaseOrderDetail.TotalPrice +
                    "','" + pPurchaseOrderDetail.Remarks +
                    "','" + pPurchaseOrderDetail.UserId + "');", _conn);
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

        public bool removePurchaseOrderDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemovePurchaseOrderDetail('" + pDetailId +
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

        public bool updateQtyInPurchaseOrderDetail(string pDetailId, decimal pQtyIn, decimal pVariance)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateQtyInPurchaseOrderDetail('" + pDetailId +
                    "'," + pQtyIn + "," + pVariance + ");", _conn);
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

        public bool updateTotalPricePurchaseOrderDetail(string pDetailId, decimal pTotalPrice)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateTotalPricePurchaseOrderDetail('" + pDetailId +
                    "'," + pTotalPrice + ");", _conn);
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