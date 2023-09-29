using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMagicBot
{
    public class LigaCommandsModule : ModuleBase<SocketCommandContext>
    {
        [Command("carta")]
        [Summary("Faz o bot repetir uma mensagem.")]
        public async Task ObterCartaCommand(params string[] carta)
        {
            var pesquisa = string.Empty;

            for (int i = 0; i < carta.Length - 1; i++)
            {
                pesquisa = pesquisa + "+" + carta[i] ;
            }
            // Responde à mensagem do usuário com o conteúdo fornecido.
            await ReplyAsync($"https://www.ligamagic.com.br/?view=cards%2Fsearch&card={pesquisa.Substring(1)}&tipo=1");
        }
    }
}
