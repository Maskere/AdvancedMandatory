using System.Xml;
namespace MandatoryGameframework;

public class FileLoader : IFileLoader {
    public XmlDocument Load(string filePath) {
        XmlDocument configDoc = GetConfigDoc(filePath);
        return configDoc;
    }

    private XmlDocument GetConfigDoc(string filePath){
        XmlDocument? configDoc = new();
        configDoc.Load(filePath);
        return configDoc;
    }
}
