## Ping

The `Ping_Command` method defines the `!Ping` command.

### Implementation

```csharp
[Command("Ping")]
[RequirePrefixes("!")]
public async Task Ping_Command(CommandContext commandPing)
{
    await commandPing.RespondAsync(
        $"Pong! latency is {commandPing.Client.Ping}ms. From {commandPing.User.Username}");
}
```

### Purpose

The Ping command provides a simple way to verify that the bot is online and responding to commands. When executed, the bot responds with its current latency and the username of the person who invoked the command.

The ping value comes directly from the DSharpPlus client:

```csharp
commandPing.Client.Ping
```

This value is useful as a basic connection check, but it is not a measurement of Steam API response times or external network performance.

The command also writes an informational log entry after responding.

### Example

**User Input**

```text
!Ping
```

**Example Response**

```text
Pong! latency is 42ms. From YourUsername
```

The latency and username shown above are examples only.

<!-- Screenshot placeholder: add a screenshot of the ping command and its response. -->

---

## Greet

The `Greet_Command` class defines the `!Greet` command.

### Purpose

This command greets the invoking member when a valid guild member is available in the command context.

### Implementation

```csharp
if (_Greet_Command.Member != null)
{
    await _Greet_Command.RespondAsync(
        $"Hello, {_Greet_Command.Member.Mention}! Welcome to the Game News Bot!");
}
```

### Behavior

Before sending a greeting, the command verifies that the `Member` property is not null.

If a valid member exists, the bot responds by mentioning that member directly.

The informational log entry is written outside of the conditional statement, meaning the command may still be logged even if no greeting message is sent.

### Example

**User Input**

```text
!Greet
```

**Example Response**

```text
Hello, @User! Welcome to the Game News Bot!
```

<!-- Screenshot placeholder: add a screenshot of the greet command and response. -->

---

## BotInfo

The `BotInfo` class defines the `!BotInfo` command.

### Purpose

This command displays information about the Game News Bot using a Discord embed.

### Behavior

The command builds an embed containing:

- Author information
- Title
- Description
- Footer text
- Embed color

Once the embed has been assembled, it is sent as the response to the invoking user.

### Example

**User Input**

```text
!BotInfo
```

**Example Response**

A Discord embed containing information about the Game News Bot.

<!-- Screenshot placeholder: add a screenshot of the BotInfo embed. -->

---

## Command Configuration Notes

In `Program.cs`, CommandsNext is configured with the following string prefixes:

```text
!
/
```

Command matching is configured as case-insensitive.

The command methods documented in this chapter also use:

```csharp
[RequirePrefixes("!")]
```

Because of this attribute, these commands require the `!` prefix even though `/` is configured as a string prefix.

It is important to note that the `/` string prefix used by CommandsNext is not the same thing as a Discord application slash command.