using System;
using AutoMapper;
using Greenfield.Web.Api.Infrastructure;
using Greenfield.Web.Api.ViewModels;
using Greenfield.Web.Api.ViewModels.Resolvers;
using Ninject;
using Raven.Client;

namespace Greenfield.Web.Api
{
    public static class GreenfieldBootstrapper
    {
        private static bool hasRunAlready = false;

        public static void SetupAutoMapping()
        {
            Mapper.CreateMap<Order, OrderVm>()
                  .ReverseMap();

            Mapper.CreateMap<OrderRow, OrderRowVm>()
                  .ReverseMap()
                  .ForMember(
                    x => x.Article, 
                    opt => opt.ResolveUsing<ArticleResolver>()
                              .ConstructedBy(() => new ArticleResolver(DocumentStoreHolder.Store))
                  );
        }

        public static void SetupNinjectGlobalScope(IKernel existingKernel = null)
        {
            if (hasRunAlready)
            {
                throw new InvalidOperationException(
                    "This function is only intended to be run once before starting the Greenfield Server.");
            }
            hasRunAlready = true;

            existingKernel = existingKernel ?? new StandardKernel();
            existingKernel.Bind<IDocumentStore>().ToConstant(DocumentStoreHolder.Store);
        }

        public static void SetupNinjectRequestScope(IKernel existingKernel)
        {
            existingKernel.Bind<IDocumentSession>().ToMethod(_ => DocumentStoreHolder.Store.OpenSession());
        }
    }
}
