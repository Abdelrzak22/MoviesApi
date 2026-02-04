namespace WebApplication2.Dto
{
    public class Moviedt
    {

        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }


        [MaxLength(2500)]
        public string storeline { get; set; }

        public int year { get; set; }

        public IFormFile Poster { get; set; }
        public double Rate { get; set; }

        public byte generId { get; set; }
    }
}
