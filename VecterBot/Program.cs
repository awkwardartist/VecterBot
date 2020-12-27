using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;

namespace MyFirstBot
{
    class Program
    {
        //info: my id: 683697713551769636
        //tarans id: 293132462907850753
        static HttpClient client = new HttpClient();
        static DiscordClient discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = "NzkyNTIwOTkxNjMyNzg1NDQ4.X-e6sA.Xb9p5A47SDBTyzhn7ARVkEThifA",
            TokenType = TokenType.Bot
        });
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            //called whenever message created
            discord.MessageCreated += async (e) =>
            {
                if (e.Message.Content == "/vb help")
                {
                    await PrintHelp();
                }
                if(e.Message.Content == "/vb topdog")
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + "/topdogcurrently.txt", File.ReadAllText("http://vecter.online/leaderboard.html"));
                    
                }
                async Task PrintHelp()
                { 
                    var help = new DSharpPlus.Entities.DiscordEmbedBuilder();
                    help.AddField("Available Commands:", "all commands start with \"/vb\"\n---------------------------------\n/vb help\n---------------------------------");
                    var helpEm = help.Build();
                    await e.Message.RespondAsync("", false, helpEm);
                }
            };
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
        
       
    }
}