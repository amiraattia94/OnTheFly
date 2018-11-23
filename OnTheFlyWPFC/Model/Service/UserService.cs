using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;

namespace OnTheFlyWPFC.Model.Service
{
    class UserService
    {
        async public Task<List<UserDTO>> GetUser()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                List<UserDTO> result = con.UserTBLs.Select(s => new UserDTO()
                {
                    username = s.user_name,
                    password = s.password
                }).ToList();

                return result;
            }
        }
        async public Task<Boolean> GetUserExists(string username, string password)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.UserTBLs.SingleOrDefault(u => u.user_name == username && u.password == password);
                if (result != null)
                {
                    username = result.user_name;
                    password = result.password;
                    return true;

                }
            }
            return false;

        }
               
        
    }
}
