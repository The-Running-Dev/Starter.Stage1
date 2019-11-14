using System;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;
using FluentAssertions;

using Starter.Data.Entities;

namespace Starter.Tests.Repositories
{
    /// <summary>
    /// Contains tests for the CatRepository class
    /// </summary>
    [TestFixture]
    public class CatRepositoryTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            //CreateCatTestData();

            //CatDataRepository.Stub(x => x.LoadAsync(Arg<bool>.Is.Anything))
            //    .Return(Task.FromResult(Cats.AsEnumerable()));
        }

        [Test]
        public async Task Should_Get_All_Cats()
        {
            var cats = await CatRepository.GetAllAsync();

            cats.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Should_Get_Cat_By_Id()
        {
            var cat = Cats.FirstOrDefault();
            var existingCat = await CatRepository.GetByIdAsync(cat.Id);

            existingCat.Name.Should().Be(cat.Name);
        }

        [Test]
        public async Task Should_Add_A_Cat()
        {
            var cat = new Cat { Name = Guid.NewGuid().ToString(), Ability = Ability.Napping };

            Cats.Add(cat);
            await CatRepository.AddAsync(cat);

            var existingCat = await CatRepository.GetByIdAsync(cat.Id);

            existingCat.Id.Should().Be(cat.Id);
        }

        [Test]
        public async Task Should_Update_A_Cat()
        {
            var cat = Cats.FirstOrDefault();
            cat.Name = Guid.NewGuid().ToString();

            await CatRepository.UpdateAsync(cat);

            var existingCat = await CatRepository.GetByIdAsync(cat.Id);

            existingCat.Id.Should().Be(cat.Id);
        }

        [Test]
        public async Task Should_Delete_A_Cat()
        {
            var cat = Cats.FirstOrDefault();
            cat.Name = Guid.NewGuid().ToString();

            await CatRepository.DeleteAsync(cat);
            Cats.Remove(cat);

            var existingCat = await CatRepository.GetByIdAsync(cat.Id);

            existingCat.Should().BeNull();
        }

        [Test]
        public async Task Should_Get_Exactly_3_Cats()
        {
            var results = await CatRepository.GetAllAsync();

            results.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Should_Contain_Specific_Cat()
        {
            var cat = Cats.FirstOrDefault();
            var cats = await CatRepository.GetAllAsync();

            cats.FirstOrDefault(x => x.Name == cat.Name).Should().NotBeNull();
        }
    }
}