using BackUpApp.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpApp.Interfaces
{
    public interface IGitHubService
    {
        Task<ListOfPrivateRepositoriesDto> GetListOfRepositories();
    }
}
