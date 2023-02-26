using shopyway.Function;
using shopyway.Model;

namespace shopyway.Interface
{
    public interface ICart
    {
        dynamic add_to_cart(cart_f c);
       dynamic goto_cart(Goto_cart_fun f);

        dynamic remove_cart(cart_f c);
    }
}
