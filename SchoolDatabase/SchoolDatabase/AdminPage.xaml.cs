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
        string path;
        SQLite.Net.SQLiteConnection conn;
        Admin adminInUse = new Admin("Xavier", "Truong", 90000, "abc123");

        public AdminPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminAddRemoveCoursePage));
        }

        private void AddRemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminAddRemoveUserPage));
        }

        private void AddRemoveCoursesProfessorButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminAddRemoveCoursesProfessorPage));
        }
    }
}
