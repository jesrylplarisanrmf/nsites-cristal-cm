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
    public class PurchaseRequest
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Approve { get; set; }
        public string Cancel { get; set; }
        public string POId { get; set; }
        public string Reference { get; set; }
        public string SupplierId { get; set; }
        public int Terms { get; set; }
        public string Instructions { get; set; }
        public string RequestedBy { get; set; }
        public DateTime DateNeeded { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public string PreparedBy { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime DateApproved { get; set; }
        public string CancelledBy { get; set; }
        public string CancelledReason { get; set; }
        public DateTime DateCancelled { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getPurchaseRequests(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseRequests('" + pDisplayType + "'," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ",'" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getPurchaseRequestBySupplier(string pSupplierId,string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseRequestBySupplier('" + pSupplierId + "','" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getPurchaseRequestStatus(string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseRequestStatus('" + pId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getNextPurchaseRequestId()
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetNextPurchaseRequestId()", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertPurchaseRequest(PurchaseRequest pPurchaseRequest)
        {
            string _result = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertPurchaseRequest('" + String.Format("{0:yyyy-MM-dd}", pPurchaseRequest.Date) +
                    "','" + pPurchaseRequest.Reference +
                    "','" + pPurchaseRequest.SupplierId +
                    "','" + pPurchaseRequest.Terms +
                    "','" + pPurchaseRequest.Instructions +
                    "','" + pPurchaseRequest.RequestedBy +
                    "','" + String.Format("{0:yyyy-MM-dd}", pPurchaseRequest.DateNeeded) +
                    "','" + pPurchaseRequest.TotalQty +    
                    "','" + pPurchaseRequest.TotalAmount +
                    "','" + pPurchaseRequest.UserId +
                    "','" + pPurchaseRequest.Remarks +
                    "','" + pPurchaseRequest.UserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    _result = _cmd.ExecuteScalar().ToString();
                    _trans.Commit();
                    _conn.Close();
                }
                catch
                {
                    _trans.Rollback();
                    _result = "";
                }
            }
            return _result;
        }

        public string updatePurchaseRequest(PurchaseRequest pPurchaseRequest)
        {
            string _result = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdatePurchaseRequest('" + pPurchaseRequest.Id +
                    "','" + String.Format("{0:yyyy-MM-dd}", pPurchaseRequest.Date) +
                    "','" + pPurchaseRequest.Reference +
                    "','" + pPurchaseRequest.SupplierId +
                    "','" + pPurchaseRequest.Terms +
                    "','" + pPurchaseRequest.Instructions +
                    "','" + pPurchaseRequest.RequestedBy +
                    "','" + String.Format("{0:yyyy-MM-dd}", pPurchaseRequest.DateNeeded) +
                    "','" + pPurchaseRequest.TotalQty +
                    "','" + pPurchaseRequest.TotalAmount +
                    "','" + pPurchaseRequest.UserId +
                    "','" + pPurchaseRequest.Remarks +
                    "','" + pPurchaseRequest.UserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    _result = _cmd.ExecuteScalar().ToString();
                    _trans.Commit();
                    _conn.Close();
                }
                catch
                {
                    _trans.Rollback();
                    _result = "";
                }
            }
            return _result;
        }

        public bool removePurchaseRequest(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemovePurchaseRequest('" + pId +
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

        public bool approvePurchaseRequest(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spApprovePurchaseRequest('" + pId +
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

        public bool cancelPurchaseRequest(string pId, string pCancelledReason, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spCancelPurchaseRequest('" + pId +
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
    }
}