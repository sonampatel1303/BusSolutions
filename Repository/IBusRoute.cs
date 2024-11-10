using FastX_CaseStudy.Models;

namespace FastX_CaseStudy.Repository
{
    public interface IBusRoute
    {
        List<BusRoute> BrowseRoutes(string source, string destination);


        BusRoute GetRouteDetails(int routeId);

        int AddRoute(BusRoute routeData);


        string UpdateRoute(int routeId, BusRoute routeData);


        string DeleteRoute(int routeId);
    }
}
