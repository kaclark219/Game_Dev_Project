INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} You're the new person in town? Huh. I thought you'd look a little tougher, moving in by yourself and all.
* [Excuse me?] -> Aggressive
* [I'm tougher than I look.] -> StandUp

=== Aggressive ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Suspicious")} Sorry? What's that even supposed to mean? And why do you even know that I moved in by myself? That's unsettling.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Calm down there, kid. It was friendly banter. Kids these days can't even take a little messing around! Ridiculous.
~BruceTrust -= 10
-> END

=== StandUp ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Suspicious")} I'll have you know that I'm a lot tougher than I look. I do just fine on my own, not that it's any of your business.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} HAHAHAA! That's the kind of spirit I like to see. You know, kid, I think you might enjoy hunting or practicing fire starting with me sometime.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} I'm not sure that's something I'd enjoy, but thank you for the offer?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Well, just let me know after you think about it for a bit. Bruce here'll teach you everything you need to know.
~BruceTrust += 10
-> END