
using System.Diagnostics;

namespace cslab1.Classes
{
    public class TestCollections
    {
        private List<Edition> editions;

        private List<string> strings;

        private Dictionary<Edition, Magazine> dictionaryFirst;

        private Dictionary<string, Magazine> dictionarySecond;

        public static Magazine CreateMagazine(int i)
        {
            return new Magazine(i.ToString(), Frequency.Weekly, new DateTime(i), i);
        }

        public TestCollections(int numberOfElements)
        {
            editions = new List<Edition>();
            strings = new List<string>();
            dictionaryFirst = new Dictionary<Edition, Magazine>();
            dictionarySecond = new Dictionary<string, Magazine>();

            for (int i = 0; i < numberOfElements; i++)
            {
                Magazine magazine = CreateMagazine(i);
                editions.Add(magazine);
                strings.Add(magazine.ToString());
                dictionaryFirst.Add(magazine.Edition, magazine);
                dictionarySecond.Add(magazine.ToString(), magazine);
            }
        }

        public void CalculateSearchingTime(int valueToSearch)
        {
            var searchResult = false;
            var magazineToSearch = CreateMagazine(valueToSearch);

            Stopwatch stopwatch = Stopwatch.StartNew();
            searchResult = editions.Contains(magazineToSearch);
            stopwatch.Stop();

            Console.WriteLine($"TIME : {stopwatch.ElapsedTicks}, {searchResult}, List<Editions>");

            stopwatch.Restart();
            searchResult = strings.Contains(magazineToSearch.ToString());
            stopwatch.Stop();

            Console.WriteLine($"TIME : {stopwatch.ElapsedTicks}, {searchResult}, List<string>");

            stopwatch.Restart();
            searchResult = dictionaryFirst.ContainsKey(magazineToSearch.Edition);
            stopwatch.Stop();

            Console.WriteLine($"TIME : {stopwatch.ElapsedTicks}, {searchResult}, Dictionary<Edition,Magazine> Key");

            stopwatch.Restart();
            searchResult = dictionaryFirst.ContainsValue(magazineToSearch);
            stopwatch.Stop();

            Console.WriteLine($"TIME : {stopwatch.ElapsedTicks}, {searchResult}, Dictionary<Edition,Magazine> Value");

            stopwatch.Restart();
            searchResult = dictionarySecond.ContainsKey(magazineToSearch.ToString());
            stopwatch.Stop();

            Console.WriteLine($"TIME : {stopwatch.ElapsedTicks}, {searchResult}, Dictionary<Edition,Magazine> Key");

            stopwatch.Restart();
            searchResult = dictionarySecond.ContainsValue(magazineToSearch);
            stopwatch.Stop();

            Console.WriteLine($"TIME : {stopwatch.ElapsedTicks}, {searchResult}, Dictionary<string,Magazine> Value");
        }
    }
}
