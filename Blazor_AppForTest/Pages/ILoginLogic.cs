using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_AppForTest.Pages
{
    public interface ILoginLogic
    {
        bool SignIn(string email,string password);
    }
}
