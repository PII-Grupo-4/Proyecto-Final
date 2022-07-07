using System;
using System.Collections.Generic;


namespace Battleship
{
    /// <summary>
    /// 
    /// </summary>
    public class CountCaracters
    {
        public int contadoragua;

        public int contadortiros;


        public int ObtenerCantCaracter()
        {
            private Board RegisterBoard = new Board();

            RegisterBoard = Player.GetRegisterBoard();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (RegisterBoard [i,j] == "o")
                    {
                        contadoragua += 1;
                    }
                    if (RegisterBoard [i,j] == "x" && RegisterBoard [i,j] == "#")
                    {
                        contadortiros += 1;
                    }
                }
                     
            }
        }

    }
}