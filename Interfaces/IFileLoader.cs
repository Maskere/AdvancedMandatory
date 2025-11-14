using System.Xml;
namespace Mandatory;

public interface IFileLoader{
    XmlDocument Load(string filePath);
}
