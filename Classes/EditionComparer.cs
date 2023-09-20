
namespace cslab1.Classes
{
    public class EditionComparer : IComparer<Edition>
    {
        public int Compare(Edition? x, Edition? y)
        {
            if (x is null || y is null)
            {
                throw new NullReferenceException();
            }

            if (x.Printing > y.Printing)
            {
                return -1;
            }
            else if (x.Printing == y.Printing)
            {
                return 0;
            }
            else return 1;
        }
    }
}
