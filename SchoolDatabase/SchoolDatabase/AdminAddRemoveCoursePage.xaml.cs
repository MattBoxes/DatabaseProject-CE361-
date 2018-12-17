using DataAccessLibrary;
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
using DataAccessLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SchoolDatabase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminAddRemoveCoursePage : Page
    {
        Admin adminInUse;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string param_id = (string)e.Parameter;
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

        public AdminAddRemoveCoursePage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

        private void RemoveCourseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            adminInUse.AddCourse(CourseIDTextBox.Text, CourseNameTextBox.Text);
        }

        private void DisplayCoursesButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> cList = new List<string>();
            cList = adminInUse.ViewListOfCourses();
            RemoveCourseListView.ItemsSource = cList;
        }
    }
}
