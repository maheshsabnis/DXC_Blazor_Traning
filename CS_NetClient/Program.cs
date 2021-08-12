using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFrwk_Lib;
namespace CS_NetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSource ds = new DataSource();
            var res = ds.GetDepartments();
            foreach (var item in res)
            {
                Console.WriteLine(item.DeptNo);
            }
            Console.ReadLine();
        }
    }
}
