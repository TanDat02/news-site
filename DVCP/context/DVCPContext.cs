using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVCP.Models;
using System.Data.Entity;



namespace DVCP.Context
{
    public class DVCPcontext : DbContext
    {


        public DbSet<Tinh> Tinhs { get; set; }
        public DbSet<Huyen> Huyens { get; set; }
        public DbSet<Xa> Xas { get; set; }



    }

}