﻿using System.Threading.Tasks;
using FluentAssertions;
using LinkDotNet.Blog.TestUtilities;
using Xunit;

namespace LinkDotNet.Blog.IntegrationTests.Infrastructure.Persistence.Sql
{
    public class ProfileRepositoryTests : SqlDatabaseTestBase
    {
        [Fact]
        public async Task ShouldSaveAndRetrieveAllEntries()
        {
            var item1 = new ProfileInformationEntryBuilder().WithContent("key1").Build();
            var item2 = new ProfileInformationEntryBuilder().WithContent("key2").Build();
            await ProfileRepository.StoreAsync(item1);
            await ProfileRepository.StoreAsync(item2);

            var items = await ProfileRepository.GetAllAsync();

            items[0].Content.Should().Be("key1");
            items[1].Content.Should().Be("key2");
        }

        [Fact]
        public async Task ShouldDelete()
        {
            var item1 = new ProfileInformationEntryBuilder().WithContent("key1").Build();
            var item2 = new ProfileInformationEntryBuilder().WithContent("key2").Build();
            await ProfileRepository.StoreAsync(item1);
            await ProfileRepository.StoreAsync(item2);

            await ProfileRepository.DeleteAsync(item1.Id);

            var items = await ProfileRepository.GetAllAsync();
            items.Should().HaveCount(1);
            items[0].Id.Should().Be(item2.Id);
        }

        [Fact]
        public async Task NoopOnDeleteWhenEntryNotFound()
        {
            var item = new ProfileInformationEntryBuilder().WithContent("key1").Build();
            await ProfileRepository.StoreAsync(item);

            await ProfileRepository.DeleteAsync("SomeIdWhichHopefullyDoesNotExist");

            (await ProfileRepository.GetAllAsync()).Should().HaveCount(1);
        }
    }
}