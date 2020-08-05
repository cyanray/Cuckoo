using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cuckoo.Controls;
using Cuckoo.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BetterFrame), typeof(DashedFrameRenderer))]
namespace Cuckoo.Droid.CustomRenderers
{
    public class DashedFrameRenderer : VisualElementRenderer<Frame>
    {
        public DashedFrameRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
        {
            base.OnElementChanged(e);

            var extFrame = e.NewElement as BetterFrame;

            var gd = new Android.Graphics.Drawables.GradientDrawable();

            gd.SetColor(extFrame.BackgroundColor.ToAndroid());

            gd.SetCornerRadius((float)extFrame.CornerRadius);

            if (extFrame.BorderStroke > 0)
            {
                // TODO: Supporting line border.
                // TODO：Supporting custom dashed line.
                gd.SetStroke(extFrame.BorderStroke, extFrame.BorderColor.ToAndroid(), 10f, 10f);
            }

            this.Background = gd;

        }
    }
}