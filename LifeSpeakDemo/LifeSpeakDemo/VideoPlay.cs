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
        StackLayout header_layout;
        Image back;
        public VideoPlay(Entry entrydata)
        {
            back = new Image { Margin = 5, Source = "back.png", VerticalOptions = LayoutOptions.Start, HeightRequest = 50, WidthRequest = 50 };

           var backtap = new TapGestureRecognizer();
            backtap.Tapped += Backtap_Tapped;
            back.GestureRecognizers.Add(backtap);
            header_layout = new StackLayout
            {
                HeightRequest = 50,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    back,new Label{ Text="Video Playing",FontSize=18,VerticalOptions=LayoutOptions.Center,HorizontalOptions=LayoutOptions.CenterAndExpand}
                }
            };
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
                    header_layout,vp,title
                }
            };

        }

        private void Backtap_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}