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


    [Required(ErrorMessage = "درج متن سوال الزامی میباشد")]
    [Display(Name = "متن سوال")]
    public string QText { get; set; }

    [Required]
    [Display(Name = "گزینه اول")]
    public string AnOne { get; set; }
    [Required]
    [Display(Name = "گزینه دوم")]
    public string AnTwo { get; set; }
    [Required]
    [Display(Name = "گزینه سوم")]
    public string AnThree { get; set; }
    [Required]
    [Display(Name = "گزینه چهارم")]
    public string AnFour { get; set; }
    [Required]
    [Display(Name = "گزینه درست")]
    public string CorrectAn { get; set; }

    public int GroupId { get; set; }

    [ForeignKey("GroupId")]
    public virtual Group? Group { get; set; }
}
