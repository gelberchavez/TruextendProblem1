using System;
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

        [TestMethod]
        public void DeleteStudent_Test()
        {   // parameter test
            int pId = 6;
            //Instance the object
            clsStudent oStudent = new clsStudent();
            var vResult = oStudent.DeleteStudent(pId);
            Assert.IsNotNull(vResult, "Test");

            Console.WriteLine("-----Test Method DeleteStudent-----");
            Console.WriteLine(vResult+" Record delete: "+pId);

        }

        #endregion



        #region Servicio

        #endregion


        #region ServiciosTest

        #endregion
    }
}
