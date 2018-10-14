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
    public class PriceQuotationDetail
    {
        public string DetailId { get; set; }
        public string PriceQuotationId { get; set; }
        public string StockId { get; set; }
        public string LocationId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public string DiscountId { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getPriceQuotationDetails(string pDisplayType, string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetPriceQuotationDetails('" + pDisplayType + "'," + pId + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getStockPriceQuotation(string pLocationId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetStockPriceQuotation('" + pLocationId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getStockPriceQuotationList(string pLocationId, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetStockPriceQuotationList('" + pLocationId + "','" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertPriceQuotationDetail(PriceQuotationDetail pPriceQuotationDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertPriceQuotationDetail(" + pPriceQuotationDetail.PriceQuotationId +
                    ", " + pPriceQuotationDetail.StockId +
                    ", " + pPriceQuotationDetail.LocationId +
                    ", " + pPriceQuotationDetail.Qty +
                    ", " + pPriceQuotationDetail.UnitPrice +
                    ", '" + pPriceQuotationDetail.DiscountId +
                    "', " + pPriceQuotationDetail.DiscountAmount +
                    ", " + pPriceQuotationDetail.TotalPrice +
                    ", '" + pPriceQuotationDetail.Remarks +
                    "', '" + pPriceQuotationDetail.UserId + "');", _conn);
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

        public bool updatePriceQuotationDetail(PriceQuotationDetail pPriceQuotationDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdatePriceQuotationDetail(" + pPriceQuotationDetail.DetailId +
                    ", " + pPriceQuotationDetail.PriceQuotationId +
                    ", " + pPriceQuotationDetail.StockId +
                    ", " + pPriceQuotationDetail.LocationId +
                    ", " + pPriceQuotationDetail.Qty +
                    ", " + pPriceQuotationDetail.UnitPrice +
                    ", '" + pPriceQuotationDetail.DiscountId +
                    "', " + pPriceQuotationDetail.DiscountAmount +
                    ", " + pPriceQuotationDetail.TotalPrice +
                    ", '" + pPriceQuotationDetail.Remarks +
                    "', '" + pPriceQuotationDetail.UserId + "');", _conn);
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

        public bool removePriceQuotationDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemovePriceQuotationDetail('" + pDetailId +
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