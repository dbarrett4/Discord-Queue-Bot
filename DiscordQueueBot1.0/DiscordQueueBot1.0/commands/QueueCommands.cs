using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DSharpPlus.Interactivity.Extensions;

namespace DiscordQueueBot1._0.commands
{
    public class QueueCommands : BaseCommandModule
    {
        public string Mention { get; }
        public DiscordMember Member { get; private set; }
        public DiscordUser User { get; private set; }
        string[] maps = new string[] { "Oregon", "Consulate", "Kafe Dostoyevsky", "Clubhouse", "Coastline", "Villa", "Theme Park" };
        public List<string> currentPlayers = new List<string>();
        public List<string> selectingPlayers = new List<string>();
        string queueNames, remainingPlayers, captainOne, captainTwo;
        public List<string> queue = new List<string>();
        Random rnd = new Random();
        public List<string> team1 = new List<string>();
        public List<string> team2 = new List<string>();
        string t1, t2, name;



        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }
        [Command("j")]
        [Description("Joins the queue")]
        public async Task Join(CommandContext ctx)
        {
            bool check = false;

            name = ctx.User.Username;
            for (int i = 0; i < queue.Count; i++)
            {
                if (name == queue[i])
                {
                    check = true;
                }
            }
            if (check == true)
            {
                await ctx.Channel.SendMessageAsync("```You are already in queue.```").ConfigureAwait(false);
            }
            else
            {
                queue.Add(name);
                await ctx.Channel.SendMessageAsync("```" + name + " has been added to the queue. Players in queue: " + queue.Count + "/10 ```");
                if (queue.Count == 10)
                {

                    await ctx.Channel.SendMessageAsync("```" + name + " has been added to the queue. Players in queue: " + queue.Count + "/10 ```");
                    if (queue.Count == 10)
                    {
                        string map = maps[rnd.Next(0, maps.Length)];
                        for (int i = 0; i < 5; i++)
                        {
                            int rand = rnd.Next(0, queue.Count);
                            team1.Add(queue[rand]);
                            queue.Remove(queue[rand]);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            int rand = rnd.Next(0, queue.Count);
                            team2.Add(queue[rand]);
                            queue.Remove(queue[rand]);
                        }
                        for (int i = 0; i < team1.Count; i++)
                        {
                            t1 = t1 + team1[i] + ", ";
                            t2 = t2 + team2[i] + ", ";
                        }
                        queue.Clear();
                        string outputOne = "Starting game..." + "\n" + "Map: " + map + "\n Team 1: " + t1 + "\n Team 2: " + t2;
                        await ctx.Channel.SendMessageAsync("```" + outputOne + "```").ConfigureAwait(false);
                        team1.Clear();
                        team2.Clear();
                    }
                }
            }
        }
        [Command("l")]
        [Description("Leaves the queue")]
        public async Task Leave(CommandContext ctx)
        {
            bool check = false;
            name = ctx.User.Username;
            for (int i = 0; i < queue.Count; i++)
            {
                if (name == queue[i])
                {
                    check = true;
                }
            }
            if (check == true)
            {
                queue.Remove(name);
                await ctx.Channel.SendMessageAsync("```You have been removed from the queue. Players in queue: " + queue.Count + "/10```").ConfigureAwait(false);
            }
            else if (check == false)
            {
                await ctx.Channel.SendMessageAsync("```You are not in the queue.```").ConfigureAwait(false);
            }
        }

        [Command("q")]
        public async Task Queue(CommandContext ctx)
        {
            for (int a = 0; a < queue.Count; a++)
            {
                queueNames = queueNames + queue[a] + ", ";
            }
            await ctx.Channel.SendMessageAsync("```" + queueNames + " : Players in queue: " + queue.Count + "/10```").ConfigureAwait(false);
            queueNames = "";
        }

    }
}
