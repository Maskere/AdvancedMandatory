using System.Xml;
namespace MandatoryGameframework;

public class ConfigFileReader : IConfigFileReader{
    private IFileLoader fileLoader;
    private IConfigParser parser;

    private readonly string filePath;

    public ConfigFileReader(IFileLoader fileLoader, IConfigParser parser, string filePath){
        this.filePath = filePath;
        this.fileLoader = fileLoader;
        this.parser = parser;
    }

    public void GetWorldDimensions(out Size worldDimension){
        XmlDocument? configDoc = null;
        try{
            configDoc = fileLoader.Load(filePath);
        }
        catch(FileNotFoundException ex){
            throw new Exception(ex.Message);
        }

        try{
            worldDimension = parser.ParseDimensions(configDoc);
        }
        catch(FileNotFoundException){
            worldDimension = new(0,0);
        }
    }

    public GameDifficulty GetGameDifficulty(){
        try{
            XmlDocument configFile = fileLoader.Load(filePath);
            return parser.GetGameDifficulty(configFile);
        }
        catch(FileNotFoundException){
            return GameDifficulty.None;
        }
    }
}
