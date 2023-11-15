using CreationalPatterns.Factory;
using CreationalPatterns.Singleton;

IItemFactory laptopFactory = new LaptopFactory();
IItemFactory phoneFactory = new PhoneFactory();

var items = new List<IItem>();

items.Add(laptopFactory.Create());
items.Add(phoneFactory.Create());

foreach (var item in items)
{
    item.DisplayInfo();
}
