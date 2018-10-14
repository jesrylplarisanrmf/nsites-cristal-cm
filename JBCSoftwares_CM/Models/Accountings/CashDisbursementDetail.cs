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
    public class CashDisbursementDetail
    {
        public string DetailId { get; set; }
        public string JournalEntryId { get; set; }
        public string PurchaseOrderId { get; set; }
        public decimal AmountDue { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getCashDisbursementDetails(string pJournalEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetCashDisbursementDetails('" + pJournalEntryId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getCashDisbursementDetailsForEdit(string pJournalEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetCashDisbursementDetailsForEdit('" + pJournalEntryId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }
        
        public bool insertCashDisbursementDetail(CashDisbursementDetail pCashDisbursementDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertCashDisbursementDetail (" + pCashDisbursementDetail.JournalEntryId +
                    "," + pCashDisbursementDetail.PurchaseOrderId +
                    "," + pCashDisbursementDetail.AmountDue +
                    "," + pCashDisbursementDetail.PaymentAmount +
                    "," + pCashDisbursementDetail.Balance +
                    ",'" + pCashDisbursementDetail.Remarks +
                    "','" + pCashDisbursementDetail.UserId + "');", _conn);
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
        
        public bool updateCashDisbursementDetail(CashDisbursementDetail pCashDisbursementDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateCashDisbursementDetail(" + pCashDisbursementDetail.DetailId +
                    "," + pCashDisbursementDetail.JournalEntryId +
                    "," + pCashDisbursementDetail.PurchaseOrderId +
                    "," + pCashDisbursementDetail.AmountDue +
                    "," + pCashDisbursementDetail.PaymentAmount +
                    "," + pCashDisbursementDetail.Balance +
                    ",'" + pCashDisbursementDetail.Remarks +
                    "','" + pCashDisbursementDetail.UserId + "');", _conn);
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

        public bool removeCashDisbursementDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveCashDisbursementDetail('" + pDetailId +
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