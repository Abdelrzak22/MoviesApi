using System.Security.Principal;

namespace WebApplication2.models
{
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }


        [MaxLength(2500)]
        public string storeline { get; set; }

        public int year { get; set; }   

        public byte[] Poster {  get; set; }
        public double Rate { get; set; }

        public byte generId {  get; set; }
        
        public Gener  gener { get; set; }   

    }
}
