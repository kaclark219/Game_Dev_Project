INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")}
Oh... hey.
* [Introduce yourself.] -> IntroduceYourself
* [Nod.] -> Nod

== Nod ==
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} You nod in his direction and feel comfortable in the silence. #thought
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} He nods back appreciatively. #thought
~SebastianTrust += 10
-> END

== IntroduceYourself ==
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Happy")} Hi! It's nice to meet you!
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} He turns away from you and sighs. #thought
~SebastianTrust -= 10
-> END