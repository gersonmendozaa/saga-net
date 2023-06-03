using MongoDB.Driver;
using TripPlanner.Hostel.Entities;

namespace TripPlanner.Hostel.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<HostelEntity> hostelCollection)
        {
            bool existHostel = hostelCollection.Find(p => true).Any();
            if (!existHostel)
            {
                hostelCollection.InsertManyAsync(GetPreconfiguredHostels());
            }
        }

        private static IEnumerable<HostelEntity> GetPreconfiguredHostels()
        {
            return new List<HostelEntity>()
            {
                new HostelEntity()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 950.00M
                },
                new HostelEntity()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Samsung 10",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 840.00M
                }
            };
        }
    }
}