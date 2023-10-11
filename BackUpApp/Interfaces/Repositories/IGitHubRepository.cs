using BackUpApp.Models.Dto;
using BackUpApp.Models.Dto.ListOfPrivateRepositories;
using System.Threading.Tasks;

namespace BackUpApp.Interfaces.Repositories
{
    public interface IGitHubRepository
    {
        Task<ListOfPrivateRepositoriesDto> GetListOfPrivateRepositories(ListOfPrivateRepositoriesParameters parameters);
    }
}
