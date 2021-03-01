using System;

namespace Api.Services.Exceptions
{
  public class AlreadyExistsException : Exception
  {
    public AlreadyExistsException(string message) : base(message)
    {
    }
  }
}