using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib.Tests
{
    public class TrophiesRepositoryTests
    {
        [Fact]
        public void Add_ShouldAssignId_AndStoreTrophy()
        {
            // Arrange
            var repo = new TrophiesRepository();
            var trophy = new Trophy { Competition = "Testløb", Year = 2021 };

            // Act
            var added = repo.Add(trophy);
            var all = repo.Get();

            // Assert
            Assert.True(added.Id > 0);
            Assert.Contains(all, t => t.Competition == "Testløb" && t.Year == 2021);
        }

        [Fact]
        public void Get_FilterByYear_ShouldReturnOnlyThatYear()
        {
            var repo = new TrophiesRepository();

            var result = repo.Get(year: 2019);

            Assert.NotEmpty(result);
            Assert.All(result, t => Assert.Equal(2019, t.Year));
        }

        [Fact]
        public void Get_SortByCompetition_ShouldReturnAlphabetically()
        {
            var repo = new TrophiesRepository();

            var sorted = repo.Get(sortBy: "competition");
            var expected = sorted.OrderBy(t => t.Competition).ToList();

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void Update_ShouldChangeCompetitionAndYear()
        {
            var repo = new TrophiesRepository();
            var values = new Trophy { Competition = "Ny konkurrence", Year = 2022 };

            var updated = repo.Update(1, values);

            Assert.NotNull(updated);
            Assert.Equal("Ny konkurrence", updated!.Competition);
            Assert.Equal(2022, updated.Year);
        }
    }
}
