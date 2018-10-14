using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using System.DirectoryServices.AccountManagement;
using MySql.Data.MySqlClient;

namespace JCSoftwares_CM.Models.Accountings
{
    public class CashReceiptDetail
    {
        public string DetailId { get; set; }
        public string JournalEntryId { get; set; }
        public string SalesOrderId { get; set; }
        public decimal AmountDue { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getCashReceiptDetails(string pJournalEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetCashReceiptDetails('" + pJournalEntryId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertCashReceiptDetail(CashReceiptDetail pCashReceiptDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertCashReceiptDetail(" + pCashReceiptDetail.JournalEntryId +
                    "," + pCashReceiptDetail.SalesOrderId +
                    "," + pCashReceiptDetail.AmountDue +
                    "," + pCashReceiptDetail.PaymentAmount +
                    "," + pCashReceiptDetail.Balance +
                    ",'" + pCashReceiptDetail.Remarks +
                    "','" + pCashReceiptDetail.UserId + "');", _conn);
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

        public bool updateCashReceiptDetail(CashReceiptDetail pCashReceiptDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateCashReceiptDetail(" + pCashReceiptDetail.DetailId +
                    "," + pCashReceiptDetail.JournalEntryId +
                    "," + pCashReceiptDetail.SalesOrderId +
                    "," + pCashReceiptDetail.AmountDue +
                    "," + pCashReceiptDetail.PaymentAmount +
                    "," + pCashReceiptDetail.Balance +
                    ",'" + pCashReceiptDetail.Remarks +
                    "','" + pCashReceiptDetail.UserId + "');", _conn);
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

        public bool removeCashReceiptDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveCashReceiptDetail('" + pDetailId +
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