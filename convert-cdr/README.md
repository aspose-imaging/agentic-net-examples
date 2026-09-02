# Convert CDR to PNG with Maximum Compression in C# (Aspose.Imaging for .NET)

A set of ready‑to‑run C# examples that show how to use **Aspose.Imaging for .NET** – a UI‑agnostic backend API that works in ASP.NET Core, console apps, Azure Functions, and Docker – to transform CorelDRAW **.cdr** files into raster and layered formats.  
The samples cover:

* Adjusting PNG compression to the maximum level while converting a CDR file.  
* Performing lossless PNG conversion that preserves the original image dimensions.  
* Batch converting CDR files to JPG with timestamped filenames.  
* Batch converting CDR files to PSD while keeping the original layer structure.  
* Converting a CDR byte array directly to a PNG memory stream.

## What You Can Do

- **Maximum‑compression PNG** – Convert a single `sample.cdr` to `sample.png` using the highest PNG compression settings.  
- **Lossless PNG** – Convert a CDR to PNG without any quality loss, retaining the original width and height.  
- **Batch JPG conversion** – Process every `*.cdr` in a folder and output JPG files named `OriginalFile_yyyyMMdd_HHmmss.jpg`.  
- **Batch PSD conversion** – Transform a collection of CDR files into separate PSD files, preserving each file’s layer hierarchy.  
- **Byte‑array to PNG stream** – Load a CDR from a `byte[]`, convert it to PNG, and obtain the result as a `MemoryStream` for further processing.

## Quick Start

```csharp
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Input CDR file
        string inputPath = "Input/sample.cdr";
        // Output PNG with maximum compression
        string outputPath = "Output/sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the CDR image
        using (Image cdrImage = Image.Load(inputPath))
        {
            // Set PNG options to maximum compression (level 9)
            var pngOptions = new PngOptions
            {
                CompressionLevel = PngCompressionLevel.BestCompression
            };

            // Save as PNG
            cdrImage.Save(outputPath, pngOptions);
            Console.WriteLine($"Converted to PNG with maximum compression: {outputPath}");
        }
    }
}
```

Run the snippet in a .NET 9.0 console project after installing the Aspose.Imaging package.

## Requirements

