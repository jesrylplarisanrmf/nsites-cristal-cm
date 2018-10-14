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
    public class JournalEntry
    {
        public string JournalEntryId { get; set; }
        public int FinancialYear { get; set; }
        public string Posted { get; set; }
        public string Cancel { get; set; }
        public string Journal { get; set; }
        public string Form { get; set; }
        public string VoucherNo { get; set; }
        public DateTime DatePrepared { get; set; }
        public string Explanation { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public string Reference { get; set; }
        public string SupplierId { get; set; }
        public string CustomerId { get; set; }
        public string BegBal { get; set; }
        public string Adjustment { get; set; }
        public string ClosingEntry { get; set; }
        public string PreparedBy { get; set; }
        public string PostedBy { get; set; }
        public DateTime DatePosted { get; set; }
        public string CancelledBy { get; set; }
        public string CancelledReason { get; set; }
        public DateTime DateCancelled { get; set; }
        public string Remarks { get; set; }
        public string SOId { get; set; }
        public string POId { get; set; }
        public string UserId { get; set; }

        public DataTable getJournalEntrys(string pJournal, string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetJournalEntrys('" + pJournal + "','" + pDisplayType + "'," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ",'" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getJournalEntryStatus(string pJournalEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetJournalEntryStatus('" + pJournalEntryId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getJournalEntryBySOId(string pSOId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetJournalEntryBySOId('" + pSOId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getJournalEntryByPOId(string pPOId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetJournalEntryByPOId('" + pPOId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getJournalEntryReport(int pFinancialYear)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetJournalEntryReport(" + pFinancialYear + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertJournalEntry(JournalEntry pJournalEntry)
        {
            string _result = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertJournalEntry('" + pJournalEntry.FinancialYear +
                    "','" + pJournalEntry.Journal +
                    "','" + pJournalEntry.Form +
                    "','" + pJournalEntry.VoucherNo +
                    "','" + String.Format("{0:yyyy-MM-dd}", pJournalEntry.DatePrepared) +
                    "','" + pJournalEntry.Explanation +
                    "','" + pJournalEntry.TotalDebit +
                    "','" + pJournalEntry.TotalCredit +
                    "','" + pJournalEntry.Reference +
                    "','" + pJournalEntry.SupplierId +
                    "','" + pJournalEntry.CustomerId +
                    "','" + pJournalEntry.BegBal +
                    "','" + pJournalEntry.Adjustment +
                    "','" + pJournalEntry.ClosingEntry +
                    "','" + pJournalEntry.UserId +
                    "','" + pJournalEntry.Remarks +
                    "','" + pJournalEntry.SOId + 
                    "','" + pJournalEntry.POId +
                    "','" + pJournalEntry.UserId + "');", _conn);
                
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

        public string updateJournalEntry(JournalEntry pJournalEntry)
        {
            string _result = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateJournalEntry('" + pJournalEntry.JournalEntryId +
                    "','" + pJournalEntry.FinancialYear +
                    "','" + pJournalEntry.Journal +
                    "','" + pJournalEntry.Form +
                    "','" + pJournalEntry.VoucherNo +
                    "','" + String.Format("{0:yyyy-MM-dd}", pJournalEntry.DatePrepared) +
                    "','" + pJournalEntry.Explanation +
                    "','" + pJournalEntry.TotalDebit +
                    "','" + pJournalEntry.TotalCredit +
                    "','" + pJournalEntry.Reference +
                    "','" + pJournalEntry.SupplierId +
                    "','" + pJournalEntry.CustomerId +
                    "','" + pJournalEntry.BegBal +
                    "','" + pJournalEntry.Adjustment +
                    "','" + pJournalEntry.ClosingEntry +
                    "','" + pJournalEntry.UserId +
                    "','" + pJournalEntry.Remarks +
                    "','" + pJournalEntry.SOId +
                    "','" + pJournalEntry.POId +
                    "','" + pJournalEntry.UserId + "');", _conn);
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

        public bool removeJournalEntry(string pJournalEntryId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveJournalEntry('" + pJournalEntryId +
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

        public bool postJournalEntry(string pJournalEntryId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spPostJournalEntry('" + pJournalEntryId +
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

        public bool cancelJournalEntry(string pJournalEntryId,string pCancelledReason, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spCancelJournalEntry('" + pJournalEntryId +
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