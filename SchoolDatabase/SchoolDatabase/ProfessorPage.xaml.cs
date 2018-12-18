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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SchoolDatabase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfessorPage : Page
    {
        public ProfessorPage()
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
        /// Navigates to ProfessorChangeStudentGradeEnrollmentPage when the ChangeStudentsGradeEnrollment button is clicked.
        /// </summary>
        private void ChangeStudentsGradeEnrollmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProfessorChangeStudentGradeEnrollmentPage));
        }

        /// <summary>
        /// Navigates to ProfessorChangePasswordPage when the ChangePassword button is clicked.
        /// </summary>
        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProfessorChangePasswordPage));
        }
    }
}
