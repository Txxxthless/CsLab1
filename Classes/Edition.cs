
using System.ComponentModel;
using System.Text;

namespace cslab1.Classes
{
    public class Edition : IComparable, IComparer<Edition>
    {
        protected string _name;
        protected DateTime _firstPublicationDate;
        protected int _printing;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public DateTime FirstPublicationDate
        {
            get { return _firstPublicationDate; }
            set { _firstPublicationDate = value; }
        }
        public int Printing
        {
            get { return _printing; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Printing cannot be below 0");
                }
                _printing = value; 
            }
        }

        public Edition(string name, DateTime firstPublicationDate, int printing)
        {
            _name = name;
            _firstPublicationDate = firstPublicationDate;
            _printing = printing;
        }
        
        public Edition()
        {
            _name = "The Rolling Stones";
            _firstPublicationDate = new DateTime(1967, 9, 11);
            _printing = 20000;
        }

        public virtual object DeepCopy()
        {
            return new Edition()
            {
                Name = this.Name,
                FirstPublicationDate = this.FirstPublicationDate,
                Printing = this.Printing
            };
        }
        public override bool Equals(object? obj)
        {
            Edition otherEdition = (Edition)obj;
            return Name == otherEdition?.Name 
                && FirstPublicationDate == otherEdition.FirstPublicationDate
                && Printing == otherEdition.Printing;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0}, first published on {1}, printing {2}",
                Name, FirstPublicationDate, Printing);
        }

        public int CompareTo(object? obj)
        {
            if (obj is Edition anotherEdition)
            {
                if (String.Compare(this.Name, anotherEdition.Name) < 0)
                {
                    return -1;
                }
                else if (this.Name == anotherEdition.Name)
                {
                    return 0;
                }
                else return 1;
            }
            throw new Exception("Inputed object is not an instanse of Edition");
        }

        public int Compare(Edition? x, Edition? y)
        {
            if(x is null || y is null)
            {
                throw new NullReferenceException();
            }

            if (x.FirstPublicationDate < y.FirstPublicationDate)
            {
                return -1;
            }
            else if (x.FirstPublicationDate == y.FirstPublicationDate)
            {
                return 0;
            }
            else return 1;
        }

        public static bool operator == (Edition firstEdition, Edition secondEdition)
        {
            return firstEdition.Name == secondEdition.Name
                && firstEdition.FirstPublicationDate == secondEdition.FirstPublicationDate
                && firstEdition.Printing == secondEdition.Printing;
        }
        public static bool operator !=(Edition firstEdition, Edition secondEdition)
        {
            return !( firstEdition.Name == secondEdition.Name
                && firstEdition.FirstPublicationDate == secondEdition.FirstPublicationDate
                && firstEdition.Printing == secondEdition.Printing );
        }
    }
}
