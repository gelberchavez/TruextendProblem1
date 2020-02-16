using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Truextend.StudentManagement.Core.Entities;
using System.Globalization;

namespace Truextend.StudentManagement.Core.Bussiness
{
    public class clsStudent : clsStudentBE
    {
        #region Constructor
        //Constructor de la clase
        public clsStudent()
        {
            this.Id = 0;
            this.StudentType = string.Empty;
            this.StudentName = string.Empty;
            this.Gender = string.Empty;
            this.DateTimeStamp = DateTime.Now;
        }

        #endregion
        //String Conexion
        string ConexionString = ConfigurationManager.ConnectionStrings["StudentsConexion"].ConnectionString;

        #region Metodos
        //Method to register a STUDENT in the DB.
        public bool AddStudent(string pStudentType, string pStudentName, string pGender, DateTime pDateTimeStamp)
        {
            bool sw = false;
            //Open the conexion with DB.
            SqlConnection conexion = new SqlConnection(ConexionString);
            conexion.Open();
            // Instance the  command which calls the stored procedure of the DB.
            SqlCommand command = new SqlCommand("spAddStudent", conexion);
            command.CommandType = CommandType.StoredProcedure;
            // Insert the parameters of  the stored procedure.
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@StudentType",
                SqlDbType = SqlDbType.NVarChar,
                Value = pStudentType,
                Direction = ParameterDirection.Input
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@StudentName",
                SqlDbType = SqlDbType.NVarChar,
                Value = pStudentName,
                Direction = ParameterDirection.Input
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Gender",
                SqlDbType = SqlDbType.NVarChar,
                Value = pGender,
                Direction = ParameterDirection.Input
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DateTimeStamp",
                SqlDbType = SqlDbType.DateTime,
                Value = pDateTimeStamp,
                Direction = ParameterDirection.Input
            });

            try
            {
                // Execute query
                command.ExecuteNonQuery();
                sw = true;// execute affirmative
            }

            catch (Exception e)
            {
                sw = false; // error
            }

            // Close the conexion.
            conexion.Close();
            // return boolean
            return sw;
        }

        //Method to delete a STUDENT in the DB.
        public bool DeleteStudent(int pId)
        {
            bool sw = false;
            //Open the conexion with DB.
            SqlConnection conexion = new SqlConnection(ConexionString);
            conexion.Open();
            // Instance the  command which calls the stored procedure of the DB.
            SqlCommand command = new SqlCommand("spDeleteStudent", conexion);
            command.CommandType = CommandType.StoredProcedure;
            // Insert the parameters of  the stored procedure.
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Value = pId,
                Direction = ParameterDirection.Input
            });
            try
            {
                // Execute query
                command.ExecuteNonQuery();
                sw = true;// execute affirmative
            }
            catch (Exception e)
            {
                sw = false; // error
            }
            // Close the conexion.
            conexion.Close();
            // return boolean
            return sw;
        }

        //Method: Get Student Record by Id
        public clsStudentBE GetStudentbyId(int pId)
        {
            clsStudentBE oStudent = new clsStudentBE();
            //Open the conexion with DB.
            SqlConnection conexion = new SqlConnection(ConexionString);
            conexion.Open();
            // Instance the  command which calls the stored procedure of the DB.
            SqlCommand command = new SqlCommand("spGetStudentbyId", conexion);
            command.CommandType = CommandType.StoredProcedure;
            // Insert the parameters of  the stored procedure.
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Value = pId,
                Direction = ParameterDirection.Input
            });
            // Execute procedure.
            var vTable = command.ExecuteReader();
            if (vTable.HasRows)
            {
                var dataTable = new DataTable();
                dataTable.Load(vTable);
                oStudent.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                oStudent.StudentType = dataTable.Rows[0][1].ToString();
                oStudent.StudentName = dataTable.Rows[0][2].ToString();
                oStudent.Gender = dataTable.Rows[0][3].ToString();
                oStudent.DateTimeStamp = Convert.ToDateTime(dataTable.Rows[0][4].ToString());

            }
            return oStudent;
        }

        //Method: Get Students sorted alphabetically by name
        public DataTable GetStudentsSortedName()
        {
            DataTable oDataStudents = new DataTable();
            //Open the conexion with DB.
            SqlConnection conexion = new SqlConnection(ConexionString);
            conexion.Open();
            // Instance the  command which calls the stored procedure of the DB.
            SqlCommand command = new SqlCommand("spGetStudentSbyName", conexion);
            command.CommandType = CommandType.StoredProcedure;

            // Execute procedure.
            var vTable = command.ExecuteReader();
            if (vTable.HasRows)
            {
                var dataTable = new DataTable();
                dataTable.Load(vTable);
                oDataStudents = dataTable;
            }

            return oDataStudents;
        }

        //Method: search by type, sorted  by date,most recent to least recent.
        public DataTable GetStudentsByType(string pType)
        {
            DataTable oDataStudents = new DataTable();
            //Open the conexion with DB.
            SqlConnection conexion = new SqlConnection(ConexionString);
            conexion.Open();
            // Instance the  command which calls the stored procedure of the DB.
            SqlCommand command = new SqlCommand("spGetStudentsByType", conexion);
            command.CommandType = CommandType.StoredProcedure;
            // Insert the parameters of  the stored procedure.
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@StudentType",
                SqlDbType = SqlDbType.NVarChar,
                Value = pType,
                Direction = ParameterDirection.Input
            });
            // Execute procedure.
            var vTable = command.ExecuteReader();
            if (vTable.HasRows)
            {
                var dataTable = new DataTable();
                dataTable.Load(vTable);
                oDataStudents = dataTable;
            }

            return oDataStudents;
        }

        //Method: search by gender and type, sorted  by date,most recent to least recent.
        public DataTable GetStudentsByGender_Type(string pGender, string pType)
        {
            DataTable oDataStudents = new DataTable();
            //Open the conexion with DB.
            SqlConnection conexion = new SqlConnection(ConexionString);
            conexion.Open();
            // Instance the  command which calls the stored procedure of the DB.
            SqlCommand command = new SqlCommand("spGetStudentsByGender_Type", conexion);
            command.CommandType = CommandType.StoredProcedure;
            // Insert the parameters of  the stored procedure.
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Gender",
                SqlDbType = SqlDbType.NVarChar,
                Value = pGender,
                Direction = ParameterDirection.Input
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@StudentType",
                SqlDbType = SqlDbType.NVarChar,
                Value = pType,
                Direction = ParameterDirection.Input
            });
            // Execute procedure.
            var vTable = command.ExecuteReader();
            if (vTable.HasRows)
            {
                var dataTable = new DataTable();
                dataTable.Load(vTable);
                oDataStudents = dataTable;
            }

            return oDataStudents;
        }

        #endregion

    }
}
