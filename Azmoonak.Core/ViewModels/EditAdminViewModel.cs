﻿
using System.ComponentModel.DataAnnotations;

namespace Azmoonak.Core.ViewModels;

public class EditAdminViewModel
{
    [Display(Name = "کد کاربر")]
    public Guid Id { get; set; }

    [Display(Name = "کد نقش")]
    public Guid RoleId { get; set; }

    [Display(Name = "نام")]
    public string FName { get; set; }

    [Display(Name = "نام خانوادگی")]
    public string LName { get; set; }


    [Display(Name = "شماره موبایل")]
    [MaxLength(11)]
    [MinLength(11)]
    public string Mobile { get; set; }//username


    public string Password { get; set; }

}
