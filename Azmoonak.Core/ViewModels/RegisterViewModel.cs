using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Azmoonak.Core.ViewModels;

public class RegisterViewModel
{
    [Display(Name = "نام",Prompt ="نام خود را وارد کنید")]
    public string FName { get; set; }

    [Display(Name = "نام خانوادگی", Prompt = "نام خانوادگی خود را وارد کنید")]
    public string LName { get; set; }

    [Display(Name = "Mobile", Prompt = "شماره موبایل 11 رقمی")]
    [MaxLength(11, ErrorMessage = "شماره موبایل 11 رقمی")]
    [MinLength(11, ErrorMessage = "شماره موبایل 11 رقمی")]
    public string Mobile { get; set; }

    [Display(Name = "Password", Prompt = "رمز عبور حداقل 8 کارکتر")]
    [MinLength(8, ErrorMessage = "رمز عبور حداقل 8 کارکتر")]
    [MaxLength(25, ErrorMessage = "رمز عبور حداکثر 25 کارکتر")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Confirm Password", Prompt = "رمز عبور حداقل 8 کارکتر")]
    [MinLength(8, ErrorMessage = "رمز عبور حداقل 8 کارکتر")]
    [MaxLength(25, ErrorMessage = "رمز عبور حداکثر 25 کارکتر")]
    [DataType(DataType.Password)]
    public string RePassword { get; set; }
}
