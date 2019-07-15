﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models.BBTModels
{
   public class BBTUpdate
    {
        public int BBTID { get; set; }
        [Required]
        public double Temperature { get; set; }
        [Required]
        [Display(Name = "Date temperature was taken")]
        public DateTime DateOfTemp { get; set; }
        public string Comments { get; set; }
    }
}