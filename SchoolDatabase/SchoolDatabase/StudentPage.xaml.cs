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

            int countid = 0;
            foreach (string id in student_ids)
            {
                if (param_id == id)
                {
                    studentInUse = new Student(student_firsts[countid], student_lasts[countid], Int32.Parse(id), student_passwords[countid]);
                    break;
                }
                countid++;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void EnrollInCourseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudentEnrollInClassPage));
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudentChangePasswordPage));
        }

        private void DisplayYourInformationButton_Click(object sender, RoutedEventArgs e)
        {
            UserFirstNameTextBlock.Text = studentInUse.FirstName;
            UserLastNameTextBlock.Text = studentInUse.LastName;
            UserUserIDTextBlock.Text = (studentInUse.Id).ToString();
        }
    }
}
