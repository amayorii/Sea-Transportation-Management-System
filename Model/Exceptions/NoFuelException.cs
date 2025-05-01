namespace Sea_Transportation_Management_System.Model.Exceptions
{
    class NoFuelException : Exception
    {
        public NoFuelException() { }

        public NoFuelException(string? message) : base(message) { }

        public NoFuelException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
