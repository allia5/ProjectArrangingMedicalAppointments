namespace Server.Models.Exceptions
{
    public class FailedCreateUserException : Exception
    {
        public FailedCreateUserException(string parameterName, string actor)
            : base(message: $"{actor}, he is Not Allowed In System ")
        { }
    }
}
