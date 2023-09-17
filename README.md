# Toy Robot Simulator

![example workflow](https://github.com/lgxkevin/ToyRobotSimulator/actions/workflows/dotnet.yml/badge.svg)

## Introduction

Welcome to the Toy Robot Simulator project! This application simulates the movements of a toy robot on a 5x5 square tabletop. The robot can move freely on the table but is programmed to prevent itself from falling off. It is written in C# and includes a suite of unit tests to ensure its functionality.

## Features

- **Simulation of a 5x5 square tabletop**
- **Command-based robot movements**
- **Safety checks to prevent the robot from falling off the table**
- **Unit tests to validate functionality**

## Commands

The application accepts the following commands:

- `PLACE X,Y,F`: Places the robot on the table at coordinates `(X, Y)` facing `NORTH`, `SOUTH`, `EAST`, or `WEST`.
- `MOVE`: Moves the robot one unit forward in the direction it is currently facing.
- `LEFT`: Rotates the robot 90 degrees to the left without changing its position.
- `RIGHT`: Rotates the robot 90 degrees to the right without changing its position.
- `REPORT`: Outputs the current X, Y coordinates and the direction the robot is facing.

## Constraints

- The robot will not move in a manner that would cause it to fall off the table.
- Commands that would result in the robot falling off the table are ignored.
- The robot must be placed on the table using the `PLACE` command before any other commands can be issued.

## Test Data

Test data is provided to exercise the application's functionality and can be found in the `\ToyRobotSimulator\Data\Commands.txt` file.

## Getting Started

To get started with the Toy Robot Simulator, clone this repository and follow the setup instructions.

- Enter `ToyRobotSimulator` folder
- Run `dotnet run` in terminal
