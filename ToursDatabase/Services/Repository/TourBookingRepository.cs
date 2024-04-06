using Microsoft.EntityFrameworkCore;
using ToursDatabase.DatabaseContext;
using ToursDatabase.Domain.Entities;
using ToursDatabase.ServiceContracts;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Services.Repository
{
    public class TourBookingRepository : ITourBookingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSenderService _emailSender;

        public TourBookingRepository(ApplicationDbContext context, IEmailSenderService emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async Task<IEnumerable<TourBooking>> GetAllTourBookings()
        {
            return await _context.TourBookings.ToListAsync();
        }

        public async Task<TourBooking> GetTourBooking(Guid id)
        {
            var tourBooking = await _context.TourBookings.Include(t => t.Tour).Include(l => l.Tour.Locations).FirstOrDefaultAsync(i => i.BookingID == id);

            return tourBooking;
        }

        public async Task UpdateTourBooking(TourBooking tourBooking)
        {
            var existingTourBooking = await _context.TourBookings
                 .Include(t => t.Tour)
                 .FirstOrDefaultAsync(i => i.BookingID == tourBooking.BookingID);

            if (existingTourBooking == null)
            {
                throw new InvalidOperationException("Tour booking not found");
            }

            existingTourBooking.CustomerName = tourBooking.CustomerName;
            existingTourBooking.CustomerEmail = tourBooking.CustomerEmail;
            existingTourBooking.BookingDate = tourBooking.BookingDate;
            existingTourBooking.TourDate = tourBooking.TourDate;
            existingTourBooking.TourId = tourBooking.TourId;
            existingTourBooking.Status = tourBooking.Status;
            existingTourBooking.UpdateDate = tourBooking.UpdateDate;

            await _context.SaveChangesAsync();

            TourBooking tour = await _context.TourBookings.Include(t => t.Tour).FirstOrDefaultAsync(i => i.BookingID == tourBooking.BookingID);

            await SendBookingConfirmationEmail(tour);
        }


        public async Task<TourBooking> CreateTourBooking(TourBooking tourBooking)
        {
            _context.TourBookings.Add(tourBooking);
            await _context.SaveChangesAsync();

            TourBooking tour = await _context.TourBookings.Include(t => t.Tour).FirstOrDefaultAsync(i => i.BookingID == tourBooking.BookingID);

            await SendBookingConfirmationEmail(tour);

            return tourBooking;
        }

        public async Task DeleteTourBooking(Guid id)
        {
            var tourBooking = await _context.TourBookings.FindAsync(id);
            _context.TourBookings.Remove(tourBooking);
            await _context.SaveChangesAsync();
        }

        public async Task SendBookingConfirmationEmail(TourBooking tourBooking)
        {
            if (tourBooking == null)
            {
                throw new ArgumentNullException(nameof(tourBooking), "Tour booking object is null");
            }

            if (string.IsNullOrEmpty(tourBooking.CustomerEmail))
            {
                throw new ArgumentException("Customer email is null or empty", nameof(tourBooking.CustomerEmail));
            }

            string tourName = tourBooking.Tour != null ? tourBooking.Tour.Name : "Unknown Tour";

            string emailContent = $"Thank you for booking a tour with us. Here are your booking details:<br><br>" +
                                  $"Booking ID: {tourBooking.BookingID}<br>" +
                                  $"Tour Name: {tourName}<br>" +
                                  $"Booking Date: {tourBooking.BookingDate}<br>" +
                                  $"Customer Name: {tourBooking.CustomerName}<br>" +
                                  $"Customer Email: {tourBooking.CustomerEmail}<br>";

            await _emailSender.SendEmailAsync(tourBooking.CustomerEmail, "Tour Booking Confirmation", emailContent);
        }
    }
}
