using System.Text.Json.Serialization;
using StudentVoiceNU.Domain.Entities;
public class Club: BaseEntity
{
    public string Name{get;set;}
    public string Email{get;set;}
    [JsonIgnore]
    public virtual List<Event>? Events{get;set;}=new();
}