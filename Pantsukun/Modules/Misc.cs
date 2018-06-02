using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Pantsukun.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("echo")]                           
        public async Task Echo([Remainder]string message)  
        {
            var embed = new EmbedBuilder();         
            embed.WithTitle("Echoed messaged by " + Context.User.Username);
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));  

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("choose")]                           
        public async Task choose([Remainder]string message)
        {
            string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);  

            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle("Choice for " + Context.User.Username);
            embed.WithDescription(selection);
            embed.WithColor(new Color(0, 255, 0));
            embed.WithThumbnailUrl("https://s-media-cache-ak0.pinimg.com/originals/b2/23/18/b22318a9a6850a5c4de6cf530f499bef.jpg");

            

            await Context.Channel.SendMessageAsync("", false, embed);
            DataStorage.AddPairToStorage(Context.User.Username + DateTime.Now.ToShortTimeString(), selection);                 
        }

        //---------------------------------------------------------------------------

        [Command("secret")]
        //[RequireUserPermission(GuildPermission.Administrator)]              //The User who calls this permission needs the guilds permission to use this command
        public async Task RevealSecret([Remainder]string arg = "")
        {
            if (!UserIsEveryone((SocketGuildUser)Context.User))
            {
                await Context.Channel.SendMessageAsync(":x: You do not have the permission to do that");
                    return;
            }
            var dmChannel = await Context.User.GetOrCreateDMChannelAsync();             //Messages the person in DM
            await dmChannel.SendMessageAsync(Utilities.GetAlert("SECRET"));             //Private Message
            //await Context.Channel.SendMessageAsync(Utilities.GetAlert("SECRET"));       //Using the Alerts.  
        }

        private bool UserIsEveryone(SocketGuildUser user)               //will be not that efficient on bigger servers
        {

            //user.Guild.Roles
            string targetRoleName = "Everyone";
            var result = from r in user.Guild.Roles         //from something called r which is everything inside user.Guild.Roles (list of roles from guilds) we want to find those roles
                         where r.Name == targetRoleName     //that their name is equal to targetRoleName
                         select r.Id;                       //we want to select their ID
            ulong roleID = result.FirstOrDefault();         //If you have a list of one or 20 Ids, it selects the first one
            if (roleID == 0) return false;                  //doesnt mean the user doesnt have the role, it means the role wasn't found
            var targetRole = user.Guild.GetRole(roleID);
            return user.Roles.Contains(targetRole);

            /*foreach(var role in user.Roles)             //Being able to use all role permissions
            {
                role.
            }*/
        }

        //---------------------------------------------------------------------------

        [Command ("data")]
        public async Task GetData()
        {
            await Context.Channel.SendMessageAsync("Data Has " + DataStorage.GetPairsCount() + " pairs.");
            DataStorage.AddPairToStorage("Count" + DataStorage.GetPairsCount(), "TheCount" + DataStorage.GetPairsCount());
        }
        
        
        //---------------------------------------------------------------------------

        [Command("quotes")]
        public async Task quotes(string message)
        {
            string[] randomtexto;

            Random randi;
            randi = new Random();

            randomtexto = new string[]
                {

                        "We all make choices in life, but in the end our choices make us.",
                        "Get over here!",
                        "What is better? To be born good or to overcome your evil nature through great effort?",
                        "The right man in the wrong place can make all the difference in the world.",
                        "Bring me a bucket, and I'll show you a bucket!",
                        "A hero need not speak. When he is gone, the world will speak for him.",
                        "Nothing is true, everything is permitted.",
                        "It’s dangerous to go alone, take this!",
                        "AAAAAAAAAAAAHHHRHGHHHGH thump",
                        "Endure and survive.",
                        "You can’t undo what you’ve already done, but you can face up to it.",
                        "I miss the internet",
                        "Stay awhile, and listen!",
                        "Thank you Mario! But our Princess is in another castle!",
                        "What is a man? A miserable little pile of secrets.",
                        "My brothers and sisters... I will see you again. Someday. You've given them back to me.",
                        "Snake? Snake? SNAAAAAAAAKE!!!",
                        "Wake me when you need me.",
                        "Grass grows, birds fly, sun shines, and brother, I hurt people.",
                        "It’s super effective!",
                        "The Kid just rages for a while.",
                        "Space. Space. I'm in space. SPAAAAAAACE!",
                        "Do a barrel roll!",
                        "No matter how dark the night, morning always comes, and our journey begins anew.",
                        "Hope is what makes us strong. It is why we are here. It is what we fight with when all else is lost.",
                        "Science isn’t about why! It’s about why not!",
                        "Stop right there, criminal scum!",
                        "There was a HOLE here. It's gone now.",
                        "I don’t want to set the world on fire…",
                        "Hard to see big picture behind pile of corpses.",
                        "Does this unit have a soul?",
                        "You are not a good person. You know that, right? Good people don't end up here.",
                        "I raised you, and loved you, I've given you weapons, taught you techniques, endowed you with knowledge. There's nothing more for me to give you. All that's left for you to take is my life.",
                        "Are you a boy or a girl?",
                        "Praise the sun!",
                        "Send me out...with a bang.",
                        "You have died of dysentery.",
                        "Do you like hurting other people?",
                        "YOU DIED",
                        "This is the end.",
                        "crashed a scene",
                        "yummy stole a tornado",
                        "qq",
                        "p2w",
                        "nerf rg",
                        "Rubbing nipples",
                        "CHAPTER 10?! \n no.",
                        "Snek",
                        "Cookie",
                        "9p",
                        "I need a break ;_; Help me PLS ;_;",
                        "exploring the world!",
                        "Oh! Another Tai Chi RE x3",
                        "MD bugged again",
                        "Di is down again",
                        "Oh all instances are down.. damn..",
                        "It smells like REs are raining today",
                        "Todays weather in Wulin: Salty Drama",
                        "Pbi set",
                        "Don't forget to do Exploring the World ; ^)",
                        "Don't forget to do the daily p2w TP 0:",
                        "Food",
                        "I'm Hungry ;--;",
                        "Steamed Bread",
                        "Crab.",
                        "Can someone give me 10d for wedding pls? ;_;",
                        "Free slaps for everyoneeeeee o/",
                        "It's a *stunning* day! ; ^)",
                        "Did you feel the paaaaain?",
                        "(╯°□°）╯︵ ┻━┻",
                        "┬─┬﻿ ノ( ゜-゜ノ)",
                        "this game is not for 1-1, unless i am being ganked",
                        "You're unlucky today! You're getting ganked :P prepare!",
                        "REMMBER \n IN GNAK DIE ANY ONE",
                        " : ^)",
                        "chinagame.exe",
                        "pk once -> get attacked by the whole guild",
                        "Fixed 10 bugs -> 15 new bugs appeard",
                        "where is my RE =.=",
                        "where is my loot =.=",
                        "wasted 10d for praying",
                        "an enemy stole your 8d scenery",
                        "ping2win",
                        ")))))))",
                        "failed kidnapping 3rd time in a row",
                        "people die if they are killed",
                        "no talk in raid chat",
                        "no chat pls",
                        "hug spam?",
                        "you clown! me clown! everybody clown!",
                        "I AM THE MUSTARD OF YOUR DOOM!",
                        "you better stand back mister cos i'm about to slash ... all my prices",
                        "there are two ways this can go down, and in both of them, you die!",
                        "it was mating season, how was i to know she was your sister?",
                        "And remember, the safety word is Banana.",
                        "Whoops, seems like the quote was to edgy to return",
                        "Spies? Sappin' my sentry?"

                 };

            //if (Context.Message.Content == ("quotes"))
            //{
            int randomTextp = randi.Next(randomtexto.Length);
            string textToPost = randomtexto[randomTextp];
            await Context.Channel.SendMessageAsync(textToPost);
            //}
        }

        //---------------------------------------------------------------------------

        [Command("ping")]
        public async Task ping([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         //Puts the message in a Box
            embed.WithTitle("pong");
            embed.WithImageUrl("https://cdn.discordapp.com/attachments/181000288050741248/419541586926501888/pong.gif");
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  // Box Color
            

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("inv")]
        public async Task inv([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         
            embed.WithTitle((Utilities.GetAlert("INVITE") + "\n No Available Discord invite link"));
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("banhammer")]
        public async Task banhammer([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         
            embed.WithImageUrl("https://cdn.discordapp.com/attachments/181000288050741248/419547980740165632/BanhammerChan.png");
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("shh")]
        public async Task shh([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         
            embed.WithImageUrl("https://cdn.discordapp.com/attachments/206693977943048192/419548617611673612/hqg-2417.gif");
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("god")]
        public async Task god([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         
            embed.WithTitle(Utilities.GetAlert("GOD"));
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("lag")]
        public async Task lag([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         
            embed.WithTitle(Utilities.GetAlert("LAG"));
            embed.WithImageUrl("https://cdn.discordapp.com/attachments/206693977943048192/419549444380426240/solidsnake.png");
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("snek")]
        public async Task snek([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         
            embed.WithImageUrl("https://cdn.discordapp.com/attachments/206693977943048192/419549670562463754/snek.jpg");
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("de-bug")]
        public async Task debug([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         
            embed.WithTitle(Utilities.GetAlert("BUG"));
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("emei")]
        public async Task emei([Remainder]string arg = "")
        {
            var embed = new EmbedBuilder();         
            embed.WithImageUrl("https://cdn.discordapp.com/attachments/206693977943048192/419551141974507530/emei.png");
            embed.WithDescription(arg);
            embed.WithColor(new Color(0, 255, 0));  


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        //---------------------------------------------------------------------------

        [Command("halp")]
        public async Task halp([Remainder]string arg = "")
        {
            var dmChannel = await Context.User.GetOrCreateDMChannelAsync();             //Messages the person in DM
            await dmChannel.SendMessageAsync(Utilities.GetAlert("HELP"));             //Private Message
        }

    }
}
