using Octane.Xamarin.Forms.VideoPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LifeSpeakDemo
{
	public class VideoPlay : ContentPage
	{
        VideoPlayer vp;
        Label title;
        
        Image back;
        public VideoPlay(Entry entrydata)
        {
            back = new Image { Margin = 5, Source = "back.png", VerticalOptions = LayoutOptions.Start, HeightRequest = 50, WidthRequest = 50 };
            var backtap = new TapGestureRecognizer();
            backtap.Tapped += Backtap_Tapped;
            back.GestureRecognizers.Add(backtap);
            vp = new VideoPlayer
            {
                WidthRequest = 320,
                HeightRequest = 180,
                Source = entrydata.Group.Content.Url

            };
            title = new Label
            {
                Text = entrydata.Title
            };
            
            Content = new StackLayout
            {
                Children = {
                    back,vp,title
                }
            };

        }

        private void Backtap_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}