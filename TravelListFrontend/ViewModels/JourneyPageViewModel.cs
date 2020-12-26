using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelListFrontend.Models;

namespace TravelListFrontend.ViewModels
{
    public class JourneyPageViewModel
    {
        #region Properties
        public ObservableCollection<Journey> Journeys { get; set; }
        #endregion

        #region Constructors
        public JourneyPageViewModel()
        {
            Journeys = new ObservableCollection<Journey>();
            LoadJourneysAsync();
        }
        #endregion

        #region Methods
        private async void LoadJourneysAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:59489/api/journey"));
            var journeys = JsonConvert.DeserializeObject<IList<Journey>>(json);

            foreach(Journey journey in journeys)
            {
                Journeys.Add(journey);
            }
        }
        #endregion

    }
}
