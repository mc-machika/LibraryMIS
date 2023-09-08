namespace LibraryMIS.Services.BookRentalAPI.Models
{
    public class Rental
    {
        public int id { get; set; }
        public string memberid { get; set; }
        public string booktitle { get; set; }
        public string bookauthors { get; set; }
        public string bookisbn { get; set; }
        public DateTime dateborrowed { get; set; }
        public DateTime duedate { get; set; }
        public string status { get; set; }
    }
}
