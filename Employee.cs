using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class Employee
    {
       

        public int  eid { get; set; }

        public string ename { get; set; }

        public int esal { get; set; }
      


        public Employee()
        {

        }

        public Employee(int eid, string ename,int esal)
        {
            this.eid = eid;
            this.ename = ename;
            this.esal = esal;
        }

    }
}