# Discord-Queue-Bot
A discord bot for setting up a R6S '10-man' custom game. As of right now it involves queue commands as well as auto-teaming and auto-map pick.
This was created using the DSharp+ library (https://github.com/DSharpPlus/DSharpPlus)

Simply change the 'token' attribute in 'config.json' to your bots own token, then run the .exe and your bot will come online.

Default commands:
- !j = Joins the user to the queue
- !l = Removes the user to the queue
- !q = Lists all users currently in queue

Change log (31/12/2020):
- 1.0 released

To complete in the future:
- Cleanup code for efficiency and easy-reading (It is a mess in there right now!)
- Add permision based commands (!clear, !cancel, etc.)
- Purchase server space to have the .exe run 24/7
- Different queues for different servers (There is one, universal queue as of right now)
