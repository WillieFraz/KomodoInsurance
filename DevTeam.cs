namespace Developers;
public class DeveloperTeam
{

    private List<Developer> _teamMembers = new List<Developer>();

    public string Name { get; set; }
    public int Id { get; set; }
    public List<Developer>? TeamMembers { get; }

    public DeveloperTeam(string name, int id)
    {
        Name = name;
        Id = id;
        
    }


    public bool AddNewDeveloper(Developer developer)
    {
        
        foreach (Developer member in _teamMembers)
        {
            if(member.Id == developer.Id)
            {
                return false;
            }
        }
        _teamMembers.Add(developer);
        return true;
    }

    public bool RemoveDeveloper(Developer developer)
    {

        foreach (Developer member in _teamMembers)
        {
            if(member.Id == developer.Id)
            {
                return false;
            }
        }
        _teamMembers.Remove(developer);
        return true;
    }
}