using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OnTheFlyWPFC.ViewModel {
    public class BranchViewModel {
        BranchService _branchService;

        public BranchViewModel() {
            _branchService = new BranchService();
        }

        async public Task<bool> AddBranch(string branchname, string cityCode, string branchAddress, bool branchstatus) {
            return await _branchService.AddBranch(branchname, cityCode, branchAddress, branchstatus);
        }
    }
}
