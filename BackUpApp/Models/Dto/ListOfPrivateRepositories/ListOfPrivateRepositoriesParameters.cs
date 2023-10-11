using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpApp.Models.Dto.ListOfPrivateRepositories
{
    public class ListOfPrivateRepositoriesParameters
    {
        //public string UserId { get; set; } = ""
        public string AuthToken { get; set; } = "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";

        public ListOfPrivateRepositoriesParameters(string authToken)
        {
            //UserId = userId;
            AuthToken = authToken;
        }
        public ListOfPrivateRepositoriesParameters()
        {
            
        }
    }
}
