using System.Linq;
using AutoMapper;
using Greenfield.Web.Api.ViewModels;
using Greenfield.Web.Api.ViewModels.Resolvers;
using Nancy;
using Nancy.ModelBinding;
using Raven.Client;

namespace Greenfield.Web.Api
{
    public class SalesOrderModule : GreenfieldWebModule
    {
        public SalesOrderModule(IDocumentSession session)
            : base("/salesorders")
        {
            Get["/"] = _ =>
            {

                return Response.AsJson(new
                {
                    data = session
                        .Query<Order>()
                        .Skip(0)
                        .Take(10)
                });
            };
            Get["/dt/"] = _ =>
            {
                int draw = Request.Query.draw;
                int skip = Request.Query.start;
                int take = Request.Query.length;

                return Response.AsJson(new
                    {
                        data = session
                            .Query<Order>()
                            .Skip(skip)
                            .Take(take),
                        recordsTotal = session.Query<Order>().Count(),
                        recordsFiltered = session.Query<Order>().Count(),
                        draw
                    });
            };
            
            Get["/{orderid}"] = _ =>
            {
                string orderid = _.orderid;

                return Mapper.Map<OrderVm>( session.Load<Order>(orderid) );
            };

            Post["/"] = param =>
            {
                var orderVm = this.Bind<OrderVm>();
                if (orderVm.IsNew)
                {
                    orderVm.Id = null;
                }

                var order = Mapper.Map<Order>(orderVm);

                session.Store(order);
                session.SaveChanges();
                return new { order.Id };
            };
        }
    }
}