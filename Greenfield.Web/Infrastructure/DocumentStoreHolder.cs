using System;
using Raven.Client;
using Raven.Client.Document;

namespace Greenfield.Web.Api.Infrastructure
{
    internal class DocumentStoreHolder
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store
        {
            get { return store.Value; }
        }

        private static IDocumentStore CreateStore()
        {
            var documentStore = new DocumentStore()
            {
                Url = "http://localhost:8081",
                DefaultDatabase = "Greenfield"
            }.Initialize();

            return documentStore;
        }
    }
}
