using System.ComponentModel.DataAnnotations;

namespace shopyway.Model
{
    public class User
    {

        [Key]
        public int User_id { get; set; }
        public string User_Fullname { get; set; }
        public long User_Mobilenumber { get; set; }
        public string User_Email { get; set; } = "No Email";
        public string User_Password { get; set; }

        public int User_Pincode { get; set; } = 0;
        public string User_Address { get; set; } = "No Address";
        public string User_City { get; set; } = "No City";
        public string User_State { get; set; } = "No State";

        public DateTime User_Sinceactive { get; set; } = DateTime.Now;
    }
}
