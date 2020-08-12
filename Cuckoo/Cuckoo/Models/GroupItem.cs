namespace Cuckoo.Models
{
    public class GroupItem : IListItem
    {
        public string GroupName { get; set; }

        public GroupItem()
        {
            GroupName = string.Empty;
        }

        public GroupItem(string groupName)
        {
            this.GroupName = groupName;
        }
    }
}
