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
    public class JournalEntryDetail
    {
        public string DetailId { get; set; }
        public string JournalEntryId { get; set; }
        public string AccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Subsidiary { get; set; }
        public string SubsidiaryId { get; set; }
        public string SubsidiaryDescription { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getJournalEntryDetails(string pDisplayType, string pId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetJournalEntryDetails('" + pDisplayType + "'," + pId + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getGeneralLedgerAccounts(int pFinancialYear)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetGeneralLedgerAccounts('" + pFinancialYear + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getGeneralLedgerDetails(string pAccountId, int pFinancialYear)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetGeneralLedgerDetails('" + pAccountId + "','" + pFinancialYear + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getGeneralLedgerDetailsByDate(string pAccountId, int pFinancialYear, DateTime pDate)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetGeneralLedgerDetailsByDate('" + pAccountId + "','" + pFinancialYear + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getSubsidiaryLedgerDetailsByDate(string pAccountId, string pSubsidiaryId, string pSubsidiary, int pFinancialYear, DateTime pDate)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetSubsidiaryLedgerDetailsByDate('" + pAccountId + "','" + pSubsidiaryId + "','" + pSubsidiary + "','" + pFinancialYear + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getSubsidiaryLedgerAccounts(int pFinancialYear)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetSubsidiaryLedgerAccounts('" + pFinancialYear + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getSubsidiaries(string pAccountId, string pSubsidiary, int pFinancialYear)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetSubsidiaries('" + pAccountId + "','" + pSubsidiary + "','" + pFinancialYear + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getSubsidiaryLedgerDetails(string pAccountId, string pSubsidiaryId, string pSubsidiary, int pFinancialYear)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetSubsidiaryLedgerDetails('" + pAccountId + "','" + pSubsidiaryId + "','" + pSubsidiary + "','" + pFinancialYear + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getTrialBalance(int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetTrialBalance('" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getWorkSheetAccounts(int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetWorkSheetAccounts('" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getWorkSheetBeginningBalance(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetWorkSheetBeginningBalance('" + pAccountCode + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getWorkSheetTrialBalance(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetWorkSheetTrialBalance('" + pAccountCode + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getWorkSheetAdjustment(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetWorkSheetAdjustment(@AccountCode=N'" + pAccountCode + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getWorkSheetBalanceSheet(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetWorkSheetBalanceSheet('" + pAccountCode + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getWorkSheetIncomeStatement(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetWorkSheetIncomeStatement('" + pAccountCode + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getWorkSheetClosingEntry(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetWorkSheetClosingEntry('" + pAccountCode + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getBalanceSheetClassifications(string pClassification, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetBalanceSheetClassifications('" + pClassification + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getAccountBeginningBalance(int pFinancialYear, string pAccountCode)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetAccountBeginningBalance('" + pFinancialYear + "','" + pAccountCode + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getBalanceSheetSubClassifications(string pClassification, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetBalanceSheetSubClassifications('" + pClassification + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getBalanceSheetMainAccounts(string pSubClassification, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetBalanceSheetMainAccounts('" + pSubClassification + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getBalanceSheetMainAccountsForRetainedEarnings(string pSubClassification, int pFinancialYear, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetBalanceSheetMainAccountsForRetainedEarnings('" + pSubClassification + "','" + pFinancialYear + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getCOABeginningBalance(int pFinancialYear, string pAccountCode, string pAsOf)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetCOABeginningBalance('" + pFinancialYear + "','" + pAccountCode + "','" + pAsOf + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getIncomeStatementForClosingEntry(int pFinancialYear, string pClassification)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetIncomeStatementForClosingEntry('" + pFinancialYear + "','" + pClassification + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getBalanceForwardedAccounts(int pFinancialYear)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetBalanceForwardedAccounts('" + pFinancialYear + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertJournalEntryDetail(JournalEntryDetail pJournalEntryDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertJournalEntryDetail('" + pJournalEntryDetail.JournalEntryId +
                    "','" + pJournalEntryDetail.AccountId +
                    "','" + pJournalEntryDetail.Debit +
                    "','" + pJournalEntryDetail.Credit +
                    "','" + pJournalEntryDetail.Subsidiary +
                    "','" + pJournalEntryDetail.SubsidiaryId +
                    "','" + pJournalEntryDetail.SubsidiaryDescription +
                    "','" + pJournalEntryDetail.Remarks +
                    "','" + pJournalEntryDetail.UserId + "');", _conn);
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

        public bool updateJournalEntryDetail(JournalEntryDetail pJournalEntryDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateJournalEntryDetail('" + pJournalEntryDetail.DetailId +
                    "','" + pJournalEntryDetail.JournalEntryId +
                    "','" + pJournalEntryDetail.AccountId +
                    "','" + pJournalEntryDetail.Debit +
                    "','" + pJournalEntryDetail.Credit +
                    "','" + pJournalEntryDetail.Subsidiary +
                    "','" + pJournalEntryDetail.SubsidiaryId +
                    "','" + pJournalEntryDetail.SubsidiaryDescription +
                    "','" + pJournalEntryDetail.Remarks +
                    "','" + pJournalEntryDetail.UserId + "');", _conn);
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

        public bool removeJournalEntryDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveJournalEntryDetail('" + pDetailId +
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