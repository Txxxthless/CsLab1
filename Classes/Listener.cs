
using System.Text;

namespace cslab1.Classes
{
    public class Listener
    {
        private List<ListEntry> _entries = new List<ListEntry>();

        public void EventHandler(object source, MagazineListHandlerEventArgs args)
        {
            Console.WriteLine($"EVENT FIRED: { args.ChangeType } { args.Name }");
            this._entries.Add(
                new ListEntry(args.Name, args.ChangeType, args.ElementIndex)
            );
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (ListEntry entry in _entries)
            {
                stringBuilder.Append(entry.ToString() + "\n");
            }

            return stringBuilder.ToString();
        }
    }
}
