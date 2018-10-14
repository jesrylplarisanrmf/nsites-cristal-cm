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
    public class PurchaseRequestDetail
    {
        public string DetailId { get; set; }
        public string PurchaseRequestId { get; set; }
        public string StockId { get; set; }
        public string LocationId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getPurchaseRequestDetails(string pDisplayType, string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPurchaseRequestDetails('" + pDisplayType + "'," + pId + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getStockPurchaseRequest(string pLocationId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetStockPurchaseRequest('" + pLocationId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getStockPurchaseRequestList(string pLocationId, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetStockPurchaseRequestList('" + pLocationId + "','" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }
        
        public bool insertPurchaseRequestDetail(PurchaseRequestDetail pPurchaseRequestDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertPurchaseRequestDetail('" + pPurchaseRequestDetail.PurchaseRequestId +
                    "','" + pPurchaseRequestDetail.StockId +
                    "','" + pPurchaseRequestDetail.LocationId +
                    "','" + pPurchaseRequestDetail.Qty +
                    "','" + pPurchaseRequestDetail.UnitPrice +
                    "','" + pPurchaseRequestDetail.TotalPrice +
                    "','" + pPurchaseRequestDetail.Remarks +
                    "','" + pPurchaseRequestDetail.UserId + "');", _conn);
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
        
        public bool updatePurchaseRequestDetail(PurchaseRequestDetail pPurchaseRequestDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdatePurchaseRequestDetail('" + pPurchaseRequestDetail.DetailId +
                    "','" + pPurchaseRequestDetail.PurchaseRequestId +
                    "','" + pPurchaseRequestDetail.StockId +
                    "','" + pPurchaseRequestDetail.LocationId +
                    "','" + pPurchaseRequestDetail.Qty +
                    "','" + pPurchaseRequestDetail.UnitPrice +
                    "','" + pPurchaseRequestDetail.TotalPrice +
                    "','" + pPurchaseRequestDetail.Remarks +
                    "','" + pPurchaseRequestDetail.UserId + "');", _conn);
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

        public bool removePurchaseRequestDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemovePurchaseRequestDetail('" + pDetailId +
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