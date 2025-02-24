INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Poppy", "Right", "Normal")} Good arvo! What can I do for ya?
* [Arvo?] -> Huh
* [Just wanted to introduce myself.] -> Slang

=== Huh ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Sorry, what? What does "arvo" mean?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Ah, I forget not everyone's used to my dialect. It's just short for "afternoon" where I'm from.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Huh, okay. Well, good afternoon to you too, I guess. I just wanted to check in and introduce myself, I'm {PlayerName}.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} It's good to meet you, {PlayerName}. I run the pub in town, my name is Poppy. I'll probably catch you around, mate.
-> END

=== Slang ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Good afternoon to you, too! I was just going around introducing myself. I just moved in, I'm {PlayerName}.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Well that's might nice of you to do! We've been excited for some fresh meat in town.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Suspicious")} We? Like everyone in town?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Oh, no, I should've been a tad more clear. Linda told me all about you when you wrote her about renting that property on the edge of town, so her and I have been itching to meet you. Not that the rest of the townsfolk aren't buzzing, I just can't speak for them.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Ah, okay. Well, it was very nice speaking to you .. Sorry I forgot to ask, what's your name?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} No problem at all! I'm Poppy, I'm in charge of the pub here. You have a good one, mate.
~PoppyTrust += 10
-> END