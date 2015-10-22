using System.Collections.Generic;

namespace Starscream.Web.Api.Responses.Admin
{
    public class AdminUsersListResponse 
    {
        public List<AdminUserResponse> AdminUsers { get; set; }

        public AdminUsersListResponse(List<AdminUserResponse> adminUsers)
        {
            AdminUsers = adminUsers;
        }
    }
}