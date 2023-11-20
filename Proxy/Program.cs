using Proxy;

var file = new MyFile()
{
    Text = "some data",
    Name = "data",
    Extension = ".txt"
};


var proxy = new ProxyRepository(new MemoryRepository());

proxy.AddFile(file);


var result = proxy.GetFileByName("data");
result = proxy.GetFileByName("data");


if (result != null)
{
    Console.WriteLine($"Text: {result.Text}");
}