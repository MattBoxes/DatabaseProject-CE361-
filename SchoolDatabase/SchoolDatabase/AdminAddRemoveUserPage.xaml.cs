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
    public sealed partial class AdminAddRemoveUserPage : Page
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

        public AdminAddRemoveUserPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

        private async void AddUserButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (SelectUserTypeToAddComboBox.SelectedIndex == 0)
                adminInUse.AddProfessor(FirstNameTextBox.Text, LastNameTextBox.Text, Int32.Parse(UserIDTextBox.Text), "password");
            else if (SelectUserTypeToAddComboBox.SelectedIndex == 1)
                adminInUse.AddStudent(FirstNameTextBox.Text, LastNameTextBox.Text, Int32.Parse(UserIDTextBox.Text), "password");
            else
            {
                ContentDialog InvalidEntry = new ContentDialog
                {
                    Title = "Select type of User to Add!",
                    CloseButtonText = "OK"
                };
                ContentDialogResult result = await InvalidEntry.ShowAsync();
            }
        }
    }
}