- .NET 9.0 SDK
- Aspose.Imaging for .NET  

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
| [adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs](./adjust-png-compression-to-maximum-while-converting-a-cdr-file-to-png-in-c.cs) |
| [apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs](./apply-a-custom-jpeg-encoder-setting-to-embed-exif-metadata-during-cdr-to-jpg-conversion-in-c.cs) |
| [apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs](./apply-lossless-compression-to-a-cdr-to-png-conversion-while-maintaining-original-dimensions-in-c.cs) |
| [batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs](./batch-convert-a-folder-of-cdr-files-to-jpg-images-with-default-settings-using-c.cs) |
| [batch-convert-cdr-files-to-jpg-naming-each-output-with-the-original-filename-plus-timestamp-in-c.cs](./batch-convert-cdr-files-to-jpg-naming-each-output-with-the-original-filename-plus-timestamp-in-c.cs) |
| [batch-export-cdr-files-to-png-format-by-iterating-through-a-directory-with-c-loops.cs](./batch-export-cdr-files-to-png-format-by-iterating-through-a-directory-with-c-loops.cs) |
| [batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs](./batch-transform-a-collection-of-cdr-files-into-separate-psd-files-retaining-original-layer-structure-in-c.cs) |
| [combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs](./combine-multiple-cdr-documents-into-a-single-pdf-preserving-page-order-via-c.cs) |
| [convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs](./convert-a-cdr-file-from-a-byte-array-to-png-and-output-to-a-memory-stream-in-c.cs) |
| [convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs](./convert-a-cdr-file-from-a-memory-stream-directly-to-jpg-without-intermediate-files-in-c.cs) |
| [convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs](./convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs) |
| [convert-each-page-of-a-multi-page-cdr-document-into-individual-psd-files-preserving-color-depth-in-c.cs](./convert-each-page-of-a-multi-page-cdr-document-into-individual-psd-files-preserving-color-depth-in-c.cs) |
| [define-custom-pdf-page-size-a4-when-converting-a-multi-page-cdr-document-to-pdf-using-c.cs](./define-custom-pdf-page-size-a4-when-converting-a-multi-page-cdr-document-to-pdf-using-c.cs) |
| [ensure-fonts-are-embedded-in-the-pdf-output-when-converting-a-cdr-file-with-embedded-fonts-using-c.cs](./ensure-fonts-are-embedded-in-the-pdf-output-when-converting-a-cdr-file-with-embedded-fonts-using-c.cs) |
| [export-a-single-page-cdr-file-to-psd-format-maintaining-layers-using-c.cs](./export-a-single-page-cdr-file-to-psd-format-maintaining-layers-using-c.cs) |
| [generate-a-pdf-with-embedded-fonts-when-converting-a-cdr-file-to-pdf-using-c.cs](./generate-a-pdf-with-embedded-fonts-when-converting-a-cdr-file-to-pdf-using-c.cs) |
| [implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs](./implement-progress-reporting-while-batch-converting-cdr-files-to-jpg-updating-a-console-progress-bar-in-c.cs) |
| [load-a-multi-page-cdr-file-and-generate-separate-pdf-pages-for-each-vector-page-in-c.cs](./load-a-multi-page-cdr-file-and-generate-separate-pdf-pages-for-each-vector-page-in-c.cs) |
| [load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs](./load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs) |
| [preserve-alpha-channel-when-converting-a-cdr-file-to-png-by-configuring-png-options-in-c.cs](./preserve-alpha-channel-when-converting-a-cdr-file-to-png-by-configuring-png-options-in-c.cs) |
| [resize-a-cdr-to-jpg-conversion-output-to-1024-768-pixels-during-saving-in-c.cs](./resize-a-cdr-to-jpg-conversion-output-to-1024-768-pixels-during-saving-in-c.cs) |
| [retain-layer-groups-when-exporting-a-cdr-file-to-psd-by-enabling-layer-preservation-in-c.cs](./retain-layer-groups-when-exporting-a-cdr-file-to-psd-by-enabling-layer-preservation-in-c.cs) |
| [set-jpeg-quality-to-90-before-saving-a-cdr-conversion-to-jpg-using-c-options.cs](./set-jpeg-quality-to-90-before-saving-a-cdr-conversion-to-jpg-using-c-options.cs) |
| [set-pdf-version-to-1-7-for-compatibility-when-converting-a-cdr-file-to-pdf-in-c.cs](./set-pdf-version-to-1-7-for-compatibility-when-converting-a-cdr-file-to-pdf-in-c.cs) |
| [set-psd-resolution-to-300-dpi-for-print-quality-when-converting-a-cdr-file-in-c.cs](./set-psd-resolution-to-300-dpi-for-print-quality-when-converting-a-cdr-file-in-c.cs) |
| [specify-16-bit-color-depth-for-psd-output-when-converting-a-cdr-file-to-psd-in-c.cs](./specify-16-bit-color-depth-for-psd-output-when-converting-a-cdr-file-to-psd-in-c.cs) |
| [transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs](./transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs) |
| [use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs](./use-asynchronous-methods-to-convert-a-cdr-file-to-pdf-improving-ui-responsiveness-in-c.cs) |
| [verify-that-a-jpg-file-created-from-cdr-conversion-exists-and-has-non-zero-size-in-c.cs](./verify-that-a-jpg-file-created-from-cdr-conversion-exists-and-has-non-zero-size-in-c.cs) |
| [wrap-cdr-to-jpg-conversion-in-try-catch-blocks-to-log-runtime-exceptions-in-c.cs](./wrap-cdr-to-jpg-conversion-in-try-catch-blocks-to-log-runtime-exceptions-in-c.cs) |
[**View all 30 examples →**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/convert-cdr)