# Convert DICOM to PNG in C# with Aspose.Imaging for .NET  

A set of ready‑to‑run examples that show how to turn DICOM medical images into PNG files using the **Aspose.Imaging for .NET** backend API. The code works in ASP.NET Core, console apps, Azure Functions, Docker containers, and any environment that doesn’t require a UI.  

## What You Can Do  

- **Convert a grayscale DICOM to PNG with a custom color palette** – apply your own palette while converting a single `.dcm` file.  
- **Batch convert all DICOM files in a folder to PNG while preserving the original filenames** – perfect for processing large study folders.  
- **Control PNG compression level** – balance file size and image quality by setting `PngCompressionLevel` in `PngOptions`.  
- **Convert a DICOM byte array to PNG completely in memory** – read the DICOM data into a `byte[]`, use a `MemoryStream`, and write the PNG without touching the file system.  
- **Log start and end timestamps for each conversion** – wrap the conversion logic in a simple logger to track processing time per file.  

## Quick Start  

```csharp
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Input DICOM and output PNG paths
        string dicomPath = @"C:\Temp\input.dcm";
        string pngPath   = @"C:\Temp\output.png";

        // Load the DICOM image
        using (Image dicomImage = Image.Load(dicomPath))
        {
            // Set basic PNG options (you can also set CompressionLevel, Palette, etc.)
            var pngOptions = new PngOptions();

            // Save as PNG
            dicomImage.Save(pngPath, pngOptions);
        }

        Console.WriteLine("Conversion completed.");
    }
}
```

This snippet demonstrates the most common scenario: converting a single DICOM file to PNG with default settings.

## Requirements  

- .NET 9.0 (or later)  
- Aspose.Imaging for .NET  

Install the library via NuGet:

```bash
dotnet add package Aspose.Imaging
```

## Resources  

