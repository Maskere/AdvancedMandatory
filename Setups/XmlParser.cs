using System.Xml;
namespace Mandatory;

public class XmlParser : IConfigParser{
    public Size ParseDimensions(XmlDocument configFile) {
        Size worldDimension = new(0,0);
        XmlNode? worldWidthNode = GetSingleNode(configFile,"//WorldWidth");
        XmlNode? worldHeightNode = GetSingleNode(configFile,"//WorldHeight");

        if(worldWidthNode != null && worldHeightNode != null){
            string gridWidthStr = worldWidthNode.InnerText.Trim();
            string gridHeightStr = worldHeightNode.InnerText.Trim();

            bool foundWidth = int.TryParse(gridWidthStr,out int worldWidth);
            bool foundHeight = int.TryParse(gridHeightStr,out int worldHeight);

            if(foundWidth && foundHeight){
                worldDimension.X = worldWidth;
                worldDimension.Y = worldHeight;
                return worldDimension;
            }
            else{
                throw new ArgumentException("Could not parse 'WorldWidth' and/or 'WorldHeight' from config file");
            }
        }
        else{
            throw new ArgumentException($"Could not find WorldWidth and WorldHeight from {configFile}"); 
        }
    }

    public GameDifficulty GetGameDifficulty(XmlDocument configFile){
        XmlNode? gameDifficultyNode = GetSingleNode(configFile,"//GameDifficulty");

        if(gameDifficultyNode != null){
            string gameDifficultyStr = gameDifficultyNode.InnerText.Trim();

            switch(gameDifficultyStr){
                case "Easy":
                    return GameDifficulty.Easy;
                case "Medium":
                    return GameDifficulty.Medium;
                case "Hard":
                    return GameDifficulty.Hard;
            }
        }

        return GameDifficulty.None;
    }

    private XmlNode? GetSingleNode(XmlDocument configDoc,string node){
        return configDoc.DocumentElement?.SelectSingleNode(node);
    }
}
