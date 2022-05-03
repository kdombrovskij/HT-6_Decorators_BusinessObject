using NUnit.Framework;
using HT4_Parallel.PageObjects;
using HT4_Parallel.Utils;
using HT4_Parallel.DataSource;

[assembly: LevelOfParallelism(3)]

namespace HT4_Parallel.Tests
{
    [TestFixture]

    [Parallelizable(scope: ParallelScope.All)]
    class CardSummCheckTest : BaseTest
    {

        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.TestData))]
        public void Test1(Filter filter)
        {
            BasePage homePage = new BasePage(Driver);
            homePage.makeSearchByKeyword(filter.item);
            SearchResultPage searchResultPage = new SearchResultPage(Driver);
            searchResultPage.filterByProducer(filter.producer);
            searchResultPage.changeSortingOrder(2);
            searchResultPage.clickBuyButton();
            int total = searchResultPage.getShoppingCartSumm();
            Assert.That(total, Is.LessThan(filter.price));
        }

    }
}
