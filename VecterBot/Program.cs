using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System;
using DSharpPlus;
using System.Globalization;


namespace MyFirstBot
{
    class Program
    {
        //info: my id: 683697713551769636
        //tarans id: 293132462907850753
        static WebClient client = new WebClient();
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
                if (e.Message.Content == "/vb topdog")
                {
                    bool killproc = false;
                    //level id is day+month+year, this is me getting these values and adding them
                    string currentDay = DateTime.Now.Day.ToString();
                    string currentMonth = DateTime.Now.Month.ToString();
                    string currentYear = DateTime.Now.Year.ToString();
                    string levelID = currentDay + currentMonth + currentYear;

                    //get data and make it look good
                    var stream = client.DownloadString("https://vecterapi.azurewebsites.net/api/GetLeaderboard?ga=bdc2a3ee3d8dca378d6f13e216e033a4a2b098713a4e7f2fa1d7a20175efeea3&level=" + levelID + "&callback=?");
                    stream = stream.Replace(",{\"position", ",\n{\"position");
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"/topdog.json", stream);

                    Thread.Sleep(300);
                    string[] topjson = File.ReadAllLines(Directory.GetCurrentDirectory() + @"/topdog.json");
                    string top7 = "";
                    foreach (var line in topjson)
                    {


                        if (line.Contains("{\"position\":8"))
                        {
                            killproc = true;
                        }
                        if (!killproc)
                        {
                            string posNum = line.Substring(line.IndexOf(",\"levelUnique") - line.IndexOf("\"position\":"), line.IndexOf(",\"levelUnique"));
                            posNum = posNum.Replace(":", "");
                            posNum = posNum.Replace(",\"levelUniqu", "");


                            string name = line.Substring(line.IndexOf("\"id\":"), line.IndexOf("\",\"registerdUserId") - line.IndexOf("\"id\":"));
                            name = name.Replace("\"id\":\"", "");

                            top7 += posNum + ".) " + name + "\n";

                        }

                    }
                    await e.Message.DeleteAsync();
                    if (topjson.Length < 7)
                    {
                        string topnum = "The current top " + (topjson.Length).ToString() + " in top dog are:";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, "---------------------------------\n" + top7 + "---------------------------------\n");
                        var emb = embuilder.Build();
                        await e.Message.RespondAsync("", false, emb);

                    }
                    else
                    {
                        string topnum = "The current top 7 in top dog are:";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, "---------------------------------\n" + top7 + "---------------------------------\n");
                        var emb = embuilder.Build();
                        await e.Message.RespondAsync("", false, emb);
                    }
                    Thread.Sleep(300);
                    if (File.Exists(Directory.GetCurrentDirectory() + "/topdog.json"))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "/topdog.json");
                    }

                }
                if (e.Message.Content == "/vb hardcore")
                {
                    bool killproc = false;
                    //level id is day+month+year, this is me getting these values and adding them
                    string currentDay = DateTime.Now.Day.ToString();
                    string currentMonth = DateTime.Now.Month.ToString();
                    string currentYear = DateTime.Now.Year.ToString();
                    string levelID = currentDay + currentMonth + currentYear;

                    //get data and make it look good
                    var stream = client.DownloadString("https://vecterapi.azurewebsites.net/api/GetLeaderboard?ga=bdc2a3ee3d8dca378d6f13e216e033a4a2b098713a4e7f2fa1d7a20175efeea3&level=55" + levelID + "&callback=?");
                    stream = stream.Replace(",{\"position", ",\n{\"position");
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"/hardcore.json", stream);

                    Thread.Sleep(300);
                    string[] topjson = File.ReadAllLines(Directory.GetCurrentDirectory() + @"/hardcore.json");
                    string top7 = "";
                    foreach (var line in topjson)
                    {


                        if (line.Contains("{\"position\":8"))
                        {
                            killproc = true;
                        }
                        if (!killproc)
                        {
                            string posNum = line.Substring(line.IndexOf(",\"levelUnique") - line.IndexOf("\"position\":"), line.IndexOf(",\"levelUnique"));
                            posNum = posNum.Replace(":", "");
                            posNum = posNum.Replace(",\"levelUniqu", "");


                            string name = line.Substring(line.IndexOf("\"id\":"), line.IndexOf("\",\"registerdUserId") - line.IndexOf("\"id\":"));
                            name = name.Replace("\"id\":\"", "");

                            top7 += posNum + ".) " + name + "\n";




                        }

                    }
                    await e.Message.DeleteAsync();
                    if (topjson.Length < 7)
                    {
                        string topnum = "The current top " + (topjson.Length).ToString() + " in harcore are:";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, "---------------------------------\n" + top7 + "---------------------------------\n");
                        var emb = embuilder.Build();
                        await e.Message.RespondAsync("", false, emb);

                    }
                    else
                    {
                        string topnum = "The current top 7 in hardcore are:";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, "---------------------------------\n" + top7 + "---------------------------------\n");
                        var emb = embuilder.Build();
                        await e.Message.RespondAsync("", false, emb);
                    }
                    Thread.Sleep(300);
                    if (File.Exists(Directory.GetCurrentDirectory() + "/hardcore.json"))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "/hardcore.json");
                    }

                }
                if (e.Message.Content == "/vb speeddemon")
                {
                    bool killproc = false;
                    //level id is day+month+year, this is me getting these values and adding them
                    string currentDay = DateTime.Now.Day.ToString();
                    string currentMonth = DateTime.Now.Month.ToString();
                    string currentYear = DateTime.Now.Year.ToString();
                    string levelID = currentDay + currentMonth + currentYear;

                    //get data and make it look good
                    var stream = client.DownloadString("https://vecterapi.azurewebsites.net/api/GetLeaderboard?ga=bdc2a3ee3d8dca378d6f13e216e033a4a2b098713a4e7f2fa1d7a20175efeea3&level=77" + levelID + "&callback=?");
                    stream = stream.Replace(",{\"position", ",\n{\"position");
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"/speeddemon.json", stream);

                    Thread.Sleep(300);
                    string[] topjson = File.ReadAllLines(Directory.GetCurrentDirectory() + @"/speeddemon.json");
                    string top7 = "";
                    foreach (var line in topjson)
                    {

                        if (topjson.Length < 8)
                        {

                        }
                        if (line.Contains("{\"position\":8"))
                        {
                            killproc = true;
                        }
                        if (!killproc)
                        {
                            string posNum = line.Substring(line.IndexOf(",\"levelUnique") - line.IndexOf("\"position\":"), line.IndexOf(",\"levelUnique"));
                            posNum = posNum.Replace(":", "");
                            posNum = posNum.Replace(",\"levelUniqu", "");


                            string name = line.Substring(line.IndexOf("\"id\":"), line.IndexOf("\",\"registerdUserId") - line.IndexOf("\"id\":"));
                            name = name.Replace("\"id\":\"", "");

                            top7 += posNum + ".) " + name + "\n";




                        }

                    }
                    await e.Message.DeleteAsync();
                    if (topjson.Length < 7)
                    {
                        string topnum = "The current top " + (topjson.Length).ToString() + " in speed-demon are:\n";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, "---------------------------------\n" + top7 + "---------------------------------\n");
                        var emb = embuilder.Build();
                        await e.Message.RespondAsync("", false, emb);


                    }
                    else
                    {
                        string topnum = "The current top 7 in speed-demon are:\n";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, "---------------------------------\n" + top7 + "---------------------------------\n");
                        var emb = embuilder.Build();
                        await e.Message.RespondAsync("", false, emb);
                    }
                    Thread.Sleep(300);
                    if (File.Exists(Directory.GetCurrentDirectory() + "/speeddemon.json"))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "/speeddemon.json");
                    }


                }
                if (e.Message.Content.StartsWith("/vb seed "))
                {
                    bool killproc = false;
                    string seed = e.Message.Content.Replace("/vb seed ", "");
                    if (seed == "")
                    {
                        e.Message.RespondAsync("um, you forgot to specify a seed :)");




                    }
                    else
                    {
                        var stream = client.DownloadString("https://vecterapi.azurewebsites.net/api/GetLeaderboard?ga=bdc2a3ee3d8dca378d6f13e216e033a4a2b098713a4e7f2fa1d7a20175efeea3&level=9" + seed + "&callback=?");
                        stream = stream.Replace(",{\"position", ",\n{\"position");
                        File.WriteAllText(Directory.GetCurrentDirectory() + @"/seed" + seed + ".json", stream);
                        Thread.Sleep(300);
                        string[] topjson = File.ReadAllLines(Directory.GetCurrentDirectory() + @"/seed" + seed + ".json");
                        string top7 = "";
                        try
                        {
                            foreach (var line in topjson)
                            {

                                if (topjson.Length < 8)
                                {

                                }
                                if (line.Contains("{\"position\":8"))
                                {
                                    killproc = true;
                                }
                                if (!killproc)
                                {
                                    string posNum = line.Substring(line.IndexOf(",\"levelUnique") - line.IndexOf("\"position\":"), line.IndexOf(",\"levelUnique"));
                                    posNum = posNum.Replace(":", "");
                                    posNum = posNum.Replace(",\"levelUniqu", "");

                                    string name = line.Substring(line.IndexOf("\"id\":"), line.IndexOf("\",\"registerdUserId") - line.IndexOf("\"id\":"));
                                    name = name.Replace("\"id\":\"", "");

                                    top7 += posNum + ".) " + name + "\n";
                                }

                            }
                            if (topjson.Length < 7)
                            {
                                
                                string topnum = "The current top " + (topjson.Length).ToString() + " in your seed are:";
                                var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                                embuilder.AddField(topnum, "---------------------------------\n" + top7 + "---------------------------------\n");
                                var emb = embuilder.Build();
                                await e.Message.RespondAsync("", false, emb);
                            }
                            else
                            {
                                string topnum = "The current top 7 in your seed are:";
                                var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                                embuilder.AddField(topnum, "---------------------------------\n" + top7 + "---------------------------------\n");
                                var emb = embuilder.Build();
                                await e.Message.RespondAsync("", false, emb);
                            }
                            Thread.Sleep(300);
                            if(File.Exists(Directory.GetCurrentDirectory() + "/seed" + seed + ".json"))
                            {
                                File.Delete(Directory.GetCurrentDirectory() + "/seed" + seed + ".json");
                            }
                        }
                        catch
                        {
                            await e.Message.RespondAsync("oops, your seed gave no results!");
                        }
                    }
                }

                    async Task PrintHelp()
                    {
                        var help = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        help.AddField("Available Commands:", "all commands start with \"/vb\"\n---------------------------------\n/vb help\n/vb topdog\n/vb hardcore\n/vb speeddemon\n/vb seed [ your seed ]\n---------------------------------");
                        var helpEm = help.Build();
                        await e.Message.RespondAsync("", false, helpEm);
                    }
                };
                await discord.ConnectAsync();
                await Task.Delay(-1);
            }
        
       
    }
}