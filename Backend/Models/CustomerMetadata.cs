using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Models
{
    public partial class Customer
    {
        public List<Customer> GetAll(BasicDbContext db)
        {
            List<Customer> customers = db.Customers
            .Where(c => c.IsDelete == false)
            .ToList();
            return customers;
        }

        public void Delete()
        {
            IsDelete = true;
        }

        public Customer Create(BasicDbContext db) {
            db.Customers.Add(this);
            db.SaveChanges();
            return this;
        }

        public Customer Update(BasicDbContext db , int Id) {
            Customer customer = db.Customers
                                .FirstOrDefault(c => c.Id == Id && c.IsDelete == false);
                this.Id = Id;
                db.Entry(customer).CurrentValues.SetValues(this);
                db.SaveChanges();
                return customer;
        }
    }
}
