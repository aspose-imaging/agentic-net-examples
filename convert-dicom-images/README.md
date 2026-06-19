# DICOM Medical Imaging in C# – Convert DICOM Images with Aspose.Imaging

This collection shows how to work with **DICOM medical imaging** in C# using Aspose.Imaging for .NET.  
You’ll find examples that demonstrate converting DICOM files to PNG, handling in‑memory byte arrays, and validating image integrity before conversion—common tasks in **DICOM to PNG dotnet** and broader **medical image processing** workflows.

## What's in This Category
- Load a DICOM file from disk and save it directly as a PNG (single‑call API).  
- Convert a DICOM image stored in a byte array to PNG using `MemoryStream` for in‑memory processing.  
- Verify DICOM file integrity with the `Image.IsValid` property before attempting conversion.  
- (Additional examples may cover multi‑frame handling, custom PNG options, etc.)

## Quick Start
The most frequent operation is converting a DICOM file to PNG with a single call:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load the DICOM file and save it as PNG in one line
Image.Load(@"input.dcm").Save(@"output.png", new PngOptions());
```

Add the Aspose.Imaging package to your project and run the snippet on any .NET 9+ runtime.

## All Examples

| Example | Description |
|---|---|
| [load-a-dicom-file-from-disk-and-save-it-as-a-png-using-a-single-api-call.cs](./load-a-dicom-file-from-disk-and-save-it-as-a-png-using-a-single-api-call.cs) | Load a DICOM file from disk and save it as a PNG using a single API call. |
| [convert-a-dicom-image-stored-in-a-byte-array-to-png-by-using-memorystream-for-in-memory-processing.cs](./convert-a-dicom-image-stored-in-a-byte-array-to-png-by-using-memorystream-for-in-memory-processing.cs) | Convert a DICOM image stored in a byte array to PNG by using `MemoryStream` for in‑memory processing. |
| [use-the-image-isvalid-property-to-verify-dicom-file-integrity-before-attempting-png-conversion.cs](./use-the-image-isvalid-property-to-verify-dicom-file-integrity-before-attempting-png-conversion.cs) | Use the `Image.IsValid` property to check DICOM file integrity before converting to PNG. |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9** or later

[← Back to Root README](../README.md)