using Xamarin.Forms;

namespace Cuckoo.Models
{
    public class ListItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CourseTemplate { get; set; }
        public DataTemplate GroupTemplate { get; set; }
        public DataTemplate EmptyTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is CourseItem)
            {
                return CourseTemplate;
            }
            else if (item is GroupItem)
            {
                return GroupTemplate;
            }
            else return EmptyTemplate;
        }
    }
}
