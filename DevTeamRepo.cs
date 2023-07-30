namespace Developers;

public class DeveloperTeamRepository
{
    private readonly List<DeveloperTeam> _developerTeamList = new List<DeveloperTeam>();

    // Create
    public bool AddNewTeam(DeveloperTeam devTeam)
    {
        foreach (DeveloperTeam team in _developerTeamList)
        {
            if (devTeam.Id == team.Id)
            {
                System.Console.WriteLine("Failed adding new team, due to Id already existing in list.");
                return false;
            }
        }
        _developerTeamList.Add(devTeam);
        return true;
    }

    // Read
    public List<DeveloperTeam> GetList()
    {
        return new List<DeveloperTeam>(_developerTeamList);
    }

    public DeveloperTeam? GetTeamById(int id)
    {
        foreach (DeveloperTeam team in _developerTeamList)
        {
            if (team.Id == id)
            {
                return team;
            }
        }
        return null;
    }

    // Update

    public bool UpdateList(int id, DeveloperTeam newTeam)
    {
        DeveloperTeam? oldTeam = GetTeamById(id);
        if (oldTeam == null)
        {
            return false;
        }

        int index = _developerTeamList.IndexOf(oldTeam);
        _developerTeamList[index] = newTeam;
        return true;
    }

    // Delete 

    public bool DeleteTeamById(int id)
    {
        DeveloperTeam? targetTeam = GetTeamById(id);
        if (targetTeam == null)
        {
            return false;
        }

        bool deleteResult = _developerTeamList.Remove(targetTeam);
        return deleteResult;
    }
}