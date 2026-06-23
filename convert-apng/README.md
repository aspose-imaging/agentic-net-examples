# Convert APNG – Aspose.Imaging for .NET  

Create, edit, and export **APNG animation** files directly from C#. These samples show how to generate an **animated PNG** with custom frame delays, loop counts, and more using the Aspose.Imaging .NET library – the simplest way to **create APNG** in a .NET application.

## What's in This Category
- Load a single‑page PNG and turn it into an animated APNG with a uniform 100 ms frame delay.  
- Load a PNG image and build an APNG with per‑frame custom delays.  
- Assemble multiple PNG files into one APNG animation and specify a custom loop count.  
- Adjust existing APNG frames (e.g., replace a frame, change delay) before saving.  
- Export the resulting APNG to a stream or file for further processing.

## Quick Start  

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load a PNG, add two frames with different delays, and save as APNG
using (var png = Image.Load(@"input.png"))
{
    var apng = new ApngImage(png.Width, png.Height);
    apng.Frames.Add(new ApngFrame(png, delay: 50));   // 50 ms
    apng.Frames.Add(new ApngFrame(png, delay: 150));  // 150 ms

    var options = new ApngOptions { LoopCount = 0 }; // infinite loop
    apng.Save(@"output.apng", options);
}
```

The snippet demonstrates the most common operation: **creating an animated PNG in C#** with custom frame delays.

## Files

Examples and tasks in this folder:

| Example | |
|---------|---|
| [adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs](./adjust-apng-frame-delays-based-on-external-timing-data-stored-in-a-json-configuration-file.cs) |
| [batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs](./batch-convert-a-collection-of-svg-files-to-apng-assigning-each-svg-a-random-frame-delay.cs) |
| [batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs](./batch-convert-a-folder-of-webp-files-to-apng-format-applying-uniform-frame-delay.cs) |
| [batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs](./batch-convert-a-set-of-animated-webp-files-to-apng-generating-a-summary-csv-of-conversion-times.cs) |
| [batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs](./batch-convert-animated-webp-files-to-apng-preserving-original-frame-order-and-timing-metadata.cs) |
| [batch-process-a-directory-of-tiff-files-converting-each-to-apng-with-a-default-loop-count-of-three.cs](./batch-process-a-directory-of-tiff-files-converting-each-to-apng-with-a-default-loop-count-of-three.cs) |
| [batch-process-png-sequences-into-apng-files-logging-each-conversion-s-success-status-to-a-report.cs](./batch-process-png-sequences-into-apng-files-logging-each-conversion-s-success-status-to-a-report.cs) |
| [batch-process-tiff-files-to-apng-adjusting-each-animation-s-frame-delay-based-on-image-dimensions.cs](./batch-process-tiff-files-to-apng-adjusting-each-animation-s-frame-delay-based-on-image-dimensions.cs) |
| [convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs](./convert-a-batch-of-svg-files-into-individual-apng-animations-each-with-default-frame-delay.cs) |
| [convert-a-multi-page-tiff-to-apng-ensuring-each-frame-uses-lossless-compression-for-maximum-quality.cs](./convert-a-multi-page-tiff-to-apng-ensuring-each-frame-uses-lossless-compression-for-maximum-quality.cs) |
| [convert-a-multi-page-tiff-to-apng-using-each-page-s-resolution-to-determine-frame-display-duration.cs](./convert-a-multi-page-tiff-to-apng-using-each-page-s-resolution-to-determine-frame-display-duration.cs) |
| [convert-an-animated-apng-to-a-series-of-png-files-one-per-frame-for-further-processing.cs](./convert-an-animated-apng-to-a-series-of-png-files-one-per-frame-for-further-processing.cs) |
| [convert-an-animated-apng-to-a-static-png-by-extracting-the-first-frame-and-saving-it.cs](./convert-an-animated-apng-to-a-static-png-by-extracting-the-first-frame-and-saving-it.cs) |
| [convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs](./convert-an-animated-webp-file-to-an-apng-while-preserving-original-animation-timing.cs) |
| [convert-an-apng-to-a-series-of-bmp-files-for-compatibility-with-legacy-imaging-systems.cs](./convert-an-apng-to-a-series-of-bmp-files-for-compatibility-with-legacy-imaging-systems.cs) |
| [convert-an-apng-to-a-series-of-jpeg-images-naming-each-file-with-its-frame-index.cs](./convert-an-apng-to-a-series-of-jpeg-images-naming-each-file-with-its-frame-index.cs) |
| [convert-an-apng-to-a-series-of-tiff-images-preserving-each-frame-as-a-separate-page.cs](./convert-an-apng-to-a-series-of-tiff-images-preserving-each-frame-as-a-separate-page.cs) |
| [create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs](./create-an-animated-apng-using-an-svg-vector-graphic-defining-frame-dimensions-and-background-color.cs) |
| [create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs](./create-an-apng-from-a-png-sequence-stored-in-a-directory-using-alphabetical-file-naming.cs) |
| [create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs](./create-an-apng-from-a-series-of-pngs-assigning-each-frame-a-random-delay-between-50-and-150-ms.cs) |
| [export-an-apng-animation-to-gif-and-compare-visual-fidelity-using-ssim-metric.cs](./export-an-apng-animation-to-gif-and-compare-visual-fidelity-using-ssim-metric.cs) |
| [export-an-apng-animation-to-gif-and-verify-that-the-resulting-file-plays-correctly-in-major-browsers.cs](./export-an-apng-animation-to-gif-and-verify-that-the-resulting-file-plays-correctly-in-major-browsers.cs) |
| [export-an-apng-to-gif-and-embed-a-custom-application-identifier-in-the-gif-comment-block.cs](./export-an-apng-to-gif-and-embed-a-custom-application-identifier-in-the-gif-comment-block.cs) |
| [export-an-apng-to-gif-and-embed-frame-delay-information-in-the-gif-comment-extension.cs](./export-an-apng-to-gif-and-embed-frame-delay-information-in-the-gif-comment-extension.cs) |
| [export-an-apng-to-gif-and-include-a-timestamp-comment-indicating-conversion-date-and-time.cs](./export-an-apng-to-gif-and-include-a-timestamp-comment-indicating-conversion-date-and-time.cs) |
| [export-an-apng-to-gif-and-include-frame-specific-comments-indicating-original-frame-indices.cs](./export-an-apng-to-gif-and-include-frame-specific-comments-indicating-original-frame-indices.cs) |
| [export-an-existing-apng-animation-to-an-animated-gif-maintaining-original-frame-order.cs](./export-an-existing-apng-animation-to-an-animated-gif-maintaining-original-frame-order.cs) |
| [export-apng-animation-to-gif-format-while-reducing-color-palette-to-256-colors-for-compatibility.cs](./export-apng-animation-to-gif-format-while-reducing-color-palette-to-256-colors-for-compatibility.cs) |
| [generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs](./generate-an-apng-from-a-single-page-png-specifying-a-100-ms-delay-for-each-frame.cs) |
| [load-a-multi-page-tiff-assign-each-page-a-unique-frame-delay-and-compile-into-an-apng.cs](./load-a-multi-page-tiff-assign-each-page-a-unique-frame-delay-and-compile-into-an-apng.cs) |
| | [**View all 51 examples ↗**](https://github.com/aspose-imaging/agentic-net-examples/tree/main/convert-apng) |

## Requirements  

- **Aspose.Imaging for .NET** – install via NuGet: `Install-Package Aspose.Imaging`  
- **.NET 9** or later  

## Back to the main repository  

[← Root README](../README.md)