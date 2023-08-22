using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azmoonak.Database.Models;

public class Question
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "درج متن سوال الزامی می باشد")]
    [Display(Name = "لطفا متن سوال خود را وارد نمایید")]
    public string QText { get; set; }

    [Required(ErrorMessage = "درج گزینه اول الزامی می باشد")]
    [Display(Name = "گزینه اول(الف)")]
    public string AnOne { get; set; }
    [Required(ErrorMessage = "درج گزینه دوم الزامی می باشد")]
    [Display(Name = "گزینه دوم(ب)")]
    public string AnTwo { get; set; }
    [Required(ErrorMessage = "درج گزینه سوم الزامی می باشد")]
    [Display(Name = "گزینه سوم(ج)")]
    public string AnThree { get; set; }
    [Required(ErrorMessage = "درج گزینه چهارم الزامی می باشد")]
    [Display(Name = "گزینه چهارم(د)")]
    public string AnFour { get; set; }
    [Required(ErrorMessage = "لطفا گزینه درست را انتخاب نمایید")]
    [Display(Name = "گزینه درست")]
    public string CorrectAn { get; set; }

    [Display(Name = "جواب کاربر")]
    public string? UserAn { get; set; } = null;

    [Required(ErrorMessage = "لطفا گروه مد نظر خود راانتخاب نمایید")]
    [Display(Name = "انتخاب گروه")]
    public int GroupId { get; set; }

    [ForeignKey("GroupId")]
    public virtual Group? Group { get; set; }
}
