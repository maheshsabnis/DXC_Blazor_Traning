using Blazor_AppForTest.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Blazor_TestProject
{
    [TestClass()]
    public class LoginTests
    {
        // COllect all Dependencies
        private Bunit.TestContext testContext; // Used for setting the TEst COntext for Blazor Component
        private Moq.Mock<ILoginLogic> mock; // Help to create a Fake Object to Mock the LoginLogic Object
        public LoginTests()
        {
            testContext = new Bunit.TestContext();
            mock = new Moq.Mock<ILoginLogic>();
        }

        /// <summary>
        /// The Test Method
        /// </summary>
        [TestMethod()]
        public void SignInTest_With_Empty_Email_Password()
        {
            // Recive the Mock Object from the ILoginLogic
            testContext.Services.AddScoped(m => mock.Object);
            // Render the COmponent in the Memory of the TestContext so that its
            // DOM Tree Can be extracted
            var component = testContext.RenderComponent<Login>();

            // Running Assertion to Verify the Static HTML
            NUnit.Framework.Assert.IsTrue(component.Markup.Contains("<h2>Hello, World!</h2>"));

            // Check for the Button and if FOund read its Text/Caption and Raise Click event on it
            var buttons = component.FindAll("button");
            // MAkse sure that youn have a single button
            // 
            NUnit.Framework.Assert.AreEqual(1, buttons.Count);
            // Check and verify the button is Submit button
            // 
            var btnSubmit = buttons.FirstOrDefault(b=>b.OuterHtml.Contains("Submit"));
            // Assertion for Submit Button Exists

            NUnit.Framework.Assert.IsNotNull(btnSubmit);
            // Raise Evenbt

            btnSubmit.Click();
            // Make sure that the SignIN method is called
            mock.Verify(l => l.SignIn(string.Empty, string.Empty), Times.Never);
            // verify the the <div> with class as 'alert' is displayed in DOM Tree
            var dv = component.Find("div.alert");
            // Read the InnerHtml for the Div
            NUnit.Framework.Assert.AreEqual("Email/Password Invalid", dv.InnerHtml);


        }
    }
}