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

        /// <summary>
        /// Navigates to AdminPage when the Back button is clicked.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage), adminInUse.Id.ToString());
        }

        private async void AddUserButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (SelectUserTypeToAddComboBox.SelectedIndex == 0 || SelectUserTypeToAddComboBox.SelectedIndex == 1)
            {
                if (FirstNameTextBox.Text != "")
                {
                    if (LastNameTextBox.Text != "")
                    {
                        if (SelectUserTypeToAddComboBox.SelectedIndex == 0)
                        {
                            if (UserIDTextBox.Text != "")
                            {
                                if (Int32.Parse(UserIDTextBox.Text) / 10000 == 8 && Int32.Parse(UserIDTextBox.Text) / 80000 == 1)
                                {
                                    adminInUse.AddProfessor(FirstNameTextBox.Text, LastNameTextBox.Text, Int32.Parse(UserIDTextBox.Text), "password");
                                }
                                else
                                {
                                    ContentDialog InvalidEntry = new ContentDialog
                                    {
                                        Title = "Enter a valid professor user ID. (5 digits starting with the number 8)",
                                        CloseButtonText = "OK"
                                    };
                                    ContentDialogResult result = await InvalidEntry.ShowAsync();
                                }
                            }
                            else
                            {
                                ContentDialog InvalidEntry = new ContentDialog
                                {
                                    Title = "Enter a valid professor user ID. (5 digits starting with the number 8)",
                                    CloseButtonText = "OK"
                                };
                                ContentDialogResult result = await InvalidEntry.ShowAsync();
                            }
                        }
                        else if (SelectUserTypeToAddComboBox.SelectedIndex == 1)
                        {
                            if (UserIDTextBox.Text != "")
                            {
                                if (Int32.Parse(UserIDTextBox.Text) / 10000 == 7 && Int32.Parse(UserIDTextBox.Text) / 70000 == 1)
                                {
                                    adminInUse.AddStudent(FirstNameTextBox.Text, LastNameTextBox.Text, Int32.Parse(UserIDTextBox.Text), "password");
                                }
                                else
                                {
                                    ContentDialog InvalidEntry = new ContentDialog
                                    {
                                        Title = "Enter a valid student user ID. (5 digits starting with the number 7)",
                                        CloseButtonText = "OK"
                                    };
                                    ContentDialogResult result = await InvalidEntry.ShowAsync();
                                }
                            }
                            else
                            {
                                ContentDialog InvalidEntry = new ContentDialog
                                {
                                    Title = "Enter a valid student user ID. (5 digits starting with the number 7)",
                                    CloseButtonText = "OK"
                                };
                                ContentDialogResult result = await InvalidEntry.ShowAsync();
                            }
                        }
                    }
                    else
                    {
                        ContentDialog InvalidEntry = new ContentDialog
                        {
                            Title = "Enter a valid last name.",
                            CloseButtonText = "OK"
                        };
                        ContentDialogResult result = await InvalidEntry.ShowAsync();
                    }
                }
                else
                {
                    ContentDialog InvalidEntry = new ContentDialog
                    {
                        Title = "Enter a valid first name.",
                        CloseButtonText = "OK"
                    };
                    ContentDialogResult result = await InvalidEntry.ShowAsync();
                }
            }
            else
            {
                ContentDialog InvalidEntry = new ContentDialog
                {
                    Title = "Select type of user to add.",
                    CloseButtonText = "OK"
                };
                ContentDialogResult result = await InvalidEntry.ShowAsync();
            }
        }

        private async void DisplayUsersButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (SelectUserTypeToRemoveComboBox.SelectedIndex == 0)
            {
                List<People> pList = adminInUse.GetListOfProfessors();
                RemoveUserListView.ItemsSource = pList;
            }
            else if (SelectUserTypeToRemoveComboBox.SelectedIndex == 1)
            {
                List<People> sList= adminInUse.GetListOfStudents();
                RemoveUserListView.ItemsSource = sList;
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

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            People ppl = (People) RemoveUserListView.SelectedItem;
            if ((ppl.Id / 10000) == 8)
                adminInUse.RemoveProfessor(ppl.Id);
            else
                adminInUse.RemoveStudent(ppl.Id);
        }
    }
}
