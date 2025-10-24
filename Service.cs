namespace WinFormsApp2
{
    public class Service
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public Service(string name, string description, string price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return Name; // щоб ComboBox показував назву
        }
    }
}
