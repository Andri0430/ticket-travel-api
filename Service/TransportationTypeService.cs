using TicketTravel.Data;
using TicketTravel.Interface;
using TicketTravel.Models;

namespace TicketTravel.Repository
{
    public class TransportationTypeService : ITransportationType
    {
        private readonly TicketTravelContext _ticketTravelContext;

        public TransportationTypeService(TicketTravelContext ticketTravelContext)
        {
            _ticketTravelContext = ticketTravelContext;
        }

        public void Create(TransportationType transportationType)
        {
            _ticketTravelContext.Add(transportationType);
            _ticketTravelContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _ticketTravelContext.TransportationTypes.Remove(TransportationTypeGetById(id));
            _ticketTravelContext.SaveChanges();
        }

        public ICollection<TransportationType> GetAllTransportationType()
        {
            return _ticketTravelContext.TransportationTypes.ToList();
        }

        public TransportationType TransportationTypeGetById(int id)
        {
            return _ticketTravelContext.TransportationTypes.Where(t => t.Id == id).FirstOrDefault()!;
        }

        public void Update(TransportationType transportationType)
        {
            _ticketTravelContext.TransportationTypes.Update(transportationType);
            _ticketTravelContext.SaveChanges();
        }
    }
}
