using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cuckoo.Effects
{
    public class TintImageEffect : RoutingEffect
    {
        public const string GroupName = "Uint128";
        public const string Name = "TintImageEffect";

        public Color TintColor { get; set; }

        public TintImageEffect() : base($"{GroupName}.{Name}") { }
    }
}
