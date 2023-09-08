
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Azmoonak.Database.Models;

public class Certificate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public int GroupId { get; set; }

    [Required]
    [Display(Name = "نمره پایانی")]
    public double FinalScore { get; set; }

    [Required]
    [Display(Name = "پاسخ های درست")]
    public int CorrectAnswer { get; set; }

    [Required]
    [Display(Name = "پاسخ های اشتباه")]
    public int FalseAnswer { get; set; }

    [Required]
    [Display(Name = "بدون پاسخ ها")]
    public int NoAnswer { get; set; }

    [Required]
    [Display(Name = "تاریخ امتحان")]
    public string OpenDateTime { get; set; }


    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(GroupId))]
    public virtual Group Group { get; set; }
}
