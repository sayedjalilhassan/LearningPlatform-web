using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neo4jClient;
using Neo4jClient.Cypher;
using LearningPlatform.Models;

namespace LearningPlatform.Controllers
{
    public class Neo4jController : Controller
    {
        //
        // GET: /Neo4j/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            GraphClient client = new GraphClient(new Uri("http://localhost:7474/db/data"));
            client.Connect();

            var query = new Neo4jClient.Cypher.CypherQuery(
                    "start n=node(0) match n<-[r:HasCompleted]-e return e.UserName as Name;",
                     new Dictionary<string, object>(),CypherResultMode.Projection);
           

            //var result = client.ExecuteGetCypherResults<User>(query);

            
            // get all movies with any name using index
            List<Node<User>> list = client.QueryIndex<User>("User", IndexFor.Node, "Name: *").ToList();
            List<User> movies = new List<User>();
            foreach (Node<User> movieNode in list)
            {
                movies.Add(movieNode.Data);
            }
            return View(movies);//movies);
        }




    }
}
