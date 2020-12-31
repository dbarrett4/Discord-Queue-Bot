using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace DiscordQueueBot1._0
{
    public class DiscordUser : SnowflakeObject
    {
        public string Mention { get; }
        public virtual string Username { get; private set; }
        public virtual string Discriminator { get; }
        public ulong DiscordId { get; set; }
        public ulong GuildId { get; set; }
    }
}