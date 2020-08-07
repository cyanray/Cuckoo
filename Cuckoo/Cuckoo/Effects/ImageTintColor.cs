using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cuckoo.Effects
{
    public class TintImage : RoutingEffect
    {
        public Color TintColor { get; private set; }
        public TintImage(Color color) : base($"MyCompany.{nameof(TintImage)}")
        {
            TintColor = color;
        }

    }
}
