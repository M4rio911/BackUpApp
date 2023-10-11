using BackUpApp.Interfaces;
using BackUpApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpApp.CLI
{
    public class App
    {
        private readonly IGitHubService _gitHubService;
        public App(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async void Start()
        {
            while (true)
            {
                Console.WriteLine("______________");
                Console.WriteLine("BACKUP PROGRAM");
                Console.WriteLine("______________\n\n");

                Console.WriteLine("[1] - List All Backups");
                Console.WriteLine("[2] - Create Local Backup From Remote Repository ");
                Console.WriteLine("[3] - Recreate Remote Repository From Local Backup");
                Console.WriteLine("[0] - Exit\n");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var response = await _gitHubService.GetListOfRepositories();
                        break; 
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                    break;
                }

               
            }
        }
    }
}
