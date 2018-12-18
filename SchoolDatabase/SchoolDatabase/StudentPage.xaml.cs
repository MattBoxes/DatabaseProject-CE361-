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
    public sealed partial class StudentPage : Page
    {

        Student studentInUse;

        public StudentPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
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

        /// <summary>
        /// Navigates to LoginPage when the Back button is clicked.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        /// <summary>
        /// Navigates to StudentEnrollInClassPage when the EnrollInCourse button is clicked.
        /// </summary>
        private void EnrollInCourseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudentEnrollInClassPage));
        }

        /// <summary>
        /// Navigates to StudentChangePasswordPage when the ChangePassword button is clicked.
        /// </summary>
        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudentChangePasswordPage));
        }

        private void DisplayYourInformationButton_Click(object sender, RoutedEventArgs e)
        {
            UserFirstNameTextBlock.Text = studentInUse.FirstName;
            UserLastNameTextBlock.Text = studentInUse.LastName;
            UserUserIDTextBlock.Text = (studentInUse.Id).ToString();

            List<Course> cList = studentInUse.GetCourses();
            List<Grade> gList = studentInUse.GetGrades();
            List<CourseAndGrade> cgList = new List<CourseAndGrade>();
            for (int i = 0; i < cList.Count; i++)
            {
                cgList.Add(new CourseAndGrade(cList[i].Name, gList[i].GradePoint));
            }
            DisplayYourInformationListView.ItemsSource = cgList;

        }

      
    }
}
