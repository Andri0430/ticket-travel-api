using TicketTravel.Models;

namespace TicketTravel.Interface
{
    public interface ITransportationType
    {
        ICollection<TransportationType> GetAllTransportationType();
        TransportationType TransportationTypeGetById(int id);
        void Create(TransportationType transportationType);
        void Update(TransportationType transportationType);
        void Delete(int id);
    }
}
