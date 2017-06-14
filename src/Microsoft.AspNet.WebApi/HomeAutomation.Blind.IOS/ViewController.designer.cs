// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace HomeAutomation.Blind.IOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDown { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnStop { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnUp { get; set; }

        [Action ("BtnDown_TouchDownInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDown_TouchDownInside (UIKit.UIButton sender);

        [Action ("BtnDown_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDown_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnDtop_TouchDownInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDtop_TouchDownInside (UIKit.UIButton sender);

        [Action ("BtnStop_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnStop_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnUp_TouchDownInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnUp_TouchDownInside (UIKit.UIButton sender);

        [Action ("BtnUp_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnUp_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDown != null) {
                btnDown.Dispose ();
                btnDown = null;
            }

            if (btnStop != null) {
                btnStop.Dispose ();
                btnStop = null;
            }

            if (btnUp != null) {
                btnUp.Dispose ();
                btnUp = null;
            }
        }
    }
}