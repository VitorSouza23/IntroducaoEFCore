namespace IntroducaoEFCore.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
    }
}