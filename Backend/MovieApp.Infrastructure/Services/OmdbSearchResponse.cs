namespace MovieApp.Infrastructure.Services
{
    public class OmdbSearchResponse
    {
        public List<OmdbMovie> Search { get; set; } = new();
        public string Response { get; set; } = "";
    }

    public class OmdbMovie
    {
        public string Title { get; set; } = "";
        public string Year { get; set; } = "";
        public string Poster { get; set; } = "";
    }
}
