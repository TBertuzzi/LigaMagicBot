using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LigaMagicBot
{
    internal class Program
    {
        private DiscordSocketClient _client;
        private IServiceProvider _services;

        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.RunBotAsync();
        }


        public async Task RunBotAsync()
        {

            _services = new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<HttpClient>()
                .BuildServiceProvider();


            _client = _services.GetRequiredService<DiscordSocketClient>();
            _client.Log += LogAsync;

            await _client.LoginAsync(TokenType.Bot, "BOT TOKEN");
            await _client.StartAsync();

            await _services.GetRequiredService<CommandHandlingService>().InitializeAsync();

            await Task.Delay(-1);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }

    }
}