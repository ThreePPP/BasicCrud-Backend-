using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Models
{
    public partial class Customer
    {
        public List<Customer> Gettall(BasicDbContext db)
        {
            List<Customer> customers = db.Customers
            .Where(c => c.IsDelete == false)
            .ToList();
            return customers;
        }

        public void Delete(BasicDbContext db)
        {
            IsDelete = true;
        }

        public Customer Create(BasicDbContext db) {
            db.Customers.Add(this);
            return this;
        }

        public Customer Update(BasicDbContext db) {
            Customer customer = db.Customers.Where(c => c.Id == Id || c.IsDelete == false).FirstOrDefault();
                customer.User = User;
                db.SaveChanges(); 
            return customer;
        }
    }
}
