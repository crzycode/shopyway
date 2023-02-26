using shopyway.Function;

namespace shopyway.Interface
{
    public interface IUser_Register
    {
        dynamic User_Registeration(User_Register_Function user);
        dynamic User_Login(Login_User login);
        void savechanges();

    }
}
