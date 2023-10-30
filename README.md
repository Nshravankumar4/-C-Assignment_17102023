# -C-Assignment_17102023 


Create a workflow orchestration engine (WOE) using C# .NET with the following features:
A JSON- or XML-based workflow description file
A .NET assembly (DLL) acting as an activity library
Every activity must be self-contained
Ability to introduce a new activity on the fly without making any modification to the engine code

At runtime the WOE should:
Consume the JSON or XML workflow description file
Create activity objects from the library (.NET assembly) based on the JSON or XML description file 
Execute activities in a sequential order only
Changing the order of the activities should result in a change in the execution order of the activities.
Activities should have rollback functionality

The following three activities must be implemented. All of these activities should also support rollback:
Create a directory (recursively)
Copy files (recursively)
Start or stop a Windows Service
