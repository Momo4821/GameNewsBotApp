# Chapter 4 - News Commands

The game-news command handlers and Steam API request logic are implemented in `Commands/News_Command.cs`.

## Purpose

The news commands retrieve the latest news articles from Steam and display them in Discord. Each command is intended to be used in a specific game-news channel.

Before retrieving news, the command verifies that it is being used in the correct channel.

---

## Available Commands

| Command | Intended Game | Required Channel | App ID |
|----------|----------|----------|----------|
| `!TF2` | Team Fortress 2 | `game-news-tf2` | `440` |
| `!Marvel` | Marvel Rivals | `game-news-marvel-rivals` | `2767030` |
| `!Rain` | Risk of Rain | `game-news-risk-of-rain` | `632360` |
| `!PalWorld` | Palworld | `game-news-palworld` | `440` |

Each command uses:

```csharp
[RequirePrefixes("!")]
```

and validates the channel before attempting to retrieve news.

---

## Channel Validation

Each command checks the `CreateChannelsService.CreatedChannelInformation` dictionary.

The dictionary maps known channel names to their Discord channel IDs.

The handler performs the following checks:

1. Verify that the expected channel name exists in the dictionary.
2. Retrieve the stored channel ID.
3. Compare the stored ID with the ID of the current channel.
4. Continue only when both IDs match.

### Successful Validation

When the channel IDs match:

- The command proceeds.
- The Steam API request is executed.
- The requested news articles are displayed.

### Failed Validation

When the IDs do not match:

- The command stops.
- The user is informed that the command should be used in the designated news channel.

### Missing Dictionary Entry

If the expected channel name does not exist in the dictionary:

- News retrieval does not occur.
- The current implementation does not send a response.

The process used to populate this dictionary is discussed in Chapter 5.

---

## Steam News API

The news commands use the Steam `GetNewsForApp` endpoint:

```text
https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/
```

Each command constructs a URL containing:

- The Steam App ID
- The maximum number of news entries
- A maximum content length
- JSON output formatting

A shared `HttpClient` instance sends the request.

---

## Request Processing

After a command successfully passes channel validation, the `ParseJson` method executes.

The method performs the following steps:

1. Sends an HTTP GET request.
2. Reads the response body as a string.
3. Parses the response using `JsonDocument`.
4. Reads the `appnews.newsitems` collection.
5. Extracts the `title` and `url` fields.
6. Builds a formatted response message.
7. Sends the final response back to the Discord channel.

The generated response contains article titles along with links to the original Steam news posts.

---

## Current Limitations

The current implementation assumes that the Steam response contains the expected JSON structure.

At present, the command does not provide specialized handling for:

- HTTP request failures
- Invalid JSON
- Missing JSON properties
- Empty news collections
- Steam API outages

---

## App ID Notes

### Palworld App ID

The current Palworld implementation uses Steam App ID `440`.

```text
440
```

This is also the Team Fortress 2 App ID.

This chapter documents the value currently present in the source code and does not verify whether the command retrieves Palworld news correctly.

---

## Screenshots

Add screenshots demonstrating:

1. A successful news command response.
2. A news command executed in its designated channel.
3. A news command executed in the wrong channel.

```text
images/steam-news-response.png
images/news-command-success.png
images/news-command-wrong-channel.png
```

<!-- Screenshot placeholder: add a screenshot of a successful news command response. -->

<!-- Screenshot placeholder: add a screenshot showing a news command used in its designated channel. -->

<!-- Screenshot placeholder: add a screenshot showing the channel restriction response. -->

---

## Learning Notes

This chapter introduces several important concepts:

- Steam Web API integration
- HTTP requests using `HttpClient`
- JSON parsing with `JsonDocument`
- Channel validation using Discord channel IDs
- Shared application state through dictionaries
- Command authorization based on channel context

Understanding the news commands provides a foundation for future API integrations and more advanced command workflows.