using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service
{
    class CategoryService
    {
        async public Task<bool> AddCategory(string name) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.CategoriesTBLs.Add(new CategoriesTBL() {

                        
                        category_name = name,
                       

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<bool> EditCategoryByID(int categoryID, string name) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.CategoriesTBLs.SingleOrDefault(w => w.categoryID == categoryID);
                    if (Result != null) {

                        try {

                            Result.category_name = name;

                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch {

                        }
                        return false;
                    }
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<bool> DeleteCategoryByID(int categoryID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                    
                    var result = con.CategoriesTBLs.SingleOrDefault(w => w.categoryID  == categoryID);

                    if (result != null ) {

                        con.CategoriesTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch {

            }

            return false;

        }

        async public Task<ObservableCollection<CategoryDTO>> GetAllCategory() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                List<CategoryDTO> result = con.CategoriesTBLs.Select(s => new CategoryDTO() {
                    CategoryID = s.categoryID,
                    CategoryName = s.category_name
                }).ToList();

                return new ObservableCollection<CategoryDTO>(result);
            }
        }

        async public Task<CategoryDTO> GetCategoryByID(int categoryID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.CategoriesTBLs.SingleOrDefault(w => w.categoryID == categoryID);

                if (result != null) {
                    return new CategoryDTO() {
                        CategoryID = result.categoryID,
                        CategoryName = result.category_name
                    };
                };

                return new CategoryDTO() { };



            }
        }

        async public Task<ObservableCollection<CategoryDTO>> GetCategoryByName(string categoryName) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                var result = con.CategoriesTBLs.Where(w => w.category_name.StartsWith(categoryName)).Select(s => new CategoryDTO() {
                    CategoryID = s.categoryID,
                    CategoryName = s.category_name
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<CategoryDTO>(result);
                }
                else {
                    return new ObservableCollection<CategoryDTO>();
                }
            }

        }
    }
}
