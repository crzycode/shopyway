using shopyway.Function;
using shopyway.Model;

namespace shopyway.Interface
{
    public interface IPartner
    {
        dynamic partner_Registeration(Partner_user p);
        dynamic partner_Login(Login_User p);
        dynamic check_site(string id);
        void savechanges();
    }
}
