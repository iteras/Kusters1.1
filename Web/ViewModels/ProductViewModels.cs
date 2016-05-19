﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class ProductPictureViewModels
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Picture Picture { get; set; }


        [Required(ErrorMessageResourceName = "NotSelected", ErrorMessageResourceType = typeof(Resources.Domain))]
        public SelectList AllProducts { get; set; }
    }
   public class ProductViewModels
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        [Required(ErrorMessageResourceName = "NotSelected", ErrorMessageResourceType = typeof(Resources.Domain) )]
        public SelectList AllPersons { get; set; }
        public List<Description> GetDescriptionsByProduct { get; set; } 

        public Person GetPerson { get; set; }
        public List<Product> AllProducts { get; set; } 
        public List<Product> GetProductByPerson { get; set; }
    }
}