using System.ComponentModel.DataAnnotations;

namespace UnictiveTest.Models
{
    public class User
    {
        [Key]
        public int fID { get; set; }
        public string fName { get; set; }

        public ICollection<UserHobby> UserHobbies { get; set; }
    }

    public class Hobby
    {
        [Key]
        public int fID { get; set; }
        public string fHobby { get; set; }

        public ICollection<UserHobby> UserHobbies { get; set; }
    }

    public class UserHobby
    {
        [Key]
        public int fID { get; set; }
        public int fUserID { get; set; }
        public User User { get; set; }
        public int fHobbyID { get; set; }
        public Hobby Hobby { get; set; }
    }

    public class UserRead
    {
        [Key]
        public int fID { get; set; }
        public string fName { get; set; }
        public List<String> fHobbies { get; set; }
    }

    public class UserCreate
    {
        public string fName { get; set; }
        public List<int> fHobbyID { get; set; }
    }
}
