using System;
using Telegram.Bot;


namespace bot
{
    class Program
    {

        static TelegramBotClient botClient = new TelegramBotClient("SEU API TOKEN AQUI");
        static void Main(string[] args)
        {
            botClient.OnMessage += BotClient_OnMessage;
            botClient.OnUpdate += BotClient_OnUpdate;
            botClient.StartReceiving();
            Console.ReadLine();
        }

        private static void BotClient_OnUpdate(object sender, Telegram.Bot.Args.UpdateEventArgs e)
        {
            if (e.Update.ChannelPost != null)
            {
                Console.WriteLine("Mensagem recebida no canal: " + e.Update.ChannelPost.Text);

                var channelChatId = e.Update.ChannelPost.Chat.Id;
                var messageId = e.Update.ChannelPost.MessageId;

                //Substituir o -00000 pelo id do chat que vc deseja encaminhar a mensagem
                botClient.ForwardMessageAsync("-00000000", channelChatId, messageId);
                                                              
            }
        }

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine(e.Message.Text);
                Console.WriteLine("O ID do chat é:" + e.Message.Chat.Id);

                if (e.Message.Text.ToUpper() == "OI")
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, "E ai, blz? O seu ChatID é " + e.Message.Chat.Id);
                }
            }
            
        }
    }
}




