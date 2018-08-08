using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace LifeSpeakDemo
{
	public class VideoList : ContentPage
	{
        ListView lv;
        public List<Entry> getFeed()
        {
            Feed data;
            List<Entry> entrydata;
            XmlSerializer xmls = new XmlSerializer(typeof(Feed));
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XMLFeedData");
            using (var streamReader = new StreamReader(fileName))
            {
                string Xmldata = streamReader.ReadToEnd();
                data = (Feed)xmls.Deserialize(streamReader);
                entrydata = data.Entry;
            }

            return entrydata;

        }
        public VideoList()
        {
            
            lv = new ListView { RowHeight=40,ItemTemplate = new DataTemplate(typeof(ListViewCell)),ItemsSource = getFeed() };
            lv.ItemSelected += async (sender, e) => {
                if (e.SelectedItem != null)
                {
                    var selecteditem = (Entry)e.SelectedItem;
                    var videoPage = new VideoPlay(selecteditem); // so the new page shows correct data
                    await Navigation.PushModalAsync(videoPage);
                }
            };
            Content = new StackLayout
            {
                
                Children = {
                lv
                }
            };
        }
    }
}