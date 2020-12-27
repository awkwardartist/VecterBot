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
        
        static WebClient client = new WebClient();
        static DiscordClient discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = Environment.GetEnvironmentVariable("BOT_TOKEN"),
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
                    var stream = client.DownloadString(Environment.GetEnvironmentVariable("APIURL") + levelID + "&callback=?");
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

                            top7 += "asc\n" + posNum + ".) " + name + "\n";

                        }

                    }
                    
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
                    var stream = client.DownloadString(Environment.GetEnvironmentVariable("APIURL") +"55" + levelID + "&callback=?");
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

                            top7 += "asc\n" + posNum + ".) " + name + "\n";




                        }

                    }
                    
                    if (topjson.Length < 7)
                    {
                        string topnum = "The current top " + (topjson.Length).ToString() + " in harcore are:";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, top7);
                        var emb = embuilder.Build();
                        await e.Message.RespondAsync("", false, emb);

                    }
                    else
                    {
                        string topnum = "The current top 7 in hardcore are:";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, top7);
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
                    var stream = client.DownloadString(Environment.GetEnvironmentVariable("APIURL") + "77" + levelID + "&callback=?");
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
                    //bruh
                    
                    if (topjson.Length < 7)
                    {
                        string topnum = "The current top " + (topjson.Length).ToString() + " in speed-demon are:\n";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        embuilder.AddField(topnum, top7);
                        var emb = embuilder.Build();
                        await e.Message.RespondAsync("", false, emb);


                    }
                    else
                    {
                        string topnum = "The current top 7 in speed-demon are:\n";
                        var embuilder = new DSharpPlus.Entities.DiscordEmbedBuilder();
                        top7 = "```" + top7 + "```";
                        embuilder.AddField(topnum, top7);
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
                        var stream = client.DownloadString(Environment.GetEnvironmentVariable("APIURL") + "9" + seed + "&callback=?");
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

                                    top7 += "asc\n" + posNum + ".) " + name + "\n";
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