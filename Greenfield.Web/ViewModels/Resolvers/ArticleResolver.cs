using System;
using AutoMapper;
using Raven.Client;

namespace Greenfield.Web.Api.ViewModels.Resolvers
{
    public class ArticleResolver : ValueResolver<OrderRowVm, Article>
    {
        private readonly IDocumentStore _store;

        public ArticleResolver(IDocumentStore store)
        {
            _store = store;
        }

        protected override Article ResolveCore(OrderRowVm vm)
        {
            if (String.IsNullOrEmpty(vm.ArticleId))
                return null;
           using(var session = _store.OpenSession())
           {
               return session.Load<Article>(vm.ArticleId);
           }
        }
    }
}
