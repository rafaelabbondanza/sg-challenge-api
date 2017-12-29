namespace SGChallenge.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SGChallenge.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SGChallenge.Models.SGChallengeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SGChallenge.Models.SGChallengeContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new User { Username="rafael" },
                new User { Username="abbondanza" }
            );
        }
    }
}
