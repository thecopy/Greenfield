using System;
using System.Diagnostics;
using Greenfield.Web.Api.ViewModels;
using Nancy;
using Nancy.Responses;
using Raven.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Greenfield.Web
{
    public class SalesModule : GreenfieldUiModule
    {
        public SalesModule(IDocumentSession session, DefaultJsonSerializer jsonSerializer)
            : base("/sales")
        {
            Get["/"] = _ => View["Sales/ListSalesOrders.cshtml"];

            Get["/edit/order/"] = _ =>
            {
                var order = new Order()
                    {
                        Id = null
                    };
                
                var vm = AutoMapper.Mapper.Map<OrderVm>(order);
                vm.IsNew = true;
                ViewBag.IsNew = true;
                ViewBag.OrderType = "Sales";
                ViewBag.ModelAsJson = JsonConvert.SerializeObject(vm, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                return View["Orders/EditOrderGeneric.cshtml", vm];
            };

            Get["/edit/order/{orderid*}"] = _ =>
            {
                var orderId = (string)_.orderid;
                var order = session.Load<Order>(orderId);
                
                var vm = AutoMapper.Mapper.Map<OrderVm>(order);
                ViewBag.IsNew = false;
                ViewBag.OrderType = "Sales";
                ViewBag.ModelAsJson = JsonConvert.SerializeObject(vm, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                return View["Orders/EditOrderGeneric.cshtml", vm];
            };
        }
    }
}
