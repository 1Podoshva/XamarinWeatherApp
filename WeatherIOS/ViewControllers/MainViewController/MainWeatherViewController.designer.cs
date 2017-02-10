// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WeatherIOS
{
    [Register ("MainWeatherViewController")]
    partial class MainWeatherViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView BgImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CityLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContentView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint ContentView_LayoutCenterY { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DayLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HumidityLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MainLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MonthLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TempLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WindLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActivityIndicator != null) {
                ActivityIndicator.Dispose ();
                ActivityIndicator = null;
            }

            if (BgImageView != null) {
                BgImageView.Dispose ();
                BgImageView = null;
            }

            if (CityLabel != null) {
                CityLabel.Dispose ();
                CityLabel = null;
            }

            if (ContentView != null) {
                ContentView.Dispose ();
                ContentView = null;
            }

            if (ContentView_LayoutCenterY != null) {
                ContentView_LayoutCenterY.Dispose ();
                ContentView_LayoutCenterY = null;
            }

            if (DayLabel != null) {
                DayLabel.Dispose ();
                DayLabel = null;
            }

            if (HumidityLabel != null) {
                HumidityLabel.Dispose ();
                HumidityLabel = null;
            }

            if (MainLabel != null) {
                MainLabel.Dispose ();
                MainLabel = null;
            }

            if (MonthLabel != null) {
                MonthLabel.Dispose ();
                MonthLabel = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (TempLabel != null) {
                TempLabel.Dispose ();
                TempLabel = null;
            }

            if (WindLabel != null) {
                WindLabel.Dispose ();
                WindLabel = null;
            }
        }
    }
}