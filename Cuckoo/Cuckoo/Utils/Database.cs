using Cuckoo.Services;

namespace Cuckoo.Utils
{
    public class Database
    {
        static UserDatabase userDatabase;

        static CourseDatabase courseDatabase;
        public static UserDatabase UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabase();
                }
                return userDatabase;
            }
        }

        public static CourseDatabase CourseDatabase
        {
            get
            {
                if (courseDatabase == null)
                {
                    courseDatabase = new CourseDatabase();
                }
                return courseDatabase;
            }
        }

    }
}
