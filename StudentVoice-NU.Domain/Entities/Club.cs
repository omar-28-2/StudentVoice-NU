using StudentVoiceNU.Domain.Entities;

public class Club: BaseEntity
{
    public string Name{get;set;}
    public string Email{get;set;}
    public virtual List<Event>? Events{get;set;}=new();
}