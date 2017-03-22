using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

namespace NetStatus
{
    public class App:Application
    {
        public App()
        {
            MainPage = CrossConnectivity.Current.IsConnected ? (Page) new NetworkViewPage() : new NoNetworkPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
        }

        private void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            Type currentPage = this.MainPage.GetType();

            if(e.IsConnected&&currentPage!=typeof(NetworkViewPage))
                this.MainPage= new NetworkViewPage();
            else if(!e.IsConnected&& currentPage!=typeof(NoNetworkPage))
                this.MainPage= new NoNetworkPage();
        }

        protected override void OnSleep()
        {
           
        }

        protected override void OnResume()
        {
             
        }
        
    }
}
