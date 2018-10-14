using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using System.DirectoryServices.AccountManagement;
using MySql.Data.MySqlClient;

namespace JCSoftwares_CM.Models.Sales
{
    public class SalesOrderDetail
    {
        public string DetailId { get; set; }
        public string SalesOrderId { get; set; }
        public string StockId { get; set; }
        public string LocationId { get; set; }
        public decimal SOQty { get; set; }
        public decimal QtyOut { get; set; }
        public decimal QtyVariance { get; set; }
        public decimal UnitPrice { get; set; }
        public string DiscountId { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getSalesOrderDetails(string pDisplayType, string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetSalesOrderDetails('" + pDisplayType + "'," + pId + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getSalesOrderDetail(string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetSalesOrderDetail(" + pId + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getStockSalesOrder(string pLocationId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetStockSalesOrder('" + pLocationId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getStockSalesOrderList(string pLocationId, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetStockSalesOrderList('" + pLocationId + "','" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertSalesOrderDetail(SalesOrderDetail pSalesOrderDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertSalesOrderDetail(" + pSalesOrderDetail.SalesOrderId +
                    ", " + pSalesOrderDetail.StockId +
                    ", " + pSalesOrderDetail.LocationId +
                    ", " + pSalesOrderDetail.SOQty +
                    ", " + pSalesOrderDetail.QtyOut +
                    ", " + pSalesOrderDetail.QtyVariance +
                    ", " + pSalesOrderDetail.UnitPrice +
                    ", '" + pSalesOrderDetail.DiscountId +
                    "', " + pSalesOrderDetail.DiscountAmount +
                    ", " + pSalesOrderDetail.TotalPrice +
                    ", '" + pSalesOrderDetail.Remarks +
                    "', '" + pSalesOrderDetail.UserId + "');", _conn);
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

        public bool updateSalesOrderDetail(SalesOrderDetail pSalesOrderDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateSalesOrderDetail(" + pSalesOrderDetail.DetailId +
                    ", " + pSalesOrderDetail.SalesOrderId +
                    ", " + pSalesOrderDetail.StockId +
                    ", " + pSalesOrderDetail.LocationId +
                    ", " + pSalesOrderDetail.SOQty +
                    ", " + pSalesOrderDetail.QtyOut +
                    ", " + pSalesOrderDetail.QtyVariance +
                    ", " + pSalesOrderDetail.UnitPrice +
                    ", '" + pSalesOrderDetail.DiscountId +
                    "', " + pSalesOrderDetail.DiscountAmount +
                    ", " + pSalesOrderDetail.TotalPrice +
                    ", '" + pSalesOrderDetail.Remarks +
                    "', '" + pSalesOrderDetail.UserId + "');", _conn);
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

        public bool removeSalesOrderDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveSalesOrderDetail('" + pDetailId +
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

        public bool updateQtyOutSalesOrderDetail(string pDetailId, decimal pQtyOut, decimal pVariance)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateQtyOutSalesOrderDetail('" + pDetailId +
                    "'," + pQtyOut + "," + pVariance + ");", _conn);
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

        public bool updateTotalPriceSalesOrderDetail(string pDetailId, decimal pTotalPrice)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateTotalPriceSalesOrderDetail('" + pDetailId +
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