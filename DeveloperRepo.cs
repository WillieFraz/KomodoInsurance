namespace Developers;

public class DeveloperRepository
{

    private List<Developer> _developerList = new List<Developer>();

    // Create
    public bool AddDeveloperToList(Developer dev) 
    {
        int startingCount = _developerList.Count;

        // Make sure there aren't any identical IDs
        for (int i = 0; i < _developerList.Count; i++)
        {
            if(_developerList[i].Id != dev.Id)
            {
                _developerList.Add(dev);
                continue;
            }
        }

        bool countIncreased = _developerList.Count > startingCount;
        return countIncreased;
    }

    // Read
    /* public List<int> GetId()
    {
        List<int> developerIdList = new List<int>();

        foreach (Developer teams in _developerList)
        {
            developerIdList.Add(teams.Id);
        }
        return developerIdList;
    }
*/
    public List<Developer> GetList ()
    {
        return new List<Developer>(_developerList);
    }

    public Developer? GetDeveloperById(int id)
    {
        foreach (Developer developer in _developerList)
        {
            if(developer.Id == id)
            {
                return developer;
            }
        }
        return null;
    }

    // Update

    public bool UpdateDeveloper(int id, Developer newDeveloper)
    {
        Developer? oldDeveloper = GetDeveloperById(id);
        if (oldDeveloper == null)
        {
            return false;
        }

        int index = _developerList.IndexOf(oldDeveloper);
        _developerList[index] = newDeveloper;
        return true;
    }

    // Delete

    public bool DeleteDeveloper (int id)
    {
        Developer? targetDeveloper = GetDeveloperById(id);
        if (targetDeveloper == null)
        {
            return false;
        }

        bool deleteResult = _developerList.Remove(targetDeveloper);
        return deleteResult;
    }
}


