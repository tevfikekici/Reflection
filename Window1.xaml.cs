using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Reflection
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Loaded += Window1_Loaded;
        }




        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            Student ooo = new Student();
            ooo.Name = "Samantha";
            ooo.Surname = "Smith";
            ooo.StudentNo = "123";

            Insert_New_BC_All_Brum_Tipo(ooo);
        }



        public void Insert_New_BC_All_Brum_Tipo(Student New_BC_All_Brum_Tipo)
        {

            // create database table instance below (as example used a list)
            Student_DB TableToSave = new Student_DB();


            // create type of entity
            Type Typ_Of_TYP = typeof(Student);
            PropertyInfo[] DataToSave = Typ_Of_TYP.GetProperties();


            // create type of database table
            Type Typ_Of_TBL = typeof(Student);
            PropertyInfo[] DbTable = Typ_Of_TBL.GetProperties();

            // getting items of entity type
            foreach (PropertyInfo item in DataToSave)
            {
                // loop into table members
                foreach (PropertyInfo item1 in DbTable)
                {
                    // loop into entity memberes
                    if (item1.Name == item.Name)
                    {
                        // catch matching memebrs
                        if (item.GetValue(New_BC_All_Brum_Tipo) != null)
                        {
                            // set data of mathcing members into table
                            item1.SetValue(TableToSave, item.GetValue(New_BC_All_Brum_Tipo));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }




        }
    }
}
