using System.ComponentModel.DataAnnotations;
using StudentVoiceNU.Domain.Entities;
public class AuditableEntity:BaseEntity
{
    public DateTime CreatedAt { get; set; }=DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}