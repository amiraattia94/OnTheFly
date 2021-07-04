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
    }
}
