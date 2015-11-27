using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using CateringPXL.Droid;
using CateringPXL;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ScrollView), typeof(CustomScrollViewRenderer))]
namespace CateringPXL.Droid
{
    class CustomScrollViewRenderer : ScrollViewRenderer
    {
        float StartX, StartY;
        int IsHorizontal = -1;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (((Xamarin.Forms.ScrollView)e.NewElement).Orientation == ScrollOrientation.Horizontal) IsHorizontal = 1;

        }
        public override bool DispatchTouchEvent(Android.Views.MotionEvent e)
        {

            switch (e.Action)
            {
                case MotionEventActions.Down:
                    StartX = e.RawX;
                    StartY = e.RawY;
                    this.Parent.RequestDisallowInterceptTouchEvent(true);
                    break;
                case MotionEventActions.Move:
                    if (IsHorizontal * Math.Abs(StartX - e.RawX) < IsHorizontal * Math.Abs(StartY - e.RawY))
                        this.Parent.RequestDisallowInterceptTouchEvent(false);
                    break;
                case MotionEventActions.Up:
                    this.Parent.RequestDisallowInterceptTouchEvent(false);
                    break;
            }

            return base.DispatchTouchEvent(e);
        }
    }
}