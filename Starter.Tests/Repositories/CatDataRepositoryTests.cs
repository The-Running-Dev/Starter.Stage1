using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;
using Newtonsoft.Json;
using FluentAssertions;
using Starter.Repository;
using Starter.Data.Configuration;

namespace Starter.Tests.Repositories
{
    /// <summary>
    /// Contains tests for the CatRepository class
    /// </summary>
    [TestFixture]
    public class CatDataRepositoryTests : TestsBase
    {
        [Test]
        [Category("Integration")]
        public async Task Load_Should_Cat_Data()
        {
            var tempFile = GetTemporaryFile();
            var repository = new CatDataRepository(new Settings(tempFile));

            File.WriteAllText(tempFile, JsonConvert.SerializeObject(Cats));

            var cats = await repository.LoadAsync();

            cats.Count().Should().BeGreaterThan(0);

            File.Delete(tempFile);
        }

        [Test]
        [Category("Integration")]
        public void Load_Should_Throw_General_Exception()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => CatDataRepository.LoadAsync());
        }

        [Test]
        [Category("Integration")]
        public void Load_Should_Throw_Exception_On_Not_Existing_File()
        {
            var tempFile = GetTemporaryFile();
            var repository = new CatDataRepository(new Settings(tempFile));

            Assert.ThrowsAsync<FileNotFoundException>(() => repository.LoadAsync());
        }

        [Test]
        [Category("Integration")]
        public void Load_Should_Throw_Exception_On_Bad_Data()
        {
            var tempFile = GetTemporaryFile();
            var repository = new CatDataRepository(new Settings(tempFile));
            
            File.WriteAllText(tempFile, "Non-JSON gibberish");

            Assert.ThrowsAsync<JsonReaderException>(() => repository.LoadAsync());
        }

        [Test]
        [Category("Integration")]
        public async Task Save_Should_Write_To_File()
        {
            var tempFile = GetTemporaryFile();
            var repository = new CatDataRepository(new Settings(tempFile));

            await repository.SaveAsync(Cats);

            var contents = File.ReadAllText(tempFile);

            contents.Should().Contain($"\"Name\":\"{Cats.FirstOrDefault().Name}\"");

            File.Delete(tempFile);
        }

        [Test]
        [Category("Integration")]
        public void Save_Should_Throw_General_Exception()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => CatDataRepository.SaveAsync(Cats));
        }
    }
}