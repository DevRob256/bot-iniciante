using System;
using Telegram.Bot;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace Bot
{
    class Program
    {

        private static TelegramBotClient botClient = new TelegramBotClient("SEU TOKEN AQUI");

        static void Main(string[] args)
        {
            botClient.OnMessage += BotClient_OnMessage;

            botClient.StartReceiving();
            Thread.Sleep(Timeout.Infinite);
            botClient.StopReceiving();
        }

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Console.WriteLine(e.Message.Text);

            if(e.Message.Text.ToUpper()=="OI")
            {
                botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: $"<a href =\"http://www.google.com.br\">Clique aqui</a>",
                    parseMode: ParseMode.Html
                    );
            }

        }
    }
}
