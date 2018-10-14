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
    public class Employee
    {
        public string Id { get; set; }
        public string EmployeeNo { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Active { get; set; }
        public string BiometricsIdNo { get; set; }
        public string EmploymentTypeId { get; set; }
        public string DesignationId { get; set; }
        public string DepartmentId { get; set; }
        public string NoWorkSchedule { get; set; }
        public string WorkScheduleId { get; set; }
        public DateTime Birthday { get; set; }
        public string EmailAddress { get; set; }
        public string TIN { get; set; }
        public string TINDeducted { get; set; }
        public string PhilHealthId { get; set; }
        public string PhilHealthDeducted { get; set; }
        public string SSSId { get; set; }
        public string SSSDeducted { get; set; }
        public string PagibigId { get; set; }
        public string PagibigDeducted { get; set; }
        public decimal PagibigEmployeeShare { get; set; }
        public decimal PagibigEmployerShare { get; set; }
        public int NoOfDependent { get; set; }
        public string RateType { get; set; }
        public decimal BasicPay { get; set; }
        public string ImmediateSupervisor { get; set; }
        public string Remarks { get; set; }
        public string Picture { get; set; }
        public string UserId { get; set; }

        public DataTable getEmployees(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetEmployees('" + pDisplayType + "','" + pPrimaryKey + "','" + pSearchString + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getEmployeeNames()
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetEmployeeNames()", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertEmployee(Employee pEmployee)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertEmployee('" + pEmployee.EmployeeNo +
                    "','" + pEmployee.Lastname +
                    "','" + pEmployee.Firstname +
                    "','" + pEmployee.Middlename +
                    "','" + pEmployee.Active +
                    "','" + pEmployee.BiometricsIdNo +
                    "','" + pEmployee.EmploymentTypeId +
                    "','" + pEmployee.DesignationId +
                    "','" + pEmployee.DepartmentId +
                    "','" + pEmployee.NoWorkSchedule +
                    "','" + pEmployee.WorkScheduleId +
                    "','" + String.Format("{0:yyyy-MM-dd}", pEmployee.Birthday) +
                    "','" + pEmployee.EmailAddress +
                    "','" + pEmployee.TIN +
                    "','" + pEmployee.TINDeducted +
                    "','" + pEmployee.PhilHealthId +
                    "','" + pEmployee.PhilHealthDeducted +
                    "','" + pEmployee.SSSId +
                    "','" + pEmployee.SSSDeducted +
                    "','" + pEmployee.PagibigId +
                    "','" + pEmployee.PagibigDeducted +
                    "','" + pEmployee.PagibigEmployeeShare +
                    "','" + pEmployee.PagibigEmployerShare +
                    "','" + pEmployee.NoOfDependent +
                    "','" + pEmployee.RateType +
                    "','" + pEmployee.BasicPay +
                    "','" + pEmployee.ImmediateSupervisor +
                    "','" + pEmployee.Remarks +
                    "','" + pEmployee.UserId + "');", _conn);
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

        public string updateEmployee(Employee pEmployee)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateEmployee('" + pEmployee.Id +
                    "','" + pEmployee.EmployeeNo +
                    "','" + pEmployee.Lastname +
                    "','" + pEmployee.Firstname +
                    "','" + pEmployee.Middlename +
                    "','" + pEmployee.Active +
                    "','" + pEmployee.BiometricsIdNo +
                    "','" + pEmployee.EmploymentTypeId +
                    "','" + pEmployee.DesignationId +
                    "','" + pEmployee.DepartmentId +
                    "','" + pEmployee.NoWorkSchedule +
                    "','" + pEmployee.WorkScheduleId +
                    "','" + String.Format("{0:yyyy-MM-dd}", pEmployee.Birthday) +
                    "','" + pEmployee.EmailAddress +
                    "','" + pEmployee.TIN +
                    "','" + pEmployee.TINDeducted +
                    "','" + pEmployee.PhilHealthId +
                    "','" + pEmployee.PhilHealthDeducted +
                    "','" + pEmployee.SSSId +
                    "','" + pEmployee.SSSDeducted +
                    "','" + pEmployee.PagibigId +
                    "','" + pEmployee.PagibigDeducted +
                    "','" + pEmployee.PagibigEmployeeShare +
                    "','" + pEmployee.PagibigEmployerShare +
                    "','" + pEmployee.NoOfDependent +
                    "','" + pEmployee.RateType +
                    "','" + pEmployee.BasicPay +
                    "','" + pEmployee.ImmediateSupervisor +
                    "','" + pEmployee.Remarks +
                    "','" + pEmployee.UserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    _Id = _cmd.ExecuteScalar().ToString();
                    _trans.Commit();
                    _conn.Close();
                }
                catch(Exception ex)
                {
                    //_trans.Rollback();
                    //_Id = "";
                    _Id = ex.Message;
                }
            }
            return _Id;
        }

        public bool removeEmployee(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveEmployee('" + pId +
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