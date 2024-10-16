# Complete-23-Gang-of-Four-Design-Patterns-in-C-With-Real-Time-Examples
Complete 23 Gang of Four Design Patterns in C# With Real-Time Examples
# 23 Gang of Four Design Patterns in C#

This repository contains implementations of the 23 Gang of Four (GoF) Design Patterns in C#. Each pattern is demonstrated with real-time examples to help understand its usage and application in software design.

## Table of Contents

- [Introduction](#introduction)
- [Design Patterns](#design-patterns)
  - [Creational Patterns](#creational-patterns)
  - [Structural Patterns](#structural-patterns)
  - [Behavioral Patterns](#behavioral-patterns)
- [Real-Time Examples](#real-time-examples)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Design patterns are proven solutions to common software design problems. They provide a template for how to solve issues in software architecture, making your code more flexible, reusable, and easier to maintain.

## Design Patterns

### Creational Patterns
1. **Singleton**
   - Ensures a class has only one instance and provides a global point of access.
   - *Example:* Configuration settings manager.

2. **Factory Method**
   - Defines an interface for creating an object but allows subclasses to alter the type of created objects.
   - *Example:* Shape factory for different shapes (Circle, Square).

3. **Abstract Factory**
   - Provides an interface for creating families of related or dependent objects without specifying their concrete classes.
   - *Example:* UI widget factory (Windows, Mac).

4. **Builder**
   - Separates the construction of a complex object from its representation.
   - *Example:* MealBuilder for creating complex meal objects.

5. **Prototype**
   - Creates new objects by copying an existing object, known as the prototype.
   - *Example:* Cloning a game character.

### Structural Patterns
6. **Adapter**
   - Allows incompatible interfaces to work together.
   - *Example:* Adapter for integrating a new payment gateway with an existing system.

7. **Bridge**
   - Decouples an abstraction from its implementation so that the two can vary independently.
   - *Example:* Remote control for different types of devices.

8. **Composite**
   - Composes objects into tree structures to represent part-whole hierarchies.
   - *Example:* Graphic design elements (Shapes, Groups).

9. **Decorator**
   - Adds new functionality to an object dynamically.
   - *Example:* Adding features to a coffee order (milk, sugar).

10. **Facade**
    - Provides a simplified interface to a complex subsystem.
    - *Example:* A simplified API for a library with multiple classes.

11. **Flyweight**
    - Reduces memory usage by sharing common parts of state between multiple objects.
    - *Example:* Character representation in a text editor.

12. **Proxy**
    - Provides a surrogate or placeholder for another object to control access.
    - *Example:* Virtual proxy for loading images.

### Behavioral Patterns
13. **Chain of Responsibility**
    - Passes a request along a chain of handlers.
    - *Example:* Logging framework with multiple log levels.

14. **Command**
    - Encapsulates a request as an object, thereby allowing for parameterization of clients.
    - *Example:* GUI buttons that execute commands.

15. **Interpreter**
    - Defines a representation for a language's grammar and provides an interpreter to use it.
    - *Example:* Simple expression evaluator.

16. **Iterator**
    - Provides a way to access elements of a collection sequentially without exposing its underlying representation.
    - *Example:* Custom collection of books.

17. **Mediator**
    - Defines an object that encapsulates how a set of objects interact.
    - *Example:* Chat room where users communicate.

18. **Memento**
    - Captures and externalizes an object's internal state without violating encapsulation.
    - *Example:* Undo functionality in a text editor.

19. **Observer**
    - Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified.
    - *Example:* News subscription service.

20. **State**
    - Allows an object to alter its behavior when its internal state changes.
    - *Example:* Vending machine states.

21. **Strategy**
    - Defines a family of algorithms, encapsulates each one, and makes them interchangeable.
    - *Example:* Sorting algorithms for different data types.

22. **Template Method**
    - Defines the skeleton of an algorithm in a method, deferring some steps to subclasses.
    - *Example:* Game development (initializing levels).

23. **Visitor**
    - Represents an operation to be performed on elements of an object structure.
    - *Example:* File system operations (copy, delete).

## Real-Time Examples

For each design pattern, there is a dedicated folder containing:
- The pattern implementation in C#
- A detailed explanation
- Example use cases



