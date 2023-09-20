namespace cslab1.Classes
{
    public class MagazineListHandlerEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string ChangeType { get; set; }
        public int ElementIndex { get; set; }

        public MagazineListHandlerEventArgs(string name, string changeType, int elementIndex)
        {
            Name = name;
            ChangeType = changeType;
            ElementIndex = elementIndex;
        }

        public override string ToString()
        {
            return $"Name: {Name}, ChangeType: {ChangeType}, ElementIndex: {ElementIndex}";
        }
    }
}