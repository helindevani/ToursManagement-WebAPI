namespace ToursDatabase.ServiceContracts
{
    public interface IAuditable
    {
        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}