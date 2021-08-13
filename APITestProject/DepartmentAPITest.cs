using System;
using Xunit;
using Moq;
using Core_API.Models;
using Core_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SharedLib;
using Core_API.Services;

namespace APITestProject
{

    public class DepartmentAPITest
    {
        /// <summary>
        /// The Attribute that represents the TestCase
        /// </summary>
        [Fact]
        public void GetDepartmentsTest()
        {

            // Arange

            List<Department> depts = new List<Department>();

            // MOck the DEependency for the Department API
            var mockDbContext = new Mock<IService<Department,int>>();

            // define an instance of the COntroller Object and pass the depednency
            var deptAPIController = new DepartmentAPController(mockDbContext.Object);

            // Act
            var result = deptAPIController.Get();
            var actual = result.Result;

            // Assertion
            Assert.IsType<OkObjectResult>(actual);
        }
    }
}
