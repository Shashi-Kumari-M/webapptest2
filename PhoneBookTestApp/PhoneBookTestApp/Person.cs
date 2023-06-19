namespace PhoneBookTestApp
{
    public class Person
    {
        public string name;
        public string phoneNumber;
        public string address;
        public bool IsValid
        {
            get
            {
                if (
                        string.IsNullOrWhiteSpace(name) ||
                        string.IsNullOrWhiteSpace(phoneNumber) ||
                        string.IsNullOrWhiteSpace(address))
                {
                    return false;
                }
                else
                {
                    return true;
                };
            }
        }
    }
}