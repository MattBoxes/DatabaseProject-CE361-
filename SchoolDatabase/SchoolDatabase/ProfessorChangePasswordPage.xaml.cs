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
    public sealed partial class ProfessorChangePasswordPage : Page
    {

        Professor professorInUse;

        /// <summary>
        /// Takes the Professor ID from Professor Page and create a Professor object with that ID
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string param_id = (string)e.Parameter;
            List<string> prof_ids = DataAccess.GetData("Professor", "Professor_ID");
            List<string> prof_passwords = DataAccess.GetData("Professor", "Password");
            List<string> prof_lasts = DataAccess.GetData("Professor", "Last_Name");
            List<string> prof_firsts = DataAccess.GetData("Professor", "First_Name");

            int countid = 0;
            foreach (string id in prof_ids)
            {
                if (param_id == id)
                {
                    professorInUse = new Professor(prof_firsts[countid], prof_lasts[countid], Int32.Parse(id), prof_passwords[countid]);
                    break;
                }
                countid++;
            }
        }



        public ProfessorChangePasswordPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Navigates to ProfessorPage when the Back button is clicked.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProfessorPage), professorInUse.Id.ToString());
        }

        private async void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                professorInUse.ChangePassword(OldPasswordTextBox.Text, NewPasswordTextBox.Text);
            }
            catch (ArgumentException exc)
            {
                ContentDialog InvalidEntry = new ContentDialog
                {
                    Title = exc.Message,
                    CloseButtonText = "OK"
                };
                ContentDialogResult result = await InvalidEntry.ShowAsync();
            }
        }
    }
}
