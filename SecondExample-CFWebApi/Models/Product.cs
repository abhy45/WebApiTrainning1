using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecondExample_CFWebApi.Models
{
    /// <summary>
    /// Representation of a Product in a CF Approach in Web API.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public int NewColumn { get; set; }
    }
}
