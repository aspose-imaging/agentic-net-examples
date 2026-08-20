---
name: convert-dicom-images
description: C# examples for Convert DICOM Images using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Convert DICOM Images

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Convert DICOM Images** category.
This folder contains standalone C# examples for Convert DICOM Images operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using Aspose.Imaging;` (31/30 files) ← category-specific
- `using System;` (30/30 files)
- `using System.IO;` (30/30 files)
- `using Aspose.Imaging.ImageOptions;` (30/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Dicom;` (22/30 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (7/30 files) ← category-specific
- `using Aspose.Imaging.CoreExceptions.ImageFormats;` (2/30 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (1/30 files) ← category-specific
- `using Aspose.Imaging.ProgressManagement;` (1/30 files) ← category-specific
- `using Aspose.Imaging.CoreExceptions;` (1/30 files) ← category-specific
- `using System.Threading.Tasks;` (1/30 files)
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (1/30 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-dicom-file-from-disk-and-save-it-as-a-png-using-a-single-api-call.cs](./load-a-dicom-file-from-disk-and-save-it-as-a-png-using-a-single-api-call.cs) | `DicomImage`, `PngOptions` | Load a DICOM file from disk and save it as a PNG using a single API call. |
| [convert-a-dicom-image-stored-in-a-byte-array-to-png-by-using-memorystream-for-in-memory-processing.cs](./convert-a-dicom-image-stored-in-a-byte-array-to-png-by-using-memorystream-for-in-memory-processing.cs) | `DicomImage`, `LoadOptions`, `PngOptions` | Convert a DICOM image stored in a byte array to PNG by using MemoryStream for in... |
| [use-the-image-isvalid-property-to-verify-dicom-file-integrity-before-attempting-png-conversion.cs](./use-the-image-isvalid-property-to-verify-dicom-file-integrity-before-attempting-png-conversion.cs) | `DicomImage`, `PngOptions` | Use the Image.IsValid property to verify DICOM file integrity before attempting ... |
| [apply-a-median-filter-to-a-dicom-image-before-converting-it-to-png-to-reduce-noise.cs](./apply-a-median-filter-to-a-dicom-image-before-converting-it-to-png-to-reduce-noise.cs) | `DicomImage`, `MedianFilterOptions`, `PngOptions` | Apply a median filter to a DICOM image before converting it to PNG to reduce noi... |
| [resize-a-dicom-image-to-specific-dimensions-prior-to-png-conversion-using-the-image-resize-method.cs](./resize-a-dicom-image-to-specific-dimensions-prior-to-png-conversion-using-the-image-resize-method.cs) | `DicomImage`, `PngOptions` | Resize a DICOM image to specific dimensions prior to PNG conversion using the Im... |
| [rotate-a-dicom-image-90-degrees-clockwise-before-saving-it-as-a-png-file.cs](./rotate-a-dicom-image-90-degrees-clockwise-before-saving-it-as-a-png-file.cs) | `PngOptions` | Rotate a DICOM image 90 degrees clockwise before saving it as a PNG file. |
| [set-the-png-color-type-to-truecolor-during-conversion-to-preserve-full-color-information-from-dicom.cs](./set-the-png-color-type-to-truecolor-during-conversion-to-preserve-full-color-information-from-dicom.cs) | `PngOptions` | Set the PNG color type to truecolor during conversion to preserve full color inf... |
| [configure-png-compression-level-in-pngoptions-to-balance-file-size-and-image-quality-during-conversion.cs](./configure-png-compression-level-in-pngoptions-to-balance-file-size-and-image-quality-during-conversion.cs) | `PngOptions` | Configure PNG compression level in PngOptions to balance file size and image qua... |
| [iterate-through-each-frame-of-a-multi-page-dicom-and-export-every-frame-as-an-individual-png-file.cs](./iterate-through-each-frame-of-a-multi-page-dicom-and-export-every-frame-as-an-individual-png-file.cs) | `DicomImage`, `PngOptions` | Iterate through each frame of a multi‑page DICOM and export every frame as an in... |
| [batch-convert-all-dicom-files-in-a-directory-to-png-format-while-preserving-original-filenames.cs](./batch-convert-all-dicom-files-in-a-directory-to-png-format-while-preserving-original-filenames.cs) | `DicomImage`, `PngOptions` | Batch convert all DICOM files in a directory to PNG format while preserving orig... |
| [implement-progress-reporting-for-batch-conversion-of-dicom-files-to-png-using-iprogress-interface.cs](./implement-progress-reporting-for-batch-conversion-of-dicom-files-to-png-using-iprogress-interface.cs) | `DicomImage`, `LoadOptions`, `PngOptions` | Implement progress reporting for batch conversion of DICOM files to PNG using IP... |
| [implement-a-retry-mechanism-that-attempts-dicom-to-png-conversion-up-to-three-times-on-transient-errors.cs](./implement-a-retry-mechanism-that-attempts-dicom-to-png-conversion-up-to-three-times-on-transient-errors.cs) | `PngOptions` | Implement a retry mechanism that attempts DICOM to PNG conversion up to three ti... |
| [implement-exception-handling-to-gracefully-skip-corrupted-dicom-files-during-batch-png-conversion.cs](./implement-exception-handling-to-gracefully-skip-corrupted-dicom-files-during-batch-png-conversion.cs) | `DicomImage`, `PngOptions` | Implement exception handling to gracefully skip corrupted DICOM files during bat... |
| [capture-and-log-aspose-imaging-exceptions-when-a-dicom-to-png-conversion-fails-due-to-corrupted-data.cs](./capture-and-log-aspose-imaging-exceptions-when-a-dicom-to-png-conversion-fails-due-to-corrupted-data.cs) | `PngOptions` | Capture and log Aspose.Imaging exceptions when a DICOM to PNG conversion fails d... |
| [use-a-using-statement-to-ensure-the-image-object-is-disposed-after-converting-dicom-to-png.cs](./use-a-using-statement-to-ensure-the-image-object-is-disposed-after-converting-dicom-to-png.cs) | `PngOptions` | Use a using statement to ensure the Image object is disposed after converting DI... |
| [save-the-resulting-png-image-to-a-memorystream-for-further-transmission-over-a-network.cs](./save-the-resulting-png-image-to-a-memorystream-for-further-transmission-over-a-network.cs) | `PngOptions` | Save the resulting PNG image to a MemoryStream for further transmission over a n... |
| [validate-that-the-pixel-data-remains-unchanged-after-converting-a-dicom-image-to-png-format.cs](./validate-that-the-pixel-data-remains-unchanged-after-converting-a-dicom-image-to-png-format.cs) | `DicomImage`, `PngImage`, `PngOptions` | Validate that the pixel data remains unchanged after converting a DICOM image to... |
| [validate-that-the-generated-png-files-are-viewable-in-standard-image-viewers-after-conversion.cs](./validate-that-the-generated-png-files-are-viewable-in-standard-image-viewers-after-conversion.cs) | `PngOptions` | Validate that the generated PNG files are viewable in standard image viewers aft... |
| [implement-asynchronous-dicom-to-png-conversion-using-task-run-to-avoid-blocking-the-ui-thread.cs](./implement-asynchronous-dicom-to-png-conversion-using-task-run-to-avoid-blocking-the-ui-thread.cs) | `DicomImage`, `PngOptions` | Implement asynchronous DICOM to PNG conversion using Task.Run to avoid blocking ... |
| [create-a-command-line-tool-that-accepts-a-dicom-file-path-and-outputs-a-png-file-to-a-folder.cs](./create-a-command-line-tool-that-accepts-a-dicom-file-path-and-outputs-a-png-file-to-a-folder.cs) | `DicomImage`, `PngOptions` | Create a command‑line tool that accepts a DICOM file path and outputs a PNG file... |
| [develop-a-unit-test-that-loads-a-sample-dicom-converts-it-to-png-and-compares-file-sizes.cs](./develop-a-unit-test-that-loads-a-sample-dicom-converts-it-to-png-and-compares-file-sizes.cs) | `PngOptions` | Develop a unit test that loads a sample DICOM, converts it to PNG, and compares ... |
| [integrate-dicom-to-png-conversion-into-an-asp-net-core-api-endpoint-returning-the-png-as-a-byte-array.cs](./integrate-dicom-to-png-conversion-into-an-asp-net-core-api-endpoint-returning-the-png-as-a-byte-array.cs) | `DicomImage`, `PngOptions` | Integrate DICOM to PNG conversion into an ASP.NET Core API endpoint returning th... |
| [create-a-windows-forms-application-that-allows-users-to-select-dicom-files-and-view-generated-png-previews.cs](./create-a-windows-forms-application-that-allows-users-to-select-dicom-files-and-view-generated-png-previews.cs) | `PngOptions` | Create a Windows Forms application that allows users to select DICOM files and v... |
| [write-a-powershell-script-that-invokes-the-net-conversion-library-to-process-dicom-files-in-bulk.cs](./write-a-powershell-script-that-invokes-the-net-conversion-library-to-process-dicom-files-in-bulk.cs) | `PngOptions` | Write a PowerShell script that invokes the .NET conversion library to process DI... |
| [configure-the-png-output-to-include-metadata-from-the-original-dicom-file-for-traceability.cs](./configure-the-png-output-to-include-metadata-from-the-original-dicom-file-for-traceability.cs) | `PngOptions` | Configure the PNG output to include metadata from the original DICOM file for tr... |
| [extract-the-patient-name-tag-from-dicom-metadata-and-embed-it-into-the-png-file-name.cs](./extract-the-patient-name-tag-from-dicom-metadata-and-embed-it-into-the-png-file-name.cs) | `DicomImage`, `PngOptions` | Extract the patient name tag from DICOM metadata and embed it into the PNG file ... |
| [apply-a-custom-color-palette-to-the-png-output-when-converting-grayscale-dicom-images.cs](./apply-a-custom-color-palette-to-the-png-output-when-converting-grayscale-dicom-images.cs) | `PngOptions` | Apply a custom color palette to the PNG output when converting grayscale DICOM i... |
| [create-a-logging-wrapper-that-records-start-and-end-timestamps-for-each-dicom-to-png-conversion-operation.cs](./create-a-logging-wrapper-that-records-start-and-end-timestamps-for-each-dicom-to-png-conversion-operation.cs) | `DicomImage`, `PngOptions` | Create a logging wrapper that records start and end timestamps for each DICOM to... |
| [develop-a-background-service-that-monitors-a-folder-for-new-dicom-files-and-automatically-converts-them-to-png.cs](./develop-a-background-service-that-monitors-a-folder-for-new-dicom-files-and-automatically-converts-them-to-png.cs) | `DicomImage`, `PngOptions` | Develop a background service that monitors a folder for new DICOM files and auto... |
| [document-the-conversion-process-in-code-comments-including-required-using-directives-and-disposal-patterns.cs](./document-the-conversion-process-in-code-comments-including-required-using-directives-and-disposal-patterns.cs) | `TiffOptions` | Document the conversion process in code comments, including required using direc... |

## Category Statistics
- Total examples: 30
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngOptions`
- `DicomImage`
- `DicomOptions`
- `LoadOptions`
- `MedianFilterOptions`
- `PngImage`
- `PngOptions`
- `RasterImage`
- `TiffOptions`

## Failed Tasks

All tasks passed ✅



## Use Cases
- A hospital IT team needs to integrate DICOM medical imaging C# code into their PACS workflow, converting incoming DICOM scans to PNG for web‑based viewers using Aspose.Imaging’s DICOM to PNG dotnet capabilities.  
- A research lab processes large batches of MRI studies and requires a script that extracts individual frames from multi‑frame DICOM files, applying medical image processing techniques before saving them as high‑resolution PNGs.  
- A tele‑radiology platform wants to generate thumbnail previews of DICOM images on the fly; the examples demonstrate how to resize and compress DICOM to PNG in a .NET microservice.  
- A medical device manufacturer needs to validate image quality by converting DICOM output from their scanners into PNG format for automated visual inspection pipelines written in C#.  
- An educational software developer is building a teaching tool that overlays annotations on DICOM scans; the provided code shows how to load DICOM files, perform pixel‑level medical image processing, and export the result as PNG for cross‑platform display.

## Related Categories  
The Convert DICOM Images examples complement the **Image Conversion** and **File Format Support** sections, where you can find similar workflows for JPEG, TIFF, and BMP transformations. If you need to apply advanced filters or color corrections before conversion, the **Image Editing** category offers ready‑to‑use routines that integrate seamlessly with DICOM handling. Additionally, the **Metadata Extraction** examples illustrate how to read patient and study information from DICOM files, which can be combined with the conversion scripts to build comprehensive medical imaging pipelines.


## Operations Covered
- Convert grayscale DICOM to PNG with custom palette  
- Batch convert multiple DICOM files to PNG while preserving original filenames  
- Set PNG compression level to balance file size and quality  
- Convert a DICOM image stored in a byte‑array to PNG using MemoryStream (in‑memory processing)  
- Log start and end timestamps for each DICOM‑to‑PNG conversion page  
- Monitor a folder for new DICOM files and automatically convert them to PNG (background service)  
- Apply a custom color palette to PNG output when converting DICOM images  
- Convert JPEG images to TIFF format  

## Supported Formats
- **PNG** – target format for all DICOM conversions and for JPEG‑to‑TIFF example (output)  
- **DICOM** – source medical image format being read and converted  
- **JPEG** – source format in the JPEG‑to‑TIFF example  
- **TIFF** – output format in the JPEG‑to‑TIFF example  

## API Classes Used
- `Image` — base class that loads an image file (e.g., DICOM) and provides the `Save` method.  
- `DicomImage` — represents a DICOM image; used to access individual frames/pages and to perform conversion.  
- `PngOptions` — holds PNG‑specific saving options such as compression level and custom palette.  
- `TiffOptions` — holds TIFF‑specific saving options (used when converting JPEG to TIFF).  
- `FileSystemWatcher` — .NET class that watches a directory for new DICOM files and triggers conversion (used in the background‑service example).  
- `MemoryStream` — .NET stream used to hold a DICOM byte array in memory for conversion without touching the file system.  
- `Directory` / `Path` — .NET utilities for ensuring output folders exist (supporting the conversion workflow).

<!-- AUTOGENERATED:START -->
Updated: 2026-08-20 | Run: `20260806_142654` | Examples: 30
<!-- AUTOGENERATED:END -->

## Developer Q&A

### Q: How can I apply a custom color palette when converting a grayscale DICOM image to PNG in C# with Aspose.Imaging?  
Use `PngOptions` to set the `Palette` property with a custom `ColorPalette` before calling `image.Save(outputPath, pngOptions)`. The DICOM image is loaded with `Image.Load(inputPath)`. → See: `apply-a-custom-color-palette-to-the-png-output-when-converting-grayscale-dicom-images.cs`

### Q: What is the easiest way to batch‑convert every DICOM file in a directory to PNG while preserving the original file names using Aspose.Imaging for .NET?  
Iterate through `Directory.GetFiles(inputDir, "*.dcm")`, load each file with `Image.Load`, and save it as PNG using `image.Save(Path.ChangeExtension(filePath, ".png"), new PngOptions())`. This keeps the base name unchanged. → See: `batch-convert-all-dicom-files-in-a-directory-to-png-format-while-preserving-original-filenames.cs`

### Q: How do I configure the PNG compression level in Aspose.Imaging to balance file size and image quality during DICOM‑to‑PNG conversion?  
Create a `PngOptions` instance and set its `CompressionLevel` (0‑9) before saving the image, e.g., `pngOptions.CompressionLevel = 6;`. Then call `image.Save(outputPath, pngOptions)`. → See: `configure-png-compression-level-in-pngoptions-to-balance-file-size-and-image-quality-during-conversion.cs`

### Q: How can I convert a DICOM image that is stored in a byte array to PNG entirely in memory using Aspose.Imaging and C#?  
Wrap the byte array in a `MemoryStream`, load the image with `Image.Load(memoryStream)`, and save to another `MemoryStream` using `image.Save(pngStream, new PngOptions())`. The resulting PNG bytes are obtained from `pngStream.ToArray()`. → See: `convert-a-dicom-image-stored-in-a-byte-array-to-png-by-using-memorystream-for-in-memory-processing.cs`

### Q: How can I implement a retry mechanism that attempts a DICOM‑to‑PNG conversion up to three times on transient errors with Aspose.Imaging?  
Enclose the conversion code in a loop that catches `ImageLoadException` (or other transient exceptions) and retries up to three attempts, breaking on success. Use `Image.Load` and `image.Save` inside the try block. → See: `implement-a-retry-mechanism-that-attempts-dicom-to-png-conversion-up-to-three-times-on-transient-errors.cs`