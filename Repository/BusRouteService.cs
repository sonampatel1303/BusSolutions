using FastX_CaseStudy.Exceptions;
using FastX_CaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FastX_CaseStudy.Repository
{
    public class BusRouteService:IBusRoute
    {
        private readonly BusBookingContext _context;

        public BusRouteService(BusBookingContext context)
        {
            _context = context;
        }

        // Add a new route
        public int AddRoute(BusRoute routeData)
        {
            try
            {
                if (routeData != null)
                {
                    _context.BusRoutes.Add(routeData);
                    _context.SaveChanges();
                    return routeData.RouteId;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception($"Error adding route: {e.Message}");
            }
        }


        public string UpdateRoute(int routeId, BusRoute routeData)
        {

            var existingRoute = _context.BusRoutes.FirstOrDefault(r => r.RouteId == routeId);
            if (existingRoute != null)
            {
                existingRoute.SourcePoint = routeData.SourcePoint;
                existingRoute.Destination = routeData.Destination;
                existingRoute.BusId = routeData.BusId;
                existingRoute.DepartureTime = routeData.DepartureTime;
                existingRoute.ArrivalTime = routeData.ArrivalTime;

                _context.Entry(existingRoute).State = EntityState.Modified;
                _context.SaveChanges();

                return "Route updated successfully!";
            }
            else
            {
                return "Route not found.";
            }
        }




        public string DeleteRoute(int routeId)
        {

            var route = _context.BusRoutes.FirstOrDefault(r => r.RouteId == routeId);
            if (route != null)
            {
                _context.BusRoutes.Remove(route);
                _context.SaveChanges();
                return $"Route with ID {routeId} deleted successfully.";
            }
            else
            {
                return "Route not found.";
            }


        }


        public List<BusRoute> BrowseRoutes(string source, string destination)
        {

            var routes = _context.BusRoutes
                .Where(r => r.SourcePoint.Contains(source) && r.Destination.Contains(destination))
                .ToList();

            if (routes.Count == 0)
            {
                throw new SourcetoDestinationException($"No routes found between {source} and {destination}");
            }
            return routes;

        }


        public BusRoute GetRouteDetails(int routeId)
        {

            var route = _context.BusRoutes
                .FirstOrDefault(r => r.RouteId == routeId);

            if (route != null)
            {
                return route;
            }
            else
            {
                return null;
            }


        }
    }
}
