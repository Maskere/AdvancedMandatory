using System.Xml;
namespace MandatoryGameframework;

public interface IConfigParser{
    Size ParseDimensions(XmlDocument configFile);
    GameDifficulty GetGameDifficulty(XmlDocument configFile);
}
