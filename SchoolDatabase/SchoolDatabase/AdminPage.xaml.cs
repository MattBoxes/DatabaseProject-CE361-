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
using SQLite.Net.Attributes;
using DataAccessLibrary;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SchoolDatabase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        Admin adminInUse;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string param_id = (string) e.Parameter;
            List<string> admin_ids = DataAccess.GetData("Admin", "Admin_ID");
            List<string> admin_passwords = DataAccess.GetData("Admin", "Password");
            List<string> admin_lasts = DataAccess.GetData("Admin", "Last_Name");
            List<string> admin_firsts = DataAccess.GetData("Admin", "First_Name");

            int countid = 0;
            foreach (string id in admin_ids)
            {   
                if (param_id == id)
                {
                    adminInUse = new Admin(admin_firsts[countid], admin_lasts[countid], Int32.Parse(id), admin_passwords[countid]);                   
                    break;
                }
                countid++;
            }
        }

        public AdminPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Navigates to LoginPage when the Back button is clicked.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        /// <summary>
        /// Navigates to AdminAddRemoveCoursePage when the AddCourse button is clicked.
        /// </summary>
        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminAddRemoveCoursePage), adminInUse.Id.ToString());
        }

        /// <summary>
        /// Navigates to AdminAddRemoveUserPage when the AddRemoveUser button is clicked.
        /// </summary>
        private void AddRemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminAddRemoveUserPage), adminInUse.Id.ToString());
        }

       

        private void DisplayCoursesButton_Click(object sender, RoutedEventArgs e)
        {
            List<Course> cList = new List<Course>();
            cList = adminInUse.GetListOfCourses();
            DisplayCoursesListView.ItemsSource = cList;
        }

        private async void DisplayUsersButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectUserTypeToDisplayComboBox.SelectedIndex == 0)
            {
                List<People> pList = adminInUse.GetListOfProfessors();
                DisplayUsersListView.ItemsSource = pList;
            }
            else if (SelectUserTypeToDisplayComboBox.SelectedIndex == 1)
            {
                List<People> sList = adminInUse.GetListOfStudents();
                DisplayUsersListView.ItemsSource = sList;
            }
            else
            {
                ContentDialog InvalidEntry = new ContentDialog
                {
                    Title = "Select type of user to display.",
                    CloseButtonText = "OK"
                };
                ContentDialogResult result = await InvalidEntry.ShowAsync();
            }
        }

        
    }
}
