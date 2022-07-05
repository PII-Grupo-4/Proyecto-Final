using System;

namespace Battleship
{
    /// <summary>
    /// Excepción que se encarga de notificar cuando una coordenada ingresada tiene un formato incorrecto
    /// </summary>
    [Serializable]
    internal class IncorrectFormatException : Exception
    {
        public IncorrectFormatException()
        {
        }

    }
}