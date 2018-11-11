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
                List<UserDTO> result = con.userTBLs.Select(s => new UserDTO()
                {
                    username = s.user_name,
                    password = s.password
                }).ToList();

                return result;
            }
        }
    }
}
