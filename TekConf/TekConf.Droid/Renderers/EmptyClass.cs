using System;
using Xamarin.Forms;
using TekConf.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Graphics;


[assembly: ExportRenderer (typeof(Label), typeof(MyLabelRenderer))]
namespace TekConf.Droid
{
	public class MyLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);
			var label = (TextView)Control; // for example
			Typeface font = Typeface.CreateFromAsset (Context.Assets, "OpenSans-Light.ttf");
			label.Typeface = font;
		}
	}
}