
namespace Battleship
{
    // Se crea interfaz en caso de que en el futuro haya una nueva forma de imprimir
    // información. Respetando el SRP
    public interface IPrinter
    {
        public void Print(string textToPrint);
    }
}