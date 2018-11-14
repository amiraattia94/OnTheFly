using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OnTheFlyWPFC.ViewModel {
    public class BranchViewModel {
        BranchService _branchService;
        public ObservableCollection<BranchDTO> ViewBranch { get; set; }
        public BranchDTO EditBranch { get; set; }

        public BranchViewModel() {
            _branchService = new BranchService();
            ViewBranch = new ObservableCollection<BranchDTO>();
            EditBranch = new BranchDTO();
            
            GetAllBranches();
        }

        async public Task<bool> AddBranch(string branchname, string cityCode, string branchAddress, bool branchstatus) {
            return await _branchService.AddBranch(branchname, cityCode, branchAddress, branchstatus);
        }

        async public Task<bool> EditBranchByID(int branchID, string branchname, string cityCode, string branchAddress, bool branchstatus) {
            return await _branchService.EditBranchByID(branchID, branchname, cityCode, branchAddress, branchstatus);
        }

        async public Task<bool> DeleteBranchByID(int branchID) {
            return await _branchService.DeleteBranchByID(branchID);
        }
        
        async public void GetAllBranches() {
            ViewBranch = await _branchService.GetAllBranch();
        }

        async public void GetBranchByCity(string city) {
            ViewBranch = await _branchService.GetBranchByCity(city);
        }

        async public void GetBranchByState(bool branchState) {
            ViewBranch = await _branchService.GetBranchByState(branchState);
        }

        async public void GetBranchByID(int BranchID) {

            EditBranch = await _branchService.GetBranchByID(BranchID);
        }

        
    }
}
