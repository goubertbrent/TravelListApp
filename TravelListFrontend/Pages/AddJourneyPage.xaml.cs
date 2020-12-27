using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelListFrontend.DTO;
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
    public sealed partial class AddJourneyPage : Page
    {
        public JourneyPageViewModel viewModel { get; set; }
        public AddJourneyPage()
        {
            this.InitializeComponent();
            viewModel = new JourneyPageViewModel();
        }

        private void newJourneyBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = startDateJourney.Date.Value.DateTime;
            JourneyDTO newJourney = new JourneyDTO() { Name = nameNewJourney.Text, StartDay = startDate.Day, startMonth = startDate.Month, startYear = startDate.Year };
            viewModel.PostJourney(newJourney);
            nameNewJourney.Text = "";
            SuccesfullAddedTxt.Text = startDateJourney.Date.Value.DateTime.ToString();
            startDateJourney.Date = null;
            SuccesfullAddedTxt.Visibility = Visibility.Visible;
        }
    }
}
