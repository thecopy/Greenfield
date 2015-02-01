using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using Raven.Client;

namespace Greenfield.Web.Api
{
    public class ArticleModule : GreenfieldWebModule
    {
        public ArticleModule(IDocumentSession session) : base("/articles")
        {
            Get["/"] = _ =>
            {
                return Response.AsJson(new
                {
                    data = session
                        .Query<Article>()
                        .Skip(0)
                        .Take(50)
                });
            };

            Get["/query/{query}"] = _ =>
            {
                var query = (string)_.query;
                return Response.AsJson(session
                        .Query<Article>()
                        .Where(a => a.Name.StartsWith(query) || a.Id.StartsWith(query))
                        .Skip(0)
                        .Take(50)
                        .OrderBy(x => x.Id)
                );
            };

            Get["/dt/"] = _ =>
            {
                int draw = Request.Query.draw;
                int skip = Request.Query.start;
                int take = Request.Query.length;

                return Response.AsJson(new
                    {
                        data = session
                            .Query<Article>()
                            .Skip(skip)
                            .Take(take),
                        recordsTotal = session.Query<Article>().Count(),
                        recordsFiltered = session.Query<Article>().Count(),
                        draw
                    });
            };
            
            Get["/article/{articleid}"] = _ =>
            {
                string articleid = _.articleid;

                return session.Load<Article>(articleid);
            };

            Post["/"] = param =>
            {
                var article = this.Bind<Article>();
                if (string.IsNullOrWhiteSpace(article.Id))
                {
                    article.Id = null;
                }

                session.Store(article);
                session.SaveChanges();
                return new {article.Id};
            };
        }
    }
}