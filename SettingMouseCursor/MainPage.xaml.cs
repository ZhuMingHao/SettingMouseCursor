using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Extensions;
using Windows.Storage;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.Management.Deployment;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SettingMouseCursor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Mouse.SetCursor(this, CoreCursorType.Hand);


            StorageFolder currApp = Windows.Storage.ApplicationData.Current.LocalFolder;
            Debug.WriteLine(currApp.Path);

            // move up and get parent folder for all packages
            DirectoryInfo currAppFolder = Directory.GetParent(currApp.Path);

            DirectoryInfo pkgs = Directory.GetParent(currAppFolder.FullName);
            StorageFolder pkgFldr = await StorageFolder.GetFolderFromPathAsync(pkgs.FullName);

            var pkgDirs = await pkgFldr.GetFoldersAsync();

            Package UwpPkg = null;
            var PkgMgr = new PackageManager();

            foreach (StorageFolder dir in pkgDirs)
            {
                string folderName = dir.Name;

                var currPkg = PkgMgr.FindPackage(Package.Current.Id.FamilyName);

                //if ( == currPkg.DisplayName)
                //{
                //    // we found it
                //    UwpPkg = currPkg;
                //    break;
                //}
            }
        }



    }
}
