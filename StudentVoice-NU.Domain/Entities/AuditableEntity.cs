using System.ComponentModel.DataAnnotations;
using StudentVoiceNU.Domain.Entities;
public class AuditableEntity:BaseEntity
{
    public DateTime createdAt { get; set; }=DateTime.Now;
    public DateTime updatedAt { get; set; }
}