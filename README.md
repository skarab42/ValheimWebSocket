# Valheim WebSocket MOD

WIP project developed [on Twitch](https://twitch.tv/skarab42). Follow [my channel](https://twitch.tv/skarab42) for more development live streams.

# Features
- Twitch users can spawn Hugin/Hudin with custom message
- Twitch users can trigger HUD message

# Install

- Download and install [BepInExPack_Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)
- Download last release [ValheimWebSocket-v1.0.0](https://github.com/skarab42/ValheimWebSocket/releases/download/1.0.0/ValheimWebSocket.zip)
- Extract downloaded zip in `BepInEx/plugins` folder
- Edit `BepInEx/plugins/ValheimWebSocket/config.json` file with your [Twitch credentials](https://twitchtokengenerator.com/)
- Run the game
- Claim some rewards on your chat
- Quit the game
- Open the last log file in `BepInEx/plugins/ValheimWebSocket/logs/yy-mm-dd.log` and search for `rewardId` word
- Edit the config file with your reward ids
- Run the game
- Enjoy!

## Twitch credentials
You can generate your credentials from https://twitchtokengenerator.com/

- From the popup window chose the "Custom Scope Token"
- Select scope (HELIX):
  - channel:read:redemptions
  - channel:manage:redemptions
- Click on "Generate token"

# Development
- [Offical client](https://github.com/skarab42/valheim-websocket-client)
