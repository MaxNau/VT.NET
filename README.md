# VT.NET - VirusTotal API Client Library for .NET

A simple and easy-to-use C# client library for interacting with the [VirusTotal API v3](https://www.virustotal.com/reference/overview). This library simplifies the process of sending files, URLs, and hashes for analysis, as well as retrieving analysis results.

## Features

- Files API client (scan, rescan, get report)
- URLs API client (scan, rescan, get report)
- IP addresses API client (get report, rescan)
- Domains & Resolutions API client (get report, rescan, get resolution)
- All-In-One client for public VirusTotal APIs

## Getting Started

### Installation

Install VTNet DI Extensions that includes VTNet

[![NuGet](https://img.shields.io/nuget/v/VTNet.DependencyInjection.Extensions.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/VTNet.DependencyInjection.Extensions/)

or VTNet separatly

[![NuGet](https://img.shields.io/nuget/v/VTNet.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/VTNet/)

### Usage

For DI-ready solutions use `VT.NET.DependencyInjection.Extensions` package which provides extensions for `ServiceCollection`:
- by passing your API key as one of the arguments:
	```csharp
	builder.Services.AddVTFilesClient("<api-key>");
	```
- by using configuration:

	```yaml
	{
	  "VTConfiguration": {
		    "ApiKey": "<api key>",
		    "Url": "<api url>"
	  }
	}
	```
	and corresponding extension overload to provide `IConfiguration` object
	```csharp
	builder.Services.AddVTFilesClient(configuration);
	```
You can use different types of clients depending on your need.
Files client:
	```csharp
	builder.Services.AddVTFilesClient(configuration);
	```
 URLs client:
	```csharp
	builder.Services.AddVTUrlsClient(configuration);
	```

 Or you can use All-In-One client:
	```csharp
	builder.Services.AddVTClient(configuration);
	```
 
Then in classes where you will use the client inject `IVTFiles` or any other client depending on your need via constructor.

# License

This project is licensed under the MIT License. See the LICENSE file for details.

# Support

For issues, questions, or feature requests, please open an issue on GitHub.
