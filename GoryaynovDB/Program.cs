using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GoryaynovDB
{
    class Program
    {
        public static DatabaseContext context = null;
        public const int pageSize = 100;
        static void Main(string[] args) 
        { 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                 context = new DatabaseContext();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Environment.Exit(-1);
            }
        }
    }
}
