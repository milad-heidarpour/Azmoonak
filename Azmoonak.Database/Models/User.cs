﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Azmoonak.Database.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "کد کاربر")]
        public Guid Id { get; set; }


        [Required]
        [Display(Name = "کد نقش")]
        public Guid RoleId { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LName { get; set; }


        [Required]
        [Display(Name = "شماره موبایل")]
        [MaxLength(11)]
        [MinLength(11)]
        public string Mobile { get; set; }//username


        [Required]
        public string Password { get; set; }


        //[MaxLength(4)]
        //[MinLength(4)]
        //public int Code { get; set; }


        [Display(Name = "وضعیت کاربر")]
        public bool IsActive { get; set; } = false;


        [ForeignKey("RoleId")]//user -> role -> 1
        public virtual Role Role { get; set; }
    }
}
