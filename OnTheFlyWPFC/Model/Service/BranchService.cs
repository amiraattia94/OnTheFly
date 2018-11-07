using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    public class BranchService {

        async public Task<bool> AddBranch(string branchname, string cityCode, string branchAddress, bool branchstatus) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.CompanyBranchTBLs.Add(new CompanyBranchTBL() {
                        branch_name = branchname,
                        cityID = cityCode,
                        address = branchAddress,
                        status = branchstatus

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }
    }
}
