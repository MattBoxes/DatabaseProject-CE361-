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
    public sealed partial class StudentEnrollInClassPage : Page
    {
        Student studentInUse;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                string param_id = (string)e.Parameter;
                List<string> student_ids = DataAccess.GetData("Student", "Student_ID");
                List<string> student_passwords = DataAccess.GetData("Student", "Password");
                List<string> student_lasts = DataAccess.GetData("Student", "Last_Name");
                List<string> student_firsts = DataAccess.GetData("Student", "First_Name");


                for (int i = 0; i < student_ids.Count; i++)
                {
                    if (param_id == student_ids[i])
                    {
                        studentInUse = new Student(student_firsts[i], student_lasts[i], Int32.Parse(param_id), student_passwords[i]);
                    }
                }
            }
            else
            {
                ContentDialog InvalidEntry = new ContentDialog
                {
                    Title = "Unable to load page",
                    CloseButtonText = "OK"
                };
                ContentDialogResult result = await InvalidEntry.ShowAsync();
                this.Frame.Navigate(typeof(LoginPage));
            }
        }

        public StudentEnrollInClassPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Navigates to StudentPage when the Back button is clicked.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudentPage), studentInUse.Id.ToString());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayAllCoursesButton_Click(object sender, RoutedEventArgs e)
        {
            List<Course> cList = new List<Course>();
            cList = studentInUse.GetListOfCourses();
            DisplayAllCoursesListView.ItemsSource = cList;
        }


        private void EnrollInCourseButton_Click(object sender, RoutedEventArgs e)
        {
            Course crs = (Course) DisplayAllCoursesListView.SelectedItem;
            studentInUse.EnrollinCourse(crs.Id);
        }
    }
}
