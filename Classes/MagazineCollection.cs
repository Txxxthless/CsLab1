
using System.Text;

namespace cslab1.Classes
{
    public class MagazineCollection
    {
        private List<Magazine> magazines = new List<Magazine>();

        public List<Magazine> Magazines 
        { 
            get => magazines;
        }

        public Magazine this[int index]
        {
            get => this.magazines[index];
            set
            {
                if (index >= 0 || index < this.magazines.Count)
                {
                    this.magazines[index] = value;
                    this.MagazineReplaced?.Invoke(
                        value, new MagazineListHandlerEventArgs(this.CollectionName, "Magazine Replaced", index)
                        );
                }
            }
        }

        public string CollectionName { get; set; }

        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);

        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;

        public void AddDefaults()
        {

            List<Magazine> defaults = new List<Magazine>()
            {
                new Magazine(),
                new Magazine("Default", Frequency.Weekly, DateTime.Now, 20)
            };

            magazines.AddRange(defaults);

            foreach (Magazine magazine in defaults)
            {
                this.MagazineAdded?.Invoke(
                    magazine, new MagazineListHandlerEventArgs(this.CollectionName, "Magazine Added", this.magazines.IndexOf(magazine))
                    );
            }
        }

        public void AddMagazines(params Magazine[] magazines)
        {
            this.magazines.AddRange(magazines);

            foreach (Magazine magazine in magazines)
            {
                this.MagazineAdded?.Invoke(
                    magazine, new MagazineListHandlerEventArgs(this.CollectionName, "Magazine Added", this.magazines.IndexOf(magazine))
                    );
            }
        }

        public bool Replace(int j, Magazine magazine)
        {   
            try
            {
                this.magazines.Insert(j, magazine);
                this.MagazineReplaced?.Invoke(
                    magazine, new MagazineListHandlerEventArgs(this.CollectionName, "Magazine Replaced", j)
                    );
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void SortByName()
        {
            magazines.Sort();
        }

        public void SortByPublicationDate()
        {
            magazines.Sort(new Magazine());
        }

        public void SortByPrinting()
        {
            magazines.Sort(new EditionComparer());
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(Magazine magazine in magazines)
            {
                stringBuilder.AppendLine(magazine.ToString());
            }

            return stringBuilder.ToString();
        }

        public string ToShortString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(Magazine magazine in magazines)
            {
                stringBuilder.AppendLine(magazine.ToShortString());
            }

            return stringBuilder.ToString();
        }
    }
}
