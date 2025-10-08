# advanced_dotnet_demos

A repository that aims to showcase the strengths of C# and .NET Core
in a comprehensive test driven approach. A variety of demos is exlored 
including async & parallel programming, the leverage of reflection to 
achieve a cleaner and more maintainable code and more.

## Table of Contents

- [Async Dotnet Patterns](#async_dotnet_demo)
  - [Motivation](#motivation)
  - [Features](#features)   
    
- [Contributions](#contributions)    
- [License](#license)  



## async_dotnet_demo

A .NET demo project showcasing asynchronous programming (using `async` / `await`) in C#.  

### Motivation

Asynchronous programming is essential in modern applications (web, I/O, networking) to avoid blocking threads and to scale efficiently. This demo aims to:

- Illustrate basic to advanced uses of `async` / `await`  
- Show how to structure async code cleanly  
- Demonstrate common traps (deadlocks, forgetting `ConfigureAwait`, etc.)  
- Provide reference examples you can reuse  

### Features

- Simple APIs demonstrating asynchronous operations  
- I/O-bound demo (e.g. HTTP calls, file access)  
- Proper error / cancellation handling in async methods  
- Demo of combining tasks, awaiting multiple tasks, etc.  
- (Optional) Benchmarks or comparisons between synchronous vs asynchronous

## Contributions
Contributions are always welcome. 

