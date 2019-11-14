using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using Starter.Repository;
using Starter.Bootstrapper;
using Starter.Data.Entities;
using Starter.Data.Configuration;
using Starter.Data.Interfaces.Services;
using Starter.Data.Interfaces.Repositories;

namespace Starter.Tests
{
    [SetUpFixture]
    public class TestsBase
    {
        protected ICatService CatService;

        protected ICatRepository CatRepository;
        protected Mock<ICatRepository> CatRepositoryMock;

        protected ICatDataRepository CatDataRepository;
        protected Mock<ICatDataRepository> CatDataRepositoryMock;

        protected Mock<ISettings> SettingsMock;

        protected List<Cat> Cats;

        /// <summary>
        /// One time setup for all test execution
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Setup.Bootstrap();

            CreateCatTestData();

            CatRepositoryMock = new Mock<ICatRepository>();
            CatDataRepositoryMock = new Mock<ICatDataRepository>();
            SettingsMock = new Mock<ISettings>();

            //// Setup the cat repository
            //CatRepositoryMockObject.Setup(x => x.GetAll()).Returns(Task.FromResult(Cats.AsEnumerable()));
            //CatRepositoryMockObject.Setup(x => x.GetById(It.IsAny<Guid>()))
            //    .Returns(Task.FromResult(Cats.FirstOrDefault()));
            //CatRepositoryMockObject.Setup(x => x.Delete(It.IsAny<Cat>())).Returns(Task.CompletedTask);

            // Setup the cat data repository
            CatDataRepositoryMock.Setup(x => x.LoadAsync(It.IsAny<bool>()))
                .Returns(Task.FromResult(Cats.AsEnumerable()));
            CatDataRepositoryMock.Setup(x => x.SaveAsync(It.IsAny<IEnumerable<Cat>>())).Returns(Task.CompletedTask);

            //CatService = new CatService(CatRepositoryMockObject.Object);
            CatRepository = new CatRepository(CatDataRepositoryMock.Object);
            CatDataRepository = new CatDataRepository(SettingsMock.Object);
        }

        protected void CreateCatTestData()
        {
            Cats = new List<Cat>
            {
                new Cat { Id = Guid.NewGuid(), Name  = "Widget", Ability = Ability.Eating },
                new Cat { Id = Guid.NewGuid(), Name  = "Garfield", Ability = Ability.Engineering },
                new Cat { Id = Guid.NewGuid(), Name  = "Mr. Boots", Ability = Ability.Lounging }
            };
        }

        protected string GetTemporaryFile()
        {
            return Path.Combine(Path.GetTempPath(), $"Cats-{Guid.NewGuid()}.json");
        }
    }
}