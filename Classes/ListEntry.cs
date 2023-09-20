﻿
namespace cslab1.Classes
{
    public class ListEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public int ElementIndex { get; set; }

        public ListEntry(string collectionName, string changeType, int elementIndex)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ElementIndex = elementIndex;
        }

        public override string ToString()
        {
            return $"CollectionName: {CollectionName}, ChangeType: {ChangeType}, ElementIndex: {ElementIndex}";
        }
    }
}
