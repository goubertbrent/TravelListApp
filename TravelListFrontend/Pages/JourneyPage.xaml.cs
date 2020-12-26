using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelListFrontend.Models;
using TravelListFrontend.ViewModels;
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

namespace TravelListFrontend.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JourneyPage : Page
    {
        #region Properties
        public JourneyPageViewModel viewModel { get; set; }
        #endregion
        public JourneyPage()
        {
            this.InitializeComponent();
            viewModel = new JourneyPageViewModel();
            JourneyList.DataContext = new CollectionViewSource { Source = viewModel.Journeys };
        }

        private void newJourneyBtn_Click(object sender, RoutedEventArgs e)
        {
            Journey newJourney = new Journey() { Name = nameNewJourney.Text };
            viewModel.PostJourney(newJourney);
        }
    }
}
