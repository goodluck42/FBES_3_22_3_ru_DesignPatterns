using System.Text;
using System.Text.Json;


FileObject fileObject = new FileObject();

fileObject.Path = Console.ReadLine()!;
fileObject.Bytes = File.ReadAllBytes(fileObject.Path);


IFileStrategy currentStrategy = new JsonFileStrategy();
var viewModel = new ConsoleViewModel(currentStrategy);

viewModel.FileStrategy = currentStrategy;
viewModel.UploadFile(fileObject);


class FileObject
{
    public string Path { get; set; } = null!;
    public byte[] Bytes { get; set; } = null!;
}

interface IFileStrategy
{
    void SaveFile(FileObject fileObject);
}

class JsonFileStrategy : IFileStrategy
{
    public void SaveFile(FileObject fileObject)
    {
        var @object = new
        {
            content = Encoding.UTF8.GetString(fileObject.Bytes),
            extension = Path.GetExtension(fileObject.Path),
            size = fileObject.Bytes.Length
        };

        var result = JsonSerializer.Serialize(@object);
        var split = fileObject.Path.Split('.');

        split[^1] = "json";
        
        File.WriteAllText(string.Join('.', split), result);
    }
}

class ConsoleViewModel
{
    public IFileStrategy FileStrategy { get; set; }

    public ConsoleViewModel(IFileStrategy fileStrategy)
    {
        FileStrategy = fileStrategy;
    }

    public void UploadFile(FileObject fileObject)
    {
        if (s_AllowedExtensions.Contains(Path.GetExtension(fileObject.Path)))
        {
            FileStrategy.SaveFile(fileObject);
        }
    }

    private static readonly string[] s_AllowedExtensions = new[] { ".jpg", ".png" };
}