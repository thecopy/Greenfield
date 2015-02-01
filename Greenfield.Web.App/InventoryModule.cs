using System;
using System.Diagnostics;
using Nancy;
using Raven.Client;

namespace Greenfield.Web
{
    public class InventoryModule : GreenfieldUiModule
    {
        public InventoryModule(IDocumentSession session)
            : base("/inventory")
        {
            Get["/"] = _ => View["Inventory/ListInventory.cshtml"];

            Get["/edit/{articleid*}"] = _ =>
            {
                var isNew = ((DynamicDictionary) Request.Query).ContainsKey("new");
                var articleId = (string)_.articleid;
                Debug.WriteLine("Request.Query new = " + isNew);
                Article article;
                if (isNew)
                {                    
                    article = new Article()
                    {
                        Id = articleId
                    };
                }
                else
                {
                    article = session.Load<Article>(articleId) ?? new Article();
                }

                return View["Inventory/EditArticle.cshtml", new
                {
                    Article = article,
                    IsNew = isNew
                }];
            };
        }
    }
}
