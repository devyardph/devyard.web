namespace DYS.Devyard.Web.Shared.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string TagLine { get; set; }
        public string Category { get; set; }
        public string Badge { get; set; }
        public string Icon { get; set; }
        //public List<string> Tags { get; set; } = new List<string>();
    }
}
