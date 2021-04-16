using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Student o = new Student();
            Student ooo = new Student();
            ooo.Name = "Samantha";
            ooo.Surname = "Smith";
            ooo.StudentNo = "123";

            // reach out name, type etc. of every property in the list
            o.GetType().GetProperties().ToList().ForEach(p =>
            {
                //   MessageBox.Show("Property Name : " + p.Name + " - Property Type : " + p.PropertyType);
            });

            // reach out methods of the list
            o.GetType().GetMethods().ToList().ForEach(p =>
            {
                //   MessageBox.Show("Method Name : " + p.Name );
            });

            // invoke methods of the list
            o.GetType().GetMethods().ToList().ForEach(m =>
            {
                if (m.Name == "CalculateSalary")
                {
                    var Sonuc = m.Invoke(o, new object[] { 3, 5 });
                    //    MessageBox.Show(Sonuc.ToString());
                }
            });

            // set values to given properties in the list
            o.GetType().GetProperties().ToList().ForEach(p =>
            {
                if (p.Name == "StudentNo")
                    p.SetValue(o, "11040355");
                else if (p.Name == "Name")
                    p.SetValue(o, "David");
                else
                    p.SetValue(o, "Smith");
            });

            //   MessageBox.Show(o.Name + o.Surname + o.StudentNo);

            o.Operation(ooo);         
            o.Operation();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.Show();
        }
    }




    static class Operations
    {
        // importing a generic object data into another generic object in the sme type
        static public T Operation<T>(this T _object, T newObject) where T : class, new()
        {
            _object.GetType().GetProperties().ToList().ForEach(p =>
            {
                newObject.GetType().GetProperties().ToList().ForEach(p2 =>
                {
                    if (p.Name == p2.Name)
                    {
                        p.SetValue(_object, p2.GetValue(newObject));
                    }
                });
            });

            return _object;
        }

        // inserting data into a generic object
        static public T Operation<T>(this T _object) where T : class, new()
        {
            T newObject = new T();
            _object.GetType().GetProperties().ToList().ForEach(p =>
            {
                p.SetValue(newObject, "test");
            });

            return newObject;
        }
    }
}

