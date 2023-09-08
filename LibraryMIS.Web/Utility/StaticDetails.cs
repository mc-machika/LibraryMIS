namespace LibraryMIS.Web.Utility
{
    public class StaticDetails
    {
        public static string BookApiBase { get; set; }
        public static string AuthApiBase { get; set; }
        public static string MemberApiBase { get; set; }

        public static string RentalApiBase { get; set; }

        public const string RoleManagement = "MANAGEMENT";

        public const string RoleFrontOffice = "FRONTOFFICE";

        public const string RoleBackOffice = "BACKOFFICE";

        public const string TokenCookie = "JWTToken";

        public const string NationalFund = "National Fund";

        public const string Donation = "Donation";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
