namespace pessoas_api.Exceptions
{
    public class NotSavedToDatabaseException : Exception
    {
        public NotSavedToDatabaseException(string message) : base(message)
        {
        }

    }
}
