
using cslab1.Classes;

MagazineCollection firstCollection = new MagazineCollection();
firstCollection.CollectionName = "First Collection";
MagazineCollection secondCollection = new MagazineCollection();
secondCollection.CollectionName = "Second Collection";

Listener firstListener = new Listener();
Listener secondListener = new Listener();

firstCollection.MagazineReplaced += firstListener.EventHandler;
secondCollection.MagazineAdded += secondListener.EventHandler;

firstCollection.AddDefaults();
firstCollection.Replace(0, new Magazine());
firstCollection[1] = new Magazine();

secondCollection.AddDefaults();
secondCollection.AddMagazines(new Magazine());

Console.WriteLine("===========LISTENERS OUTPUT===========");
Console.WriteLine(firstListener.ToString());
Console.WriteLine(secondListener.ToString());

