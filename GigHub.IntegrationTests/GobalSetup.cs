using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace GigHub.IntegrationTests
{
    [SetUpFixture]
    public class GobalSetup
    {
        [SetUp]
        public void Setup()
        {
            var configuration = new Migrations.Configuration();
            var migrator = new DbMigrator(configuration);

            migrator.Update();
        }
    }
}
