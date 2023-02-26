namespace shopyway.Interface
{
    public interface IDetails
    {
        dynamic get_details(string id);
        dynamic get_add_data(string type);
        dynamic get_elec_add_data(string id);
    }
}
