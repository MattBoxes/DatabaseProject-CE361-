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
using SQLitePCL;
using Windows.Storage;
using DataAccessLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SchoolDatabase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if(ChoosePosition.SelectedIndex == 0)
            {
                this.Frame.Navigate(typeof(AdminPage));
            }
            else if(ChoosePosition.SelectedIndex == 1)
            {
                this.Frame.Navigate(typeof(ProfessorPage));
            }
            else if(ChoosePosition.SelectedIndex == 2)
            {
                this.Frame.Navigate(typeof(StudentPage));
            }
            else
            {
                this.Frame.Navigate(typeof(LoginPage));
            }
        }

        //private void AddData(object sender, RoutedEventArgs e)
        //{
        //    DataAccess.AddData(Input_Box.Text);

        //    Output.ItemsSource = DataAccess.GetData();
        //}
    }
}
