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

# Roadmap

<details>
<summary>IOC REPUTATION & ENRICHMENT</summary>

<details>

<summary>IP addresses</summary>
- [x] IP addresses
  - [x] Get an IP address report
  - [x] Request an IP address rescan (re-analyze)
  - [x] Get comments on an IP address
  - [x] Add a comment to an IP address
  - [x] Get objects related to an IP address
  - [x] Get object descriptors related to an IP address
  - [x] Get votes on an IP address
  - [x] Add a vote to an IP address
</details>

<details>
<summary style="padding-left: 10px;">Domains & Resolutions</summary>
- [x] Domains & Resolutions
  - [x] Get a domain report
  - [x] Get comments on a domain
  - [x] Add a comment to a domain
  - [x] Get objects related to a domain
  - [x] Get object descriptors related to a domain
  - [x] Get a DNS resolution object
  - [x] Get votes on a domain
  - [x] Add a vote to a domain
</details>

<details>
<summary style="padding-left: 10px;">Files</summary>
- [ ] Files
  - [x] Upload a file
  - [x] Get a file report
  - [x] Request a file rescan (re-analyze)
  - [ ] Get a file’s download URL
  - [ ] Download a file
  - [x] Get comments on a file
  - [x] Add a comment to a file
  - [x] Get objects related to a file
  - [x] Get object descriptors related to a file
  - [ ] Get a crowdsourced Sigma rule object
  - [ ] Get a crowdsourced YARA ruleset
  - [x] Get votes on a file
  - [x] Add a vote on a file
</details>

<details>
<summary style="padding-left: 10px;">File Behaviours</summary>
- [ ] File Behaviours
  - [ ] Get a summary of all behavior reports for a file
  - [ ] Get a summary of all MITRE ATT&CK techniques observed in a file
  - [ ] Get all behavior reports for a file 
  - [ ] Get a file behavior report from a sandbox
  - [ ] Get objects related to a behaviour report
  - [ ] Get object descriptors related to a behaviour report
  - [ ] Get a detailed HTML behaviour report
  - [ ] Get the EVTX file generated during a file’s behavior analysis
  - [ ] Get the PCAP file generated during a file’s behavior analysis
  - [ ] Get the memdump file generated during a file’s behavior analysis
</details>

<details>
<summary style="padding-left: 10px;">URLs</summary>
- [x] URLs
  - [x] Scan URL
  - [x] Get a URL analysis report
  - [x] Request a URL rescan (re-analyze)
  - [x] Get comments on a URL
  - [x] Add a comment on a URL
  - [x] Get objects related to a URL
  - [x] Get object descriptors related to a URL
  - [x] Get votes on a URL
  - [x] Add a vote to a URL
</details>

<details>
<summary style="padding-left: 10px;">Comments</summary>
- [ ] Comments
  - [x] Get latest comments
  - [x] Get a comment object
  - [x] Delete a comment
  - [ ] Get objects related to a comment
  - [ ] Get object descriptors related to a comment
  - [ ] Add a vote to a commentp
</details>

<details>
<summary style="padding-left: 10px;">Analyses, Submissions & Operations</summary>
- [ ] Analyses, Submissions & Operations
  - [x] Get a URL / file analysis
  - [x] Get objects related to an analysis
  - [x] Get object descriptors related to an analysis
  - [ ] Get a submission object
  - [ ] Get an operation object
</details>


<details>
<summary style="padding-left: 10px;">Attack Tactics</summary>
- [ ] Attack Tactics
  - [ ] Get an attack tactic object
  - [ ] Get objects related to an attack tactic
  - [ ] Get object descriptors related to an attack tactic
</details>

<details>
<summary style="padding-left: 10px;">Attack Techniques</summary>
- [ ] Attack Techniques
  - [ ] Get an attack technique object
  - [ ] Get objects related to an attack technique
  - [ ] Get object descriptors related to an attack technique
</details>

<details>
<summary style="padding-left: 10px;">Popular Threat Categories</summary>
- [ ] Popular Threat Categories
  - [ ] Get a list of popular threat categories
</details>
</details>


# License

This project is licensed under the MIT License. See the LICENSE file for details.

# Support

For issues, questions, or feature requests, please open an issue on GitHub.
