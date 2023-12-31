﻿using System.ComponentModel.DataAnnotations;


namespace Azmoonak.Core.ViewModels;

public class LoginViewModel
{
    [Display(Name = "Mobile", Prompt = "شماره موبایل 11 رقمی")]
    [MaxLength(11, ErrorMessage = "شماره موبایل 11 رقمی")]
    [MinLength(11, ErrorMessage = "شماره موبایل 11 رقمی")]
    public string Mobile { get; set; }

    [Display(Name = "Password", Prompt = "رمز عبور حداقل 8 کارکتر")]
    [MinLength(8, ErrorMessage = "رمز عبور حداقل 8 کارکتر")]
    [MaxLength(25, ErrorMessage = "رمز عبور حداکثر 25 کارکتر")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
