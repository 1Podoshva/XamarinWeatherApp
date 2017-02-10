// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WeatherIOS
{
    [Register ("ForecastTableViewCell")]
    partial class ForecastTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DayNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HumidityLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MainLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TempLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WindSpeedLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DayNameLabel != null) {
                DayNameLabel.Dispose ();
                DayNameLabel = null;
            }

            if (DescriptionLabel != null) {
                DescriptionLabel.Dispose ();
                DescriptionLabel = null;
            }

            if (HumidityLabel != null) {
                HumidityLabel.Dispose ();
                HumidityLabel = null;
            }

            if (MainLabel != null) {
                MainLabel.Dispose ();
                MainLabel = null;
            }

            if (TempLabel != null) {
                TempLabel.Dispose ();
                TempLabel = null;
            }

            if (WindSpeedLabel != null) {
                WindSpeedLabel.Dispose ();
                WindSpeedLabel = null;
            }
        }
    }
}