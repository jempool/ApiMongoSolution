namespace Api.Controllers
{
  public class AppError
  {
    public AppError(string error)
    {
      Error = error;
    }

    public string Error { get; set; }
  }
}