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

        public CategoryViewModel() {
            categoryService = new CategoryService();
            allCategories = new ObservableCollection<CategoryDTO>();

            GetAllCategories();
        }


        async public void GetAllCategories() {
            allCategories = await categoryService.GetAllCategory();
        }

    }
}
