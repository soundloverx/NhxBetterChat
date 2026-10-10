# NhxBetterChat

A private mod for personal use with friends - not published on Thunderstore.

Normal chat messages are sent to every player in the world instead of only players nearby. They get a timestamp in the chat window, other players' messages play a short sound, and messages that arrive while you're respawning aren't lost.

This is the World Chat feature of **NhxQualityPack**, split out into a small mod of its own so it can be used alongside other mods, as a replacement for Crystal's **BetterChat**. Don't install it together with either of them: NhxBetterChat won't load while NhxQualityPack or BetterChat is installed.

## Features

Everything below is on by default. The `World Chat` config setting turns it all off, which leaves chat exactly as in the unmodded game.

- Messages look like the game's normal chat: normal case and colour, and no marker on the map. `/s` shouts are sent the same way, so they look like any other message
- The floating text follows the sender's head, or sits at the edge of the screen when they're out of view, without drifting upwards
- The sender's name is added in front of the floating text when they're further away than normal chat reaches (15 m) or out of view, so it's clear who said it. If they're too far away to be loaded, the text stays where they were standing when they spoke
- A map ping and a chat message from the same player both stay up, instead of one replacing the other
- Chat messages in the chat window start with the local time they arrived, in 24-hour format (e.g. `[14:05:32]`)
- A short sound plays when another player's chat message appears in the chat window (your own messages are silent). It follows the game's sound effects volume, messages shown together play it only once, and it can be turned off with the `Chat Sound Alert` config setting
- Chat messages that arrive while you're respawning after a death, loading into the world, or watching the arrival intro are kept and shown in the chat window once you're back, instead of being lost (vanilla discards them). Up to 50 messages are kept. Nearby-only chat from players who have World Chat turned off, or don't have this mod, can't be kept this way
- Messages that arrive while the screen is dark - lying dead, going through a portal, or sleeping - show up as usual, and the chat window pops open again once you can see, so they aren't missed behind the loading screen
- Whispers (`/w`) are unchanged

## Differences From BetterChat

BetterChat lets normal chat reach further (its `TalkDistance`, up to 100 m) and adds options for the chat window. NhxBetterChat sends chat to the whole world instead, and leaves the chat window and its keys as they are in the game.

- Normal chat reaches every player in the world, however far away
- `/s` shouts never put a marker on anyone's map, since they're sent like normal chat (BetterChat's `ShowShoutPings` only hid them on your own map)
- Shouts keep the case they were typed in, like BetterChat's default `ForceCase = false`. Whispers are lowercase, as in the game
- Added: timestamps, the sound alert, messages kept while respawning, the sender's name on far-away floating text, and map pings and chat no longer replacing each other
- Not carried over: `/` opening the chat window (`SlashOpensChat`), shouting by default (`DefaultShout`), the chat window settings (`AlwaysVisible`, `HideDelay`, `ShowOnNewMessage`) and the whisper distance (`WhisperDistance`)

## Compatibility

- **BetterChat**: replaced by this mod, NhxBetterChat won't load while it's installed
- **NhxQualityPack**: not compatible (it already contains this chat code, so every message would be sent twice), NhxBetterChat won't load while it's installed

## Multiplayer

- Client-side mod
- Does not have server sync
- Not needed on a dedicated server. If it's installed there anyway, it does nothing
- Every player should install it. Players without it still receive world chat messages as normal chat, but for them the floating text doesn't follow the sender or show their name, and their own chat only reaches players nearby

## Configuration

- World chat on/off (default on)
- Chat sound alert on/off (default on, needs World Chat on)

The settings are in `NhxBetterChat.cfg`. They have the same names as in NhxQualityPack, but aren't copied over from `NhxQualityPack.cfg`.
