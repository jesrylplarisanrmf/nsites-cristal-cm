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
    public class ChartOfAccount
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string ClassificationId { get; set; }
        public string SubClassificationId { get; set; }
        public string MainAccountId { get; set; }
        public string AccountTitle { get; set; }
        public string ContraAccount { get; set; }
        public string TypeOfAccount { get; set; }
        public string Subsidiary { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getChartOfAccounts(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetChartOfAccounts('" + pDisplayType + "'," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ",'" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertChartOfAccount(ChartOfAccount pChartOfAccount)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertChartOfAccount('" + pChartOfAccount.Code +
                    "','" + pChartOfAccount.ClassificationId +
                    "','" + pChartOfAccount.SubClassificationId +
                    "','" + pChartOfAccount.MainAccountId +
                    "','" + pChartOfAccount.AccountTitle +
                    "','" + pChartOfAccount.TypeOfAccount +
                    "','" + pChartOfAccount.Subsidiary +
                    "','" + pChartOfAccount.ContraAccount +
                    "','" + pChartOfAccount.Remarks +
                    "','" + pChartOfAccount.UserId + "');", _conn);
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

        public string updateChartOfAccount(ChartOfAccount pChartOfAccount)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateChartOfAccount('" + pChartOfAccount.Id +
                    "','" + pChartOfAccount.Code +
                    "','" + pChartOfAccount.ClassificationId +
                    "','" + pChartOfAccount.SubClassificationId +
                    "','" + pChartOfAccount.MainAccountId +
                    "','" + pChartOfAccount.AccountTitle +
                    "','" + pChartOfAccount.TypeOfAccount +
                    "','" + pChartOfAccount.Subsidiary +
                    "','" + pChartOfAccount.ContraAccount +
                    "','" + pChartOfAccount.Remarks +
                    "','" + pChartOfAccount.UserId + "');", _conn);
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

        public bool removeChartOfAccount(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveChartOfAccount('" + pId +
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