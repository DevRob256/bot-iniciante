using System;
using Telegram.Bot;
using System.Threading;
using System.Threading.Tasks;


namespace Bot
{
    class Program
    {
        private static TelegramBotClient botClient = new TelegramBotClient("Seu Token Aqui");

        static void Main(string[] args)
        {
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"ID: {me.Id} \nNome do Bot: {me.FirstName} \n_"); //Exibe os resultados de login do bot

            botClient.OnMessage += BotClient_OnMessage;

            botClient.StartReceiving();
            Thread.Sleep(Timeout.Infinite);
            botClient.StopReceiving();
        }

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Console.WriteLine($"Mensagem recebida:{e.Message.Text} - de {e.Message.Chat.FirstName}");

            if (e.Message.Text.ToUpper() == "OI")
            {

            }


            string opcaoUsuario = e.Message.Text;

            switch (opcaoUsuario)
                {
                    case "1":
                        botClient.SendTextMessageAsync(
                            e.Message.Chat.Id,$"Olá! {e.Message.From.FirstName}, Você escolheu a opção Parcele Fácil");
                        break;
                    case "2":
                        botClient.SendTextMessageAsync(
                            e.Message.Chat.Id, $"Olá! {e.Message.From.FirstName}, Você escolheu a opção Crédito Pessoal");
                    break;
                    case "3":
                        botClient.SendTextMessageAsync(
                            e.Message.Chat.Id, $"Olá! {e.Message.From.FirstName}, Você escolheu a opção Pag Contas");
                    break;
                    case "4":
                        botClient.SendTextMessageAsync(
                            e.Message.Chat.Id, $"Olá! {e.Message.From.FirstName}, Você escolheu a opção Saque rápido");
                    break;
                    case "5":
                        botClient.SendTextMessageAsync(
                            e.Message.Chat.Id, $"Olá! {e.Message.From.FirstName}, Você escolheu a opção SMS Controle Total");
                    break;
                    case "6":
                        botClient.SendTextMessageAsync(
                            e.Message.Chat.Id, $"Olá! {e.Message.From.FirstName}, Você escolheu a opção Extravio do cartão");
                    break;
                    case "X":
                        botClient.SendTextMessageAsync(
                            e.Message.Chat.Id, $"Olá! {e.Message.From.FirstName}, Você escolheu Sair");
                    break;
                    default:
                        botClient.SendTextMessageAsync(
                        e.Message.Chat.Id,
                        $"Olá! {e.Message.From.FirstName}, Seja bem vindo ao atendimento virtual do Banco Carrefour!\n" +
                        $"Informe a opção desejada:\n" +
                        $"1- Parcele Fácil\n" +
                        $"2- Crédito Pessoal\n" +
                        $"3- Pag Contas\n" +
                        $"4- Saque rápido\n" +
                        $"5- SMS Controle Total\n" +
                        $"6- Extravio do cartão\n" +
                        $"X- Sair\n");
                    break;

            }

  

        }
    }
}

