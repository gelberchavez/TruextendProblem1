using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Truextend.StudentManagement.Core.Entities;

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
            SqlCommand command = new SqlCommand("psAddStudent", conexion);
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

            catch(Exception e)
            {
                sw = false; // error
            }

            // Close the conexion.
            conexion.Close();
            // return boolean
            return sw;
        }

        //Method to delete a STUDENT in the DB.


        //Method: search by name, sorted alphabetically


        //Method: search by type, sorted  by date,most recent to least recent.


        //Method: search by gender and type, sorted  by date,most recent to least recent.


        #endregion

    }
}
