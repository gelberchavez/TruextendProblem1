using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Truextend.StudentManagement.Core.Bussiness;

namespace Truextend.StudentManagement.Core.Testing
{
    /// <summary>
    /// Summary description for Clasificador
    /// </summary>
    [TestClass]
    public class clsStudentTest
    {
        #region  TestMethods
        // Unit Test Method AddStudent
        [TestMethod]
        public void AddStudent_Test()
        {
            //Instance the object
            clsStudent oStudent = new clsStudent();
            var vResult = oStudent.AddStudent("university", "ivan", "M", DateTime.Now);
            Assert.IsNotNull(vResult, "Test");

            Console.WriteLine("-----Test Method AddStudent-----");
            Console.WriteLine(vResult);
        }
        // Unit Test Method DeleteStudent
        [TestMethod]
        public void DeleteStudent_Test()
        {   // parameter test
            int pId = 6;
            //Instance the object
            clsStudent oStudent = new clsStudent();
            var vResult = oStudent.DeleteStudent(pId);
            Assert.IsNotNull(vResult, "Test");

            Console.WriteLine("-----Test Method DeleteStudent-----");
            Console.WriteLine(vResult + " Record delete: " + pId);

        }
        // Unit Test Method GetStudentById
        [TestMethod]
        public void GetStudentById_Test()
        {   // parameter test
            int pId = 4;
            //Instance the object
            clsStudent oStudent = new clsStudent();
            var vResult = oStudent.GetStudentbyId(pId);
            Assert.IsNotNull(vResult, "Test");

            Console.WriteLine("-----Test Get Student by Id-----");
            Console.WriteLine(vResult + " Record: " + vResult.Id + "  " + vResult.StudentType + "  " + vResult.StudentName + " " + vResult.Gender + " " + vResult.DateTimeStamp.ToString());
        }
        // Unit Test Method GetStudents
        [TestMethod]
        public void GetStudents_Test()
        {   //Instance the object
            clsStudent oStudent = new clsStudent();
            var vResult = oStudent.GetStudentsSortedName();
            Assert.IsNotNull(vResult, "Test");
            Console.WriteLine("-----Test Get Students sorted by name-----");
            int count = 0;
            foreach (DataRow datarow in vResult.Rows)
            {
                count++;
                Console.WriteLine("***************** Record " + count + "********************");
                Console.WriteLine(datarow[0].ToString() + " " + datarow[1].ToString() + " " + datarow[2].ToString() + " " + datarow[3].ToString() + " " + datarow[4].ToString());
            }


        }
        // Unit Test Method GetStudentsByType
        [TestMethod]
        public void GetStudentsByType_Test()
        {   //Instance the object
            clsStudent oStudent = new clsStudent();
            var vResult = oStudent.GetStudentsByType("Kinder");
            Assert.IsNotNull(vResult, "Test");
            Console.WriteLine("-----Test Get Students by Type-----");
            int count = 0;
            foreach (DataRow datarow in vResult.Rows)
            {
                count++;
                Console.WriteLine("***************** Record " + count + "********************");
                Console.WriteLine(datarow[0].ToString() + " " + datarow[1].ToString() + " " + datarow[2].ToString() + " " + datarow[3].ToString() + " " + datarow[4].ToString());
            }
        }
        // Unit Test Method GetStudentsByGender_Type
        [TestMethod]
        public void GetStudentsByGender_Type()
        {
            //Instance the object
            clsStudent oStudent = new clsStudent();
            var vResult = oStudent.GetStudentsByGender_Type("F","High");
            Assert.IsNotNull(vResult, "Test");
            Console.WriteLine("-----Test Get Students by Gender and Type-----");
            int count = 0;
            foreach (DataRow datarow in vResult.Rows)
            {
                count++;
                Console.WriteLine("***************** Record " + count + "********************");
                Console.WriteLine(datarow[0].ToString() + " " + datarow[1].ToString() + " " + datarow[2].ToString() + " " + datarow[3].ToString() + " " + datarow[4].ToString());
            }

        }
        #endregion



        #region Servicio

        #endregion


        #region ServiciosTest

        #endregion
    }
}
