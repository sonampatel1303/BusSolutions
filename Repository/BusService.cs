using FastX_CaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FastX_CaseStudy.Repository
{
    public class BusService : IBusService
    {
        private BusBookingContext _busSystemContext;

        public BusService(BusBookingContext busSystemContext)
        {
            _busSystemContext = busSystemContext;
        }
        public int AddNewBus(bus buses)
        {
            try
            {
                if (buses != null)
                {
                    _busSystemContext.Buses.Add(buses);
                    _busSystemContext.SaveChanges();
                    return buses.BusId;

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteBus(int id)
        {
            if (id != null)
            {
                var buses = _busSystemContext.Buses.FirstOrDefault(x => x.BusId == id);
                if (buses != null)
                {
                    _busSystemContext.Buses.Remove(buses);
                    _busSystemContext.SaveChanges();
                    return "the given Bus id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public List<bus> GetAllBuses()
        {
            var buses = _busSystemContext.Buses.ToList();
            if (buses.Count>0)
            {
                return buses;
            }
            else
                return null;
        }

        public bus GetBusById(int id)
        {
            if (id != 0 || id != null)
            {
                var buses = _busSystemContext.Buses.FirstOrDefault(x => x.BusId == id);
                if (buses != null)
                    return buses;
                else
                    return null;
            }
            return null;
        }

        public string UpdateBus(bus buses)
        {
            var existingBus = _busSystemContext.Buses.FirstOrDefault(x => x.BusId == buses.BusId);
            if (existingBus != null)
            {
                existingBus.BusId = buses.BusId;
                existingBus.Bustype = buses.Bustype;
                existingBus.BusName = buses.BusName;
                existingBus.Amenities = buses.Amenities;
                existingBus.PricePerSeat = buses.PricePerSeat;
                existingBus.NumberofSeats = buses.NumberofSeats;
                _busSystemContext.Entry(existingBus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _busSystemContext.SaveChanges();
                return "Record Updated successfully";
            }
            else
            {
                return "Something went wrong";
            }
        }
    }
}
