# CDR File Conversion with Aspose.Imaging for .NET  

Convert CorelDRAW (CDR) files to popular image and document formats directly from C#. The examples demonstrate CDR to JPG, PNG (with transparency), PDF (vector‑preserving) and other common scenarios using Aspose.Imaging for .NET.

## What's in This Category
- Load a single‑page CDR and export it as a high‑quality JPEG.  
- Convert a CDR page to PNG while preserving transparency.  
- Transform a CDR document into a PDF that retains vector data.  
- Control rasterization options such as DPI, color depth, and background color.  
- Combine CDR rasterization with other Aspose.Imaging features (e.g., image resizing).

## Quick Start  

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load the first page of a CDR file
using (var image = (CdrImage)Image.Load("sample.cdr"))
{
    // Export to high‑quality JPEG
    var jpegOptions = new JpegOptions { Quality = 100 };
    image.Save("sample.jpg", jpegOptions);
}
```

The snippet above shows the most common operation: opening a CorelDRAW CDR file and saving it as a JPEG image.

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

## Requirements  

- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9.0** or later  

## ↩️ Back to Main README  

[← Return to the repository root README](../README.md)