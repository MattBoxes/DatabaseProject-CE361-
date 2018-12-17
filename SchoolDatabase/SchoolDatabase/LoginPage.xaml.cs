using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLitePCL;
using Windows.Storage;
using DataAccessLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SchoolDatabase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(SelectPositionComboBox.SelectedIndex == 0)
            {
                List<string> admin_ids = DataAccess.GetData("Admin", "Admin_ID");
                List<string> admin_passwords = DataAccess.GetData("Admin", "Password");

                int countid = 0, countpw = 0;
                foreach (string id in admin_ids)
                {
                    countid++;
                    if (UserIDTextBox.Text == id)
                    {
                        countpw = 0;
                        foreach (string pw in admin_passwords)
                        {
                            countpw++;
                            if (countpw == countid)
                            {
                                if (PasswordTextBox.Text == pw)
                                    this.Frame.Navigate(typeof(AdminPage), id);
                            }
                        }
                    }  
                }
                
            }
            else if(SelectPositionComboBox.SelectedIndex == 1)
            {
                List<string> prof_ids = DataAccess.GetData("Professor", "Professor_ID");
                List<string> prof_passwords = DataAccess.GetData("Professor", "Password");

                int countid = 0, countpw = 0;
                foreach (string id in prof_ids)
                {
                    countid++;
                    if (UserIDTextBox.Text == id)
                    {
                        countpw = 0;
                        foreach (string pw in prof_passwords)
                        {
                            countpw++;
                            if (countpw == countid)
                            {
                                if (PasswordTextBox.Text == pw)
                                    this.Frame.Navigate(typeof(ProfessorPage), id);
                            }
                        }
                    }
                }
                
            }
            else if(SelectPositionComboBox.SelectedIndex == 2)
            {
                List<string> student_ids = DataAccess.GetData("Student", "Student_ID");
                List<string> student_passwords = DataAccess.GetData("Student", "Password");

                int countid = 0, countpw = 0;
                foreach (string id in student_ids)
                {
                    countid++;
                    if (UserIDTextBox.Text == id)
                    {
                        countpw = 0;
                        foreach (string pw in student_passwords)
                        {
                            countpw++;
                            if (countpw == countid)
                            {
                                if (PasswordTextBox.Text == pw)
                                    this.Frame.Navigate(typeof(StudentPage), id);
                            }
                        }
                    }
                }
                
            }
            else
            {
                this.Frame.Navigate(typeof(LoginPage));
            }
        }

        //private void AddData(object sender, RoutedEventArgs e)
        //{
        //    DataAccess.AddData(Input_Box.Text);

        //    Output.ItemsSource = DataAccess.GetData();
        //}
    }
}
