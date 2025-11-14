using System.Xml;
namespace Mandatory;

public interface IConfigParser{
    Size ParseDimensions(XmlDocument configFile);
    GameDifficulty GetGameDifficulty(XmlDocument configFile);
}
