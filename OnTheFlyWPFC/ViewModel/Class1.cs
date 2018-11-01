using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel
{
    class Class1
    {
        public ObservableCollection<Class2> ItemsTest { get; private set; }



        public Class1() {
            ItemsTest = new ObservableCollection<Class2>();

            for (int i = 0; i < 10; i++) {

                ItemsTest.Add(new Class2("اسم الطلبيةaaaaaaaaaaaaaaaa", "اسم الفرaaaaaaaaaaaaaaaaaaaaع", "الحاaaaaaaaaaaaaaaaaaaaaaaaaaaaلة"));
            }
        }


    }
}
