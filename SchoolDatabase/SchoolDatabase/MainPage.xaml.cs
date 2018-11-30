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

// TEE HEE

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SchoolDatabase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnCreateAcc_click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Folders.db");
            string sSQL = @"CREATE TABLE IF NOT EXISTS Folders 
                    (IDFolder Integer Primary Key Autoincrement NOT NULL 
                        , Foldername VARCHAR(200) 
                        , Path VARCHAR(255));";
            ISQLiteStatement cnStatement = dbConnection.Prepare(sSQL);
            cnStatement.Step();
        }
    }
}
