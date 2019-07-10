﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class OvulationStick
    {
        [Key]
        public int OvStickID { get; set; }

        [ForeignKey(nameof(PersonalInfo))]
        public Guid UserID { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        [Required]
        [Display(Name = "Are you ovulating, according to the ovulation stick?")]
        public bool Ovulation { get; set; }
        [Required]
        [Display(Name ="Date of ovulation stick use")]
        public DateTime DateOfUse { get; set; }
        public string Comments { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset? ModifiedTime { get; set; }
    }
}
