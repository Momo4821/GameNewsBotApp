# Chapter 1 - Project Overview

## Introduction

Game News Bot is a small Discord bot created to learn how to connect a C# application to Discord and fetch data from an external API. The bot retrieves game-related news from the Steam API and posts it in designated Discord channels.

This project is intentionally simple and focused on learning. It is designed for personal use in private Discord servers where the developer has admin access.

## Why this project exists

This project was created to explore:
- Discord bot development in C#
- DSharpPlus command handling
- API integration basics
- JSON parsing and data formatting
- Logging and debugging
- Command restrictions based on channel

## Main goals

The primary goals of this project are:
- learn how to build a Discord bot in C#
- practice calling external APIs
- handle JSON responses safely
- create simple command-based bot behavior
- build a small modular project structure

## Project structure

The project is organized into a few main areas:

- Main File/Program.cs  
  Starts the bot and registers commands.

- Commands/  
  Contains the bot command modules.

- CreateChannels/  
  Creates category and text channels used by the bot.

- ConfigToken/  
  Reads the bot token from the environment.

- Logging/  
  Configures logging through Serilog.

- AppSettings/  
  Stores the logging configuration.

- SQL Connection/  
  Reserved for possible future database work.

## Learning outcome

This project is useful for learning how a Discord bot:
- connects to Discord
- registers commands
- receives command input
- calls a web API
- parses the response
- sends formatted messages back to Discord
