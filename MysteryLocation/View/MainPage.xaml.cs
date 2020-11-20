﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MysteryLocation.Model;
using MysteryLocation.View;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MysteryLocation
{
    public partial class MainPage : ContentPage
    {
        User user;
        public MainPage(User user)
        {
            InitializeComponent();
            // Creates a new user, reads from cookie file if it exists, else update User variables during execution.
            //user = new User(null, null, null, false, null);
            //user.ReadUser();
            this.user = user;
            APIConnection api = new APIConnection(Content);
            defaultActivityIndicator.IsRunning = true;
            api.RefreshDataAsync();
            
            
           // api.deleteItem(106);
            //api.CreateNewPost();
           // Coordinate p1 = new Coordinate(55, 13);
           // Coordinate p2 = new Coordinate(55, 14);
           // p1.getDistance(p2);
            //defaultActivityIndicator.IsRunning = false;
            GPSUpdater gps = new GPSUpdater(currentGPS);
            gps.startTimer(30);
        }

        async void FeedButtonClicked(object sender, EventArgs args)
        {
            Console.WriteLine("Feed button works.");
            
        }

        async void SettingsButtonClicked(object sender, EventArgs args)
        {
            Console.WriteLine("Settings button works.");
        }

        async void MarkedButtonClicked(object sender, EventArgs args)
        {
            Console.WriteLine("Marked button works.");
        }

        async void UnlockedButtonClicked(object sender, EventArgs args)
        {
            Console.WriteLine("Unlocked button works.");
        }

        async void CreateButtonClicked(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new PublishPage(user), false);
            Console.WriteLine("Createbutton works.");
        }

        async void getLocation(object sender, EventArgs args)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Content.Text = $"{location.Latitude}, {location.Longitude}";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

    }

}





