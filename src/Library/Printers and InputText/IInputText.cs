
namespace Battleship
{
    // Se crea interfaz en caso de que en el futuro haya una nueva forma de ingresar
    // información. Respetando el SRP
    public interface IInputText
    {
        public string Input();
    }
}