using System;
using Telegram.Bot;
using System.Threading;
using System.Threading.Tasks;

namespace Bot
{
    class Program
    {

        private static TelegramBotClient botClient = new TelegramBotClient("1162273722:AAEujxDDurLW-mMBZnlJOm0pKBd8izqenqQ");

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
                    e.Message.Chat.Id,
                    $"Olá {e.Message.From.FirstName}, tudo bem! Seu ID é {e.Message.From.Id} "
                    );

            }


        }
    }
}
