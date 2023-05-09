using System.ComponentModel.DataAnnotations;

namespace AllUp.Models
{
    public class Translate
    {
        [Key]
        public int Id { get; set; }
        public string language { get; set; }
        public string HeaderTitle { get; set; }
        public string HeaderSubtitle { get; set; }
        public string CardTitle { get; set; }
        public string CardSubTitle { get; set; }
        public string CategoryName { get; set; }

    }
}
