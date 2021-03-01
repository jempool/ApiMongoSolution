namespace Api.Config
{
  public class MongoSettings : IMongoSettings
  {
    public string Server { get; set; }
    public string Database { get; set; }
  }

  public interface IMongoSettings
  {
    string Server { get; set; }
    string Database { get; set; }
  }


}