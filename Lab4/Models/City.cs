﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models
{
    [Table("city")]
    public partial class City
    {
        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "char(35)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "char(3)")]
        public string CountryCode { get; set; }
        [Required]
        [Column(TypeName = "char(20)")]
        public string District { get; set; }
        [Column(TypeName = "int(11)")]
        public int Population { get; set; }

        [ForeignKey(nameof(CountryCode))]
        [InverseProperty(nameof(Country.City))]
        public virtual Country CountryCodeNavigation { get; set; }
    }
}
