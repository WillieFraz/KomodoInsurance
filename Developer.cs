namespace Developers;


public class Developer
{
    public Developer(string fullName, bool pluralslightAccess, int id)
    {
        Id = id;
        FullName = fullName;
        PluralslightAccess = pluralslightAccess;   
    }

    public string FullName { get; set; }
    public bool PluralslightAccess { get; set; }
    public int Id { get; set; }
    
}

