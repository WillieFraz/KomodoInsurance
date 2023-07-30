using Developers;

  DeveloperRepository devRepo = new DeveloperRepository();
  DeveloperTeamRepository devTeamRepo = new DeveloperTeamRepository();
  int teamId = 0;
  int devId = 0;
  bool keepRunning = true;
    
    void DisplayMenu()
    {
        System.Console.WriteLine("Komodo Insurance Propgram: ");       
        System.Console.WriteLine("Option 1: List of Developers");
        System.Console.WriteLine("Option 2: Create Developer");
        System.Console.WriteLine("Option 3: Remove Developer");
        System.Console.WriteLine("Option 4: List of Teams");
        System.Console.WriteLine("Option 5: Create Team");
        System.Console.WriteLine("Option 6: Delete Team");
        System.Console.WriteLine("Option 7: Remove Developer from Team");
        System.Console.WriteLine("Option 8: Add Developer to Team");
        System.Console.WriteLine("Option 9: Developers who need Plural License");
        string choice = Console.ReadLine();
        Console.Clear();

        switch (choice)
        {
            case "1":
                ReadDeveloperDirectory(devRepo);
                PressAnyKeyToContinue();
                break;
            case "2":
                CreateDeveloper();
                break;
            case "3":
                DeleteDeveloper();
                break;
            case "4":
                ReadTeamDirectory(devTeamRepo);
                PressAnyKeyToContinue();
                break;
            case "5":
                CreateDveloperTeam();
                break;
            case "6":
                DeleteTeam();
                break;
            case "7":
                RemoveDeveloperFromTeam();
                break;
            case "8":
                AddDeveloperToTeam();
                break;
            case "9":
                ShowPluralslightDevs();
                PressAnyKeyToContinue();
                break;
            default:
                keepRunning = false;
                break;
        }
    }

        void CreateDeveloper()
        {
            Console.WriteLine("Developer's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Developer's access to Pluralsight (true/false):");
            bool access = bool.Parse(Console.ReadLine());

            devId += 1;

            Developer dev = new Developer(name, access, devId);
            devRepo.AddDeveloperToList(dev);
        }

        void CreateDveloperTeam()
        {
            Console.WriteLine("Team name:");
            string name = Console.ReadLine();

            teamId += 1;

            DeveloperTeam team = new DeveloperTeam(name, teamId);
            devTeamRepo.AddNewTeam(team);
        }

        void DeleteDeveloper()
        {
            ReadDeveloperDirectory(devRepo);

            Console.WriteLine("Enter Id of the Developer you want to delete:");
            int targetId = int.Parse(Console.ReadLine());

            List<DeveloperTeam> devTeamList = devTeamRepo.GetList();
            foreach (DeveloperTeam team in devTeamList)
            {
                foreach (Developer dev in team.TeamMembers.ToList())
                {
                    if (dev.Id == targetId)
                    {
                        team.RemoveDeveloper(dev);
                    }
                }
            }
            devRepo.DeleteDeveloper(targetId);
        }

        void DeleteTeam()
        {
            ReadTeamDirectory(devTeamRepo);

            Console.WriteLine("Enter the Id of Team you would like deleted.");
            int targetId = int.Parse(Console.ReadLine());
            devTeamRepo.DeleteTeamById(targetId);
        }

        void AddDeveloperToTeam()
        {
            ReadTeamDirectory(devTeamRepo);

            Console.WriteLine("Enter the Id of Team you want developer added to.");
            int targetTeamId = int.Parse(Console.ReadLine());
            DeveloperTeam targetTeam = devTeamRepo.GetTeamById(targetTeamId);

            ReadDeveloperDirectory(devRepo);

            Console.WriteLine("Enter the Id of Developer you want added to team.");
            int targetDevId = int.Parse(Console.ReadLine());
            Developer targetDev = devRepo.GetDeveloperById(targetDevId);

            bool isOnTeam = false;
            foreach (Developer dev in targetTeam.TeamMembers)
            {
                if (dev == targetDev)
                {
                    isOnTeam = true;
                    Console.WriteLine("That Developer is already on that team.");
                    PressAnyKeyToContinue();
                }
            }
            if (!isOnTeam)
            {
                targetTeam.AddNewDeveloper(targetDev);
            }
        }

        void RemoveDeveloperFromTeam()
        {
            ReadTeamDirectory(devTeamRepo);

            Console.WriteLine("Enter the Id of team you want to remove developer from:");
            int targetTeamId = int.Parse(Console.ReadLine());
            DeveloperTeam targetTeam = devTeamRepo.GetTeamById(targetTeamId);

            List<Developer> devList = targetTeam.TeamMembers;
            foreach (Developer dev in devList)
            {
                Console.WriteLine($"Name: {dev.FullName} Id: {dev.Id}");
            }

            Console.WriteLine("Enter the Id of developer you want removed:");
            int targetDevId = int.Parse(Console.ReadLine());
            Developer targetDev = devRepo.GetDeveloperById(targetDevId);

            targetTeam.RemoveDeveloper(targetDev);
        }

          static void ReadDeveloperDirectory(DeveloperRepository devRepo)
        {
            List<Developer> devList = devRepo.GetList();
            foreach (Developer dev in devList)
            {
                Console.WriteLine($"Name: {dev.FullName} Id: {dev.Id}");
            }
        }

        static void ReadTeamDirectory(DeveloperTeamRepository devTeamRepo)
        {
            List<DeveloperTeam> devTeamList = devTeamRepo.GetList();
            foreach (DeveloperTeam team in devTeamList)
            {
                Console.WriteLine($"Name: {team.Name} Id: {team.Id}");
            }
        }

        void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        void ShowPluralslightDevs()
        {
            List<Developer> devlist = devRepo.GetList();
            foreach (Developer dev in devlist)
            {
                if (dev.PluralslightAccess == false)
                {
                    Console.WriteLine($"Name: {dev.FullName} Id: {dev.Id}");
                }
            }
        }

        void SeedData()
        {
            Developer willie = new Developer("Willie", true, 32);
            devRepo.AddDeveloperToList(willie);
            DeveloperTeam sd171 = new DeveloperTeam("sd171", 1);
            devTeamRepo.AddNewTeam(sd171);
            sd171.AddNewDeveloper(willie);
        }
        
        SeedData();

        while (keepRunning)
        {
            Console.Clear();
            DisplayMenu();
        }