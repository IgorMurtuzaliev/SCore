﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SCore.Models
{
    public class Product
    {
        public Product()
        {

        }

        public int ProductId { get; set; }
        [Display(Name = "Products name")]
        [Required(ErrorMessage = "Input products name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Input products price")]
        public int Price { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Input desciption")]
        public string Description { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.Now;
        public List<byte[]> Images { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
