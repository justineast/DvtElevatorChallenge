# DvtElevatorChallenge

# Elevator Challenge App
 
This application manages elevators using .NET 8.
 
## Table of Contents
 
1. [Introduction](#introduction)
2. [Features](#features)
3. [Installation](#installation)
4. [Usage](#usage)
 
## Introduction
 
The Elevator Challenge App is used to manage the movement of the elevator efficiently and effectively. The elevator moves to the required destination by moving through all of the buttons which were pressed.
 
## Features
 
Key Features:
- Elevators are managed by the Elevator control room
- The elevators go through the number of buttons pressed sequential to optimise movement
- Floor selection is done by passing the floor into the Elevator control
- Real-time status updates
 
## Installation
 
Prerequisites:
- dotnet 8 SDK (For development purposes).
- Access to the GitHub Repo.
	- https://github.com/justineastmc/DvtElevatorChallenge

# Instructions on how to install:
 - dotnet restore
 - dotnet build
 
# Usage
- dotnet run
- You can run the exe that is generated after compiliation
- You can debug this in an IDE like Visual Studio

## Build and Deploy

- An azure-pipelines.yaml file has been added to build the application using the DotNetCoreCLI@2 through ADO
- This would simulate the following steps:
	- Restore nuget packages added
	- Build the solution
	- Run any Unit Tests
	- Publish the artifact to the $(Build.ArtifactStagingDirectory) location
