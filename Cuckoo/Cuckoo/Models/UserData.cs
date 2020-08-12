using SQLite;

namespace Cuckoo.Models
{
    public class UserData
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string SchoolId { get; set; }
        public string Password { get; set; }
        public string SchoolName { get; set; }
        public string RemoteApiHost { get; set; }
    }
}
