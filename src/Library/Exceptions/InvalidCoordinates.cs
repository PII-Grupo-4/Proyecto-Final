using System;
namespace Battleship
{
    public class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException() { }
        public InvalidCoordinatesException(string message) : base(message) { }
        public InvalidCoordinatesException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCoordinatesException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}