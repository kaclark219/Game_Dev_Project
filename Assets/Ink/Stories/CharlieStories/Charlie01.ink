INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} Hey, there! So you just moved in, huh? Have any extra moving boxes laying around?
* [Yes.] -> YesBoxes
* [No.] -> NoBoxes

=== YesBoxes ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Um .. I guess? Do you need them or something? You're kind of quick to ask me a favor.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} Well, I guess you couldn't tell by my outfit, but I was offering to help you get rid of them. Y'know? Sanitation? It's kind of my job.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Oh, I'm sorry. I didn't mean to assume anything.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Don't worry too much about it. Anyway, I'm Charlie. I'll see you around, alright?
~CharlieTrust -= 10
-> END

=== NoBoxes ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} No, I took care of them when I was cleaning up around the house. Why do you ask?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Oh, nice! I was just going to offer to help out. My neighborly duty, y'know? And also my job I get paid for, I guess.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Happy")} That's so nice of you to offer! I'm {PlayerName}, I hope to see you around.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} No, problem! I'll see you! Oh, and I'm Charlie by the way. Bye again!
~CharlieTrust += 10
-> END