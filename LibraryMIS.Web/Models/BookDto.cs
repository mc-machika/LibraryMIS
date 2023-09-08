namespace LibraryMIS.FrontEnd.Web.Models
{
    public class BookDto
    {
        public string? Id { get; set; }

        public string Title { get; set; } = "";

        public string ISBN { get; set; } = "";

        public string Authors { get; set; } = "";


        public string? Publisher { get; set; }

        public string? PublicationDate { get; set; }

        public string? Genre { get; set; }

        public string? Synopsis { get; set; }

        public int PageCount { get; set; }

        public string? Language { get; set; }

        public string? ShelfLocation { get; set; }

        public string? Condition { get; set; }

        public string? AcquisitionMethod { get; set; }

        public decimal Price { get; set; }

        public string? SeriesInformation { get; set; }

        public string? Keywords { get; set; }
    }
}
