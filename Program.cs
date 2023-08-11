using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using System;
using Telegram.Bot.Types.ReplyMarkups;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

public static partial class Program
{
    static void Main(string[] args)
    {
        var botClient = new TelegramBotClient("5926102033:AAF90dEFZjndNh3zh9tT4VDAweDG8ol6HHM");
        botClient.StartReceiving(Update, Error);

        Console.ReadLine();
    }

    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        var inlineKeyboard = new InlineKeyboardMarkup(new[]
        {
            new[] {InlineKeyboardButton.WithCallbackData("Погода на завтра", "weather")}
        });
        if (update.Message is not { } message)
            return;
        // Only process text messages
        if (message.Text is not { } messageText)
            return;
        var chatId = message.Chat.Id;
        await botClient.SendTextMessageAsync(chatId, "Нажмите на кнопку:", replyMarkup: inlineKeyboard);

    }
    async static Task Error(ITelegramBotClient botClien, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine(exception.Message);
        Console.WriteLine(exception.StackTrace);
    }
    
}