| Resource | Link |
|----------|------|
| Documentation | https://docs.aspose.com/imaging/net/ |
| NuGet | https://www.nuget.org/packages/aspose.imaging |
| Release Notes | https://releases.aspose.com/imaging/net/ |
| Online Apps | https://products.aspose.app/imaging/family/ |
| Free Temporary License | https://purchase.aspose.com/temporary-license |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [apply-a-custom-color-palette-to-the-png-output-when-converting-grayscale-dicom-images.cs](./apply-a-custom-color-palette-to-the-png-output-when-converting-grayscale-dicom-images.cs) |
| [apply-a-median-filter-to-a-dicom-image-before-converting-it-to-png-to-reduce-noise.cs](./apply-a-median-filter-to-a-dicom-image-before-converting-it-to-png-to-reduce-noise.cs) |
| [batch-convert-all-dicom-files-in-a-directory-to-png-format-while-preserving-original-filenames.cs](./batch-convert-all-dicom-files-in-a-directory-to-png-format-while-preserving-original-filenames.cs) |
| [capture-and-log-aspose-imaging-exceptions-when-a-dicom-to-png-conversion-fails-due-to-corrupted-data.cs](./capture-and-log-aspose-imaging-exceptions-when-a-dicom-to-png-conversion-fails-due-to-corrupted-data.cs) |
| [configure-png-compression-level-in-pngoptions-to-balance-file-size-and-image-quality-during-conversion.cs](./configure-png-compression-level-in-pngoptions-to-balance-file-size-and-image-quality-during-conversion.cs) |
| [configure-the-png-output-to-include-metadata-from-the-original-dicom-file-for-traceability.cs](./configure-the-png-output-to-include-metadata-from-the-original-dicom-file-for-traceability.cs) |
| [convert-a-dicom-image-stored-in-a-byte-array-to-png-by-using-memorystream-for-in-memory-processing.cs](./convert-a-dicom-image-stored-in-a-byte-array-to-png-by-using-memorystream-for-in-memory-processing.cs) |
| [create-a-command-line-tool-that-accepts-a-dicom-file-path-and-outputs-a-png-file-to-a-folder.cs](./create-a-command-line-tool-that-accepts-a-dicom-file-path-and-outputs-a-png-file-to-a-folder.cs) |
| [create-a-logging-wrapper-that-records-start-and-end-timestamps-for-each-dicom-to-png-conversion-operation.cs](./create-a-logging-wrapper-that-records-start-and-end-timestamps-for-each-dicom-to-png-conversion-operation.cs) |
| [create-a-windows-forms-application-that-allows-users-to-select-dicom-files-and-view-generated-png-previews.cs](./create-a-windows-forms-application-that-allows-users-to-select-dicom-files-and-view-generated-png-previews.cs) |
| [develop-a-background-service-that-monitors-a-folder-for-new-dicom-files-and-automatically-converts-them-to-png.cs](./develop-a-background-service-that-monitors-a-folder-for-new-dicom-files-and-automatically-converts-them-to-png.cs) |
| [develop-a-unit-test-that-loads-a-sample-dicom-converts-it-to-png-and-compares-file-sizes.cs](./develop-a-unit-test-that-loads-a-sample-dicom-converts-it-to-png-and-compares-file-sizes.cs) |
| [document-the-conversion-process-in-code-comments-including-required-using-directives-and-disposal-patterns.cs](./document-the-conversion-process-in-code-comments-including-required-using-directives-and-disposal-patterns.cs) |
| [extract-the-patient-name-tag-from-dicom-metadata-and-embed-it-into-the-png-file-name.cs](./extract-the-patient-name-tag-from-dicom-metadata-and-embed-it-into-the-png-file-name.cs) |
| [implement-a-retry-mechanism-that-attempts-dicom-to-png-conversion-up-to-three-times-on-transient-errors.cs](./implement-a-retry-mechanism-that-attempts-dicom-to-png-conversion-up-to-three-times-on-transient-errors.cs) |
| [implement-asynchronous-dicom-to-png-conversion-using-task-run-to-avoid-blocking-the-ui-thread.cs](./implement-asynchronous-dicom-to-png-conversion-using-task-run-to-avoid-blocking-the-ui-thread.cs) |
| [implement-exception-handling-to-gracefully-skip-corrupted-dicom-files-during-batch-png-conversion.cs](./implement-exception-handling-to-gracefully-skip-corrupted-dicom-files-during-batch-png-conversion.cs) |
| [implement-progress-reporting-for-batch-conversion-of-dicom-files-to-png-using-iprogress-interface.cs](./implement-progress-reporting-for-batch-conversion-of-dicom-files-to-png-using-iprogress-interface.cs) |
| [integrate-dicom-to-png-conversion-into-an-asp-net-core-api-endpoint-returning-the-png-as-a-byte-array.cs](./integrate-dicom-to-png-conversion-into-an-asp-net-core-api-endpoint-returning-the-png-as-a-byte-array.cs) |
| [iterate-through-each-frame-of-a-multi-page-dicom-and-export-every-frame-as-an-individual-png-file.cs](./iterate-through-each-frame-of-a-multi-page-dicom-and-export-every-frame-as-an-individual-png-file.cs) |
| [load-a-dicom-file-from-disk-and-save-it-as-a-png-using-a-single-api-call.cs](./load-a-dicom-file-from-disk-and-save-it-as-a-png-using-a-single-api-call.cs) |
| [resize-a-dicom-image-to-specific-dimensions-prior-to-png-conversion-using-the-image-resize-method.cs](./resize-a-dicom-image-to-specific-dimensions-prior-to-png-conversion-using-the-image-resize-method.cs) |
| [rotate-a-dicom-image-90-degrees-clockwise-before-saving-it-as-a-png-file.cs](./rotate-a-dicom-image-90-degrees-clockwise-before-saving-it-as-a-png-file.cs) |
| [save-the-resulting-png-image-to-a-memorystream-for-further-transmission-over-a-network.cs](./save-the-resulting-png-image-to-a-memorystream-for-further-transmission-over-a-network.cs) |
| [set-the-png-color-type-to-truecolor-during-conversion-to-preserve-full-color-information-from-dicom.cs](./set-the-png-color-type-to-truecolor-during-conversion-to-preserve-full-color-information-from-dicom.cs) |
| [use-a-using-statement-to-ensure-the-image-object-is-disposed-after-converting-dicom-to-png.cs](./use-a-using-statement-to-ensure-the-image-object-is-disposed-after-converting-dicom-to-png.cs) |
| [use-the-image-isvalid-property-to-verify-dicom-file-integrity-before-attempting-png-conversion.cs](./use-the-image-isvalid-property-to-verify-dicom-file-integrity-before-attempting-png-conversion.cs) |
| [validate-that-the-generated-png-files-are-viewable-in-standard-image-viewers-after-conversion.cs](./validate-that-the-generated-png-files-are-viewable-in-standard-image-viewers-after-conversion.cs) |
| [validate-that-the-pixel-data-remains-unchanged-after-converting-a-dicom-image-to-png-format.cs](./validate-that-the-pixel-data-remains-unchanged-after-converting-a-dicom-image-to-png-format.cs) |
| [write-a-powershell-script-that-invokes-the-net-conversion-library-to-process-dicom-files-in-bulk.cs](./write-a-powershell-script-that-invokes-the-net-conversion-library-to-process-dicom-files-in-bulk.cs) |
[**View all 30 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/convert-dicom-images)
