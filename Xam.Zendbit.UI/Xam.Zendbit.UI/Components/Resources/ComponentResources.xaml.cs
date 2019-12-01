using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components.Resources
{
    public enum ComponentResourcesEnum
    {
        ConverterResources,
        ViewResources,
        StyleResources
    }

    public partial class ComponentResources : ResourceDictionary
    {
        public static ComponentResources Self { get; } = new ComponentResources();

        public ComponentResources()
        {
            InitializeComponent();
        }

        public object GetResource(
            string key,
            ComponentResourcesEnum componentResourcesEnum
        )
        {
            var resource = MergedDictionaries.GetEnumerator();

            for (int i = 0; i < ((int)componentResourcesEnum) + 1; i++)
            {
                resource.MoveNext();
            }

            object value = null;
            resource.Current?.TryGetValue(key, out value);

            return value;
        }
    }
}
