using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel
{
    class CategoryViewModel
    {
        CategoryService categoryService;
        public ObservableCollection<CategoryDTO> allCategories { get; set; }
        public CategoryDTO categories { get; set; }
        public CategoryViewModel()
        {
            categoryService = new CategoryService();
            allCategories = new ObservableCollection<CategoryDTO>();
            categories = new CategoryDTO();

            GetAllCategories();
        }

        async public Task<bool> AddCategory(string name) {
            return await categoryService.AddCategory(name);
        }

        async public Task<bool> EditCategoryByID(int categoryID, string name) {
            return await categoryService.EditCategoryByID(categoryID, name);
        }

        async public Task<bool> DeleteCategoryByID(int categoryID) {
            return await categoryService.DeleteCategoryByID(categoryID);
        }

        async public void GetAllCategories()
        {
            allCategories = await categoryService.GetAllCategory();
        }

        async public void GetCategoryByID(int categoryID) {
            categories = await categoryService.GetCategoryByID(categoryID);
        }

        async public void GetCategoryByName(string categoryName) {
            allCategories = await categoryService.GetCategoryByName(categoryName);
        }


    }
}
