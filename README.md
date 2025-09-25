# async_dotnet_demo

A .NET demo project showcasing asynchronous programming (using `async` / `await`) in C#.  
This repository is a learning / sample project to illustrate proper async patterns, best practices, and pitfalls in .NET.

## Table of Contents

- [Motivation](#motivation)  
- [Features](#features)  
- [Getting Started](#getting-started)  
- [Code Examples](#code-examples)  
- [Best Practices & Pitfalls](#best-practices--pitfalls)  
- [Testing / Benchmarks](#testing--benchmarks)  
- [Project Structure](#project-structure)  
- [Contributing](#contributing)  
- [License](#license)  

## Motivation

Asynchronous programming is essential in modern applications (web, I/O, networking) to avoid blocking threads and to scale efficiently. This demo aims to:

- Illustrate basic to advanced uses of `async` / `await`  
- Show how to structure async code cleanly  
- Demonstrate common traps (deadlocks, forgetting `ConfigureAwait`, etc.)  
- Provide reference examples you can reuse  

## Features

- Simple APIs demonstrating asynchronous operations  
- I/O-bound demo (e.g. HTTP calls, file access)  
- Proper error / cancellation handling in async methods  
- Demo of combining tasks, awaiting multiple tasks, etc.  
- (Optional) Benchmarks or comparisons between synchronous vs asynchronous  

## Getting Started

### Prerequisites

- [.NET SDK 8.0+] or whichever version the project targets  
- Basic familiarity with C#, .NET, `async` / `await`  

### Clone & Build

```bash
git clone https://github.com/pauldin91/async_dotnet_demo.git
cd async_dotnet_demo
dotnet build
