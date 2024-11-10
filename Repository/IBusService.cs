using FastX_CaseStudy.Models;

namespace FastX_CaseStudy.Repository
{
    public interface IBusService
    {
        List<bus> GetAllBuses();
        bus GetBusById(int id);
        int AddNewBus(bus buses);
        string UpdateBus(bus buses);
        string DeleteBus(int id);
    }
}
