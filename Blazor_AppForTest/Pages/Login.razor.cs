using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_AppForTest.Pages
{
    /// <summary>
    /// Code Behind class for the Login.razor
    /// </summary>
    public partial class Login
    {
        // inject the ILoginLogic interface
        [Inject] // same as @inject
        private ILoginLogic loginLogic { get; set; }
        private string errorMessage = string.Empty;
        //declare an instance of LoginModel
        private LoginModel login = new(); // C# 9.0 feature for creating instance based on LHS object

        // writing helper methods
        private bool IsEmailValid()
        {
            if (!string.IsNullOrEmpty(login.Email))
            {
                return true;
            }
            return false;
        }

        private bool IsPasswordValid()
        {
            if (!string.IsNullOrEmpty(login.Password))
            {
                return true;
            }
            return false;
        }

        private void SignIn()
        {
            if (IsEmailValid() && IsPasswordValid())
            {
                if (!loginLogic.SignIn(login.Email, login.Password))
                {
                    errorMessage = "Invalid Object";
                }
            }
            else
            {
                errorMessage = "Email/Password Invalid";
            }
        }
    }
}
