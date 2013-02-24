using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neo4jClient;

namespace LearningPlatform.Models
{
    public class Scaffolding
    {
        GraphClient client;
        public Scaffolding()
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data"));
            client.Connect();

            client.CreateIndex("User", new IndexConfiguration() { Provider = IndexProvider.lucene, Type = IndexType.exact }, IndexFor.Node); // full text node index
            client.CreateIndex("Module", new IndexConfiguration() { Provider = IndexProvider.lucene, Type = IndexType.fulltext }, IndexFor.Node); // exact node index
            //client.CreateIndex("Genre", new IndexConfiguration() { Provider = IndexProvider.lucene, Type = IndexType.fulltext }, IndexFor.Node); // full text node index

            // Create Entities
            // Movies
            /*
            Movie swI = new Movie() { Name = "Star Wars: Episode I - The Phantom Menace", Description = "Begins the story of Anakin Skywalker" };

            var starWarsEpisodeI = client.Create(swI,
                new IRelationshipAllowingParticipantNode<Movie>[0],
                new[]
                {
                    new IndexEntry("Movie")
                    {
                        { "Name", swI.Name },
                        { "Description", swI.Description },
                        { "Id", swI.Id.ToString() }
                    }
                });

            Movie swIV = new Movie() { Name = "Star Wars: Episode IV - A New Hope", Description = "First Starwars movie to debut on the big screen" };

            var starWarsEpisodeIV = client.Create(swIV,
                new IRelationshipAllowingParticipantNode<Movie>[0],
                new[]
                {
                    new IndexEntry("Movie")
                    {
                        { "Name", swIV.Name },
                        { "Description", swIV.Description },
                        { "Id", swIV.Id.ToString() }
                    }
                });

            Movie indy = new Movie() { Name = "Indiana Jones and the Temple of Doom", Description = "Second movie in the original Indiana Jones trilogy" };

            var indianaJonesTempleOfDoom = client.Create(indy,
                new IRelationshipAllowingParticipantNode<Movie>[0],
                new[]
                {
                    new IndexEntry("Movie")
                    {
                        { "Name", indy.Name },
                        { "Description", indy.Description },
                        { "Id", indy.Id.ToString() }
                    }
                });

            Movie jp = new Movie() { Name = "Jurassic Park", Description = "First Jurassic park movie" };

            var jurassicPark = client.Create(jp,
                new IRelationshipAllowingParticipantNode<Movie>[0],
                new[]
                {
                    new IndexEntry("Movie")
                    {
                        { "Name", jp.Name },
                        { "Description", jp.Description },
                        { "Id", jp.Id.ToString() }
                    }
                });

            Movie et = new Movie() { Name = "ET", Description = "ET phone home" };

            var ET = client.Create(et,
                new IRelationshipAllowingParticipantNode<Movie>[0],
                new[]
                {
                    new IndexEntry("Movie")
                    {
                        { "Name", et.Name },
                        { "Description", et.Description },
                        { "Id", et.Id.ToString() }
                    }
                }); */

            // Directors

            User lucas = new User() { UserName = "George Lucas", Email_ID ="Lucas", Password ="student_1" };

            var georgeLucas = client.Create(lucas,
                new IRelationshipAllowingParticipantNode<User>[0],
                new[]
                {
                    new IndexEntry("User")
                    {
                        { "Name", lucas.UserName },
                        { "Id", lucas.UserID.ToString() }
                    }
                });

            User spielberg = new User() { UserName = "Steven Spielberg", Email_ID = "Lucas", Password = "student_1" };

            var stevenSpielberg = client.Create(spielberg,
                new IRelationshipAllowingParticipantNode<User>[0],
                new[]
                {
                    new IndexEntry("User")
                    {
                        { "Name", spielberg.UserName },
                        { "Id", spielberg.UserID.ToString() }
                    }
                });

            Module module1 = new Module() { ModuleName = "Module 1" };

            var modModule1 = client.Create(module1,
                new IRelationshipAllowingParticipantNode<Module>[0],
                new[]
                {
                    new IndexEntry("Module")
                    {
                        { "Name", module1.ModuleName },
                        { "Id", module1.ModuleId.ToString() }
                    }
                });

            Module module2 = new Module() { ModuleName = "Module 2" };
            var modModule2 = client.Create(module2,
                new IRelationshipAllowingParticipantNode<Module>[0],
                new[]
                {
                    new IndexEntry("Module")
                    {
                        { "Name", module2.ModuleName },
                        { "Id", module2.ModuleId.ToString() }
                    }
                });

           /* // Genres
            Genre sf = new Genre() { Name = "Science Fiction" };

            var sciFi = client.Create(sf,
                new IRelationshipAllowingParticipantNode<Genre>[0],
                new[]
                {
                    new IndexEntry("Genre")
                    {
                        { "Name", sf.Name },
                        { "Id", sf.Id.ToString() }
                    }
                });

            Genre adv = new Genre() { Name = "Adventure" };

            var adventure = client.Create(adv,
                new IRelationshipAllowingParticipantNode<Genre>[0],
                new[]
                {
                    new IndexEntry("Genre")
                    {
                        { "Name", adv.Name },
                        { "Id", adv.Id.ToString() }
                    }
                }); */

            // Create Relationships
            client.CreateRelationship(stevenSpielberg, new HasCompletedRelation(modModule1));
            client.CreateRelationship(stevenSpielberg, new HasCompletedRelation(modModule2));

            client.CreateRelationship(georgeLucas, new HasCompletedRelation(modModule2));


            /*
            client.CreateRelationship(starWarsEpisodeIV, new PartOf(sciFi));

            client.CreateRelationship(indianaJonesTempleOfDoom, new PartOf(adventure));

            client.CreateRelationship(jurassicPark, new PartOf(sciFi));
            client.CreateRelationship(jurassicPark, new PartOf(adventure));

            client.CreateRelationship(ET, new PartOf(sciFi));

            client.CreateRelationship(georgeLucas, new Directed(starWarsEpisodeI, new Models.Payloads.Payload() { Comment = "George Lucas' second Star Wars trilogy" }));
            client.CreateRelationship(georgeLucas, new Directed(starWarsEpisodeIV, new Models.Payloads.Payload() { Comment = "First Starwars movie that George Lucas directed" }));
            client.CreateRelationship(georgeLucas, new Directed(indianaJonesTempleOfDoom, new Models.Payloads.Payload() { Comment = "Lucas collaborated with Spielberg while filming" }));

            client.CreateRelationship(stevenSpielberg, new Directed(jurassicPark, new Models.Payloads.Payload() { Comment = "Huge box office success" }));
            client.CreateRelationship(stevenSpielberg, new Directed(ET, new Models.Payloads.Payload() { Comment = "One of Spielberg's most successful movies" }));
            */

            /*
            var refA = client.Create(new User() { UserName = "Person A" });
            var refB = client.Create(new Module() { ModuleName = "Module A" });
            var refC = client.Create(new Module() { ModuleName = "Module B" });
            var refD = client.Create(new User() { UserName = "Person D" });

            // Create relationships
            client.CreateRelationship(refA, new HasCompletedRelation(refB));
            client.CreateRelationship(refA, new HasCompletedRelation(refC));
            client.CreateRelationship(refD, new HasCompletedRelation(refC));
            //client.CreateRelationship(refC, new HasCompletedRelation(refD) { Reason = "Don't know why : )" });
            client.CreateRelationship(refD, new HasCompletedRelation(refA)); */

        }
    }
}