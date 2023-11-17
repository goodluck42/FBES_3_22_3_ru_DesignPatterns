using System.Threading.Channels;
using CreationalPatterns.Builder;
using CreationalPatterns.Factory;
using CreationalPatterns.Singleton;


var builder = new PCBuilder();

builder.SetSocket("1155");
builder.SetGpu(6);
builder.SetPsu(600);
builder.SetSsd(500);
builder.SetRam(16);
builder.SetCpu(4);

var pc = builder.Build();

Console.WriteLine(pc.ToString());

// {
//
//
//     IItemFactory laptopFactory = new LaptopFactory();
//     IItemFactory phoneFactory = new PhoneFactory();
//
//     var items = new List<IItem>();
//
//     items.Add(laptopFactory.Create());
//     items.Add(phoneFactory.Create());
//
//     foreach (var item in items)
//     {
//         item.DisplayInfo();
//     }
// }