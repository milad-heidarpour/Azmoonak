using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azmoonak.Database.Models;

public class Group
{
    [Key]
    public int Id { get; set; }



    [Required(ErrorMessage = "نام گروه الزامی است")]
    [MaxLength(20)]
    [Display(Name = "نام گروه ")]
    public string GroupName { get; set; }


    [Display(Name = "درباره گروه")]
    [MaxLength(100)]
    public string? GroupDes { get; set; }


    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;
    public virtual ICollection<Question>? Questions { get; set; }
}
