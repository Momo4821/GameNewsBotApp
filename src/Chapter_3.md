# Chapter 3 - Administrator Commands

Administrator-related command code is in `Commands/AdministratorCommands.cs`. The file contains early experiments with moderation commands and log-level controls. These commands are incomplete, so this chapter records what the code currently does rather than describing them as finished moderation features.

## Kick command

`KickCommand` has the `!kick` command attribute and requires the bot to have the `Administrator` permission. Its method accepts a target member and calls `ValidateKickCommand`.

The validation method checks whether the target is a bot, whether the target is the invoking member, and whether the target member has the `KickMembers` permission. These checks currently do not stop the command method from continuing: the responses are not returned from the method, and some asynchronous calls are not awaited.

After validation, the command selects the first hard-coded reason and sends the target a direct message. The current method does not call a Discord kick operation, so it does not actually remove the member from the server.

<!-- Screenshot placeholder: add a screenshot showing the current !kick behavior, if tested. -->

## Ban command

`BanCommand` has a list of example ban reasons and calls `ValidateBanCommand`, but the command method does not currently have a `[Command(...)]` attribute. It therefore is not exposed as a CommandsNext command through the implementation shown here.

The validation method also does not currently stop execution after sending a warning. The implementation does not perform a ban operation.

## Timeout command

`TimeoutCommand` declares `!timeout` and requires the bot to have the `ModerateMembers` permission. Its method body is empty, so invoking the command has no implemented timeout behavior.

## Log-level commands

`SetLogLevelDebug` declares `!Debug` and calls `LoggingData.Setlogleveldebug()`, then responds with `"Working!"`.

`SetLogLevelInformation` contains logic to check the member and the channel ID, but it has no command attribute in the current code. It therefore is not registered as a callable command by CommandsNext as written.

The log-level methods are described further in Chapter 4.

## Checks and current limitations

The administrator code is useful for studying command attributes and permission checks, but it should not be treated as working moderation functionality:

- Some validation responses are asynchronous calls that are not awaited.
- The validation methods do not return a pass/fail result to prevent later code from running.
- The kick handler sends a direct message but does not kick the member.
- The ban handler is not decorated as a command and does not ban a member.
- The timeout handler has no implementation.
- The log-level information handler is not decorated as a command.

<!-- Screenshot placeholder: add a screenshot of the administrator command code or test output. -->