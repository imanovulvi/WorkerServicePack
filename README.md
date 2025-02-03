# Worker Service

## This package is written for .NET Core projects.

## Adding an Interface

### The class you want to make a Worker should implement the `IHostService` interface.

### Add the following configuration to the `Program.cs` file in your project:

```csharp
builder.Services.AddWorkerService();
