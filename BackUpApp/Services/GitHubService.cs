using BackUpApp.Interfaces;
using BackUpApp.Interfaces.Repositories;
using BackUpApp.Models.Dto;
using BackUpApp.Models.Dto.ListOfPrivateRepositories;
using System;
using System.Threading.Tasks;

namespace BackUpApp.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly IGitHubRepository _gitHubRepository;
        public GitHubService(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }
        public async Task<ListOfPrivateRepositoriesDto> GetListOfRepositories()
        {
            var listOfRepositories = await _gitHubRepository.GetListOfPrivateRepositories(new ListOfPrivateRepositoriesParameters());

            foreach (var repository in listOfRepositories.PrivateRepositories)
            {
                Console.WriteLine(repository.Name);
            }

            return listOfRepositories;
        }
    }
}
