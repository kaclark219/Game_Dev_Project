INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} Oh, hello there. My name is Gerald. I was really hoping I'd run into you at some point.. this is perfect!
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Suspicious")} Run into me? Why? Is something wrong?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} No, nothing's wrong! I just wanted to chat with you a bit about your health.
* [I'd like to hear more.] -> Interested
* [I'm not interested.] -> NotInterested

=== Interested ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Huh, I guess. Could you tell me a little more about what you mean by that?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Not a problem! I run the clinic in town, so I just wanted to touch base with you to see if you've been feeling alright with the stress and physical labor of your recent move.
* [Feeling fine!] -> Fine
* [Not so good.] -> NotFine

=== NotInterested ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Suspicious")} I don't really need whatever you're trying to sell me, sorry. I'm just not interested.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} If that's what you think, that's fine. Just thought it would be nice of me to see how you're feeling after such a big move, being the town's doctor and all. But you have a good rest of your day.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Yikes. That was not a great first impression. #thought
~GeraldTrust -= 10
-> END

=== Fine ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} I've been feeling great! It's nice to get a change of scenery, and I'm happy to have a more spacious property for my flowers.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} That's great to hear! Just know, if you're ever feeling exhausted you can stop by the clinic and check in with me. I'll be working there pretty often throughout the week. Well, anyway, that's all I wanted to say. Have a good one!
~GeraldTrust += 10
-> END

=== NotFine ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Actually, I haven't been feeling that well. I guess the exhaustion from the move really got to me.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} That's not great to hear. Just know, if you're ever feeling exhausted you can stop by the clinic and check in with me for some help. I'll be working there pretty often throughout the week, so make sure to take a few minutes to visit me. I have to get going now, but I hope you're feeling better soon!
~GeraldTrust += 10
-> END