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
    public class NetworkViewPage:ContentPage
    {
        private Label ConnectionDetails = new Label();
        public NetworkViewPage()
        {
            this.Padding= new Thickness(20,20,20,20);

            var panel = new StackLayout
            {
                Spacing=15
            };

           panel.Children.Add(ConnectionDetails);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();
            if(CrossConnectivity.Current!=null)
                CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
        }

        private void UpdateNetworkInfo(object sender, ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                ConnectionDetails.Text = connectionType.ToString();
            }
            
        }
    }
}
