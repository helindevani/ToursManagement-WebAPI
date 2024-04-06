using ToursDatabase.Domain.Entities;

namespace ToursDatabase.ServiceContracts.Repository
{
    public interface ITourBookingRepository
    {
        Task<IEnumerable<TourBooking>> GetAllTourBookings();
        Task<TourBooking> GetTourBooking(Guid id);
        Task UpdateTourBooking(TourBooking tourBooking);
        Task<TourBooking> CreateTourBooking(TourBooking tourBooking);
        Task DeleteTourBooking(Guid id);
        Task SendBookingConfirmationEmail(TourBooking tourBooking);
    }
}
