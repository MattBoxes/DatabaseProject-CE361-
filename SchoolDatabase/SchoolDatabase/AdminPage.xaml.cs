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

        public AdminPage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "SchoolDB.db");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Course>();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }


        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            var add = conn.Insert(new Course(Course_Name.Text, Course_ID.Text));
        }

        private void ShowCoursesButton_Click(object sender, RoutedEventArgs e)
        {
            var query = conn.Table<Course>();
            string result = String.Empty;
            foreach (var item in query)
            {
                result = "{Course.Id} : {Course.Name}";
                Listv.Items.Add(result);
            }
        }

        private void btnLogin(object sender, RoutedEventArgs e)
        {

        }
    }
}
