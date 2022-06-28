using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
namespace CAH
{
    public class Telegram : ICanalMensaje
    {
        ITelegramBotClient client = TelegramBot.Instance.Client;
        private static Telegram instance;
        /// <summary>
        /// Metodo utilizado para crear y enviar un mensaje de texto por telegram.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        public void ArmarMensaje(string id, string text)
        {
            Mensaje mensaje = new Mensaje(id, text);
            Enviar(mensaje);
        }
        /// <summary>
        /// Metodo utilizado para mandar un texto por telegram
        /// </summary>
        /// <param name="mensaje"></param>
        public void Enviar(IMensaje mensaje)
        {
            client.SendTextMessageAsync(chatId: mensaje.Id,
                                        text: mensaje.Text);
        }
        /// <summary>
        /// Metodo utilizado para enviar una imagen por telegram.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stream"></param>
        public void EnviarImagen(string id, Stream stream)
        {
            client.SendPhotoAsync(chatId: id,
                                  photo: stream);
        }
        public static Telegram Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Telegram();
                }
                return instance;
            }
        }
    }
}