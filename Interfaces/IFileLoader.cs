using System.Xml;
namespace MandatoryGameframework;

public interface IFileLoader{
    XmlDocument Load(string filePath);
}
