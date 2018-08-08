using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LifeSpeakDemo
{
	public class ListViewCell : ViewCell
	{
		public ListViewCell ()
		{
            var image = new Image();
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();
            Label title = new Label();


            //set bindings
            title.SetBinding(Label.TextProperty, "Title");

            image.SetBinding(Image.SourceProperty, "Group.Thumbnail.Url");

            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#eee");
            horizontalLayout.Orientation = StackOrientation.Horizontal;

            title.TextColor = Color.FromHex("#f35e20");


            //add views to the view hierarchy
            horizontalLayout.Children.Add(image);
            horizontalLayout.Children.Add(title);

            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
	}
}