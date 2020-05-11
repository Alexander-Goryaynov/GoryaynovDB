using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GoryaynovDB
{
    class Program
    {
        static DatabaseContext context = null;
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
