# Martian Robots

A C# implementation of the classic Martian Robots simulation problem. The application simulates multiple robots navigating a rectangular grid on Mars, following given movement instructions while handling edge conditions and avoiding repeating previous failures.

---

## Overview

The problem involves simulating how robots move over a grid defined by the upper-right coordinates, using three commands:

- `L` – turn left
- `R` – turn right
- `F` – move forward

Robots can fall off the grid, becoming "lost." If a robot gets lost from a position, a "scent" is left behind to prevent subsequent robots from making the same mistake at that location.

---

## Technologies Used

- **.NET 6.0 (or later, e.g., .NET 9.0)**
- **C#**
- **NUnit** for unit testing
- **Console application** interface (as per assignment simplicity)

---

### Tech Decisions

- **Console-based app**: Matches the assignment I/O format (stdin/stdout).
- **NUnit**: Popular, expressive testing framework with good IDE and CI integration.
- **Modular class design**:
  - `Robot`: encapsulates state and movement
  - `Grid`: handles boundary checks
  - `IRobotCommand`: uses the command pattern to keep L, R, and F instructions modular and easily extendable
  - `RobotController`: coordinates parsing, execution, and output
  
This architecture makes the solution maintainable, testable, and easy to expand (e.g., more commands, visual UI, etc.).

---

## Problem-Solving Approach

1. **Modeling the domain**:
   - Defined `Direction` enum and `Robot` class to model position and orientation.
   - Created `Grid` class to track boundaries and validate moves.
   - Introduced `IRobotCommand` interface to encapsulate commands (`L`, `R`, `F`).

2. **Instruction parsing**:
   - Implemented a `RobotController` that parses input line by line from `stdin`.
   - Each robot and its commands are processed sequentially.

3. **Lost robots and scents**:
   - When a robot moves off the grid, it becomes “lost” and leaves a scent.
   - Future robots ignore `F` commands from scented positions.

4. **Testing**:
   - Verified behavior with unit tests across:
     - Robot rotation and movement
     - Grid bounds
     - Command logic
     - Integration tests matching assignment examples

---

## How to Build and Run

### Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) 6.0 or later

### **Build**

From the root folder:

```
dotnet build
```

### **Run**

From the root folder:

```
dotnet run --project MartianRobots
```

### **Run Unit Tests**

From the root folder:

```
dotnet test
```

### Example

**Input**<br>
```5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL
```

**Expected Output**<br>
```1 1 E
3 3 N LOST
2 3 S
```
