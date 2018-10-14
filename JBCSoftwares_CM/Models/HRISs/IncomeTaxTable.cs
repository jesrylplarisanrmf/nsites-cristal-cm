using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using System.DirectoryServices.AccountManagement;
using MySql.Data.MySqlClient;

namespace JCSoftwares_CM.Models.HRISs
{
    public class IncomeTaxTable
    {
        public string Id { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal BaseTax { get; set; }
        public decimal PercentOver { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getIncomeTaxTables(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetIncomeTaxTables('" + pDisplayType + "'," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ",'" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertIncomeTaxTable(IncomeTaxTable pIncomeTaxTable)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertIncomeTaxTable('" + pIncomeTaxTable.LowerLimit +
                    "','" + pIncomeTaxTable.UpperLimit +
                    "','" + pIncomeTaxTable.BaseAmount +
                    "','" + pIncomeTaxTable.BaseTax +
                    "','" + pIncomeTaxTable.PercentOver +
                    "','" + pIncomeTaxTable.Remarks +
                    "','" + pIncomeTaxTable.UserId + "');", _conn);
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

        public string updateIncomeTaxTable(IncomeTaxTable pIncomeTaxTable)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateIncomeTaxTable('" + pIncomeTaxTable.Id +
                    "','" + pIncomeTaxTable.LowerLimit +
                    "','" + pIncomeTaxTable.UpperLimit +
                    "','" + pIncomeTaxTable.BaseAmount +
                    "','" + pIncomeTaxTable.BaseTax +
                    "','" + pIncomeTaxTable.PercentOver +
                    "','" + pIncomeTaxTable.Remarks +
                    "','" + pIncomeTaxTable.UserId + "');", _conn);
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

        public bool removeIncomeTaxTable(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveIncomeTaxTable('" + pId +
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