# CMX Image Conversion with Aspose.Imaging for .NET

Convert Corel Metafile (CMX) files to other formats using **Aspose.Imaging for .NET**. This collection shows how to load CMX images, inspect their pages, and export them—e.g., to TIFF—directly from C#.

## What's in This Category
- Load a CMX file from a local path using `Image.Load`.
- Detect whether a loaded CMX image contains multiple pages via `Image.IsMultiPage`.
- Convert a single‑page CMX image to a single‑page TIFF file with default compression.
- (Optional) Extend the pattern to convert CMX to PNG, JPEG, or other raster formats.

## Quick Start
The most common scenario is converting a CMX file to TIFF:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load the CMX image
using (Image cmxImage = Image.Load(@"C:\Images\sample.cmx"))
{
    // Save as TIFF (default compression)
    cmxImage.Save(@"C:\Images\sample.tiff", new TiffOptions());
}
```

Add the Aspose.Imaging package to your project and run the snippet on .NET 9 or later.

## Files

Examples and tasks in this folder:

| Example | Notes |
|---------|-------|
| [apply-rotation-to-cmx-image-before-converting-to-tiff-using-image-rotateflip-to-correct-orientation.cs](./apply-rotation-to-cmx-image-before-converting-to-tiff-using-image-rotateflip-to-correct-orientation.cs) | |
| [convert-a-cmx-image-to-jpeg-format-with-progressive-encoding-enabled-for-smoother-loading.cs](./convert-a-cmx-image-to-jpeg-format-with-progressive-encoding-enabled-for-smoother-loading.cs) | |
| [convert-a-cmx-image-to-jpeg-format-with-quality-set-to-90-using-jpegoptions.cs](./convert-a-cmx-image-to-jpeg-format-with-quality-set-to-90-using-jpegoptions.cs) | |
| [convert-a-cmx-image-to-pdf-format-embedding-fonts-as-subsets-for-smaller-files.cs](./convert-a-cmx-image-to-pdf-format-embedding-fonts-as-subsets-for-smaller-files.cs) | |
| [convert-a-cmx-image-to-pdf-format-with-a4-page-size-using-pdfoptions.cs](./convert-a-cmx-image-to-pdf-format-with-a4-page-size-using-pdfoptions.cs) | |
| [convert-a-multi-page-cmx-image-to-a-multi-page-tiff-file-preserving-original-page-order.cs](./convert-a-multi-page-cmx-image-to-a-multi-page-tiff-file-preserving-original-page-order.cs) | |
| [convert-a-multi-page-cmx-image-to-a-single-page-tiff-file-by-merging-pages.cs](./convert-a-multi-page-cmx-image-to-a-single-page-tiff-file-by-merging-pages.cs) | |
| [convert-a-single-page-cmx-image-to-a-multi-page-tiff-file-by-adding-blank-pages.cs](./convert-a-single-page-cmx-image-to-a-multi-page-tiff-file-by-adding-blank-pages.cs) | |
| [convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs](./convert-a-single-page-cmx-image-to-a-single-page-tiff-file-with-default-compression.cs) | |
| [convert-cmx-image-loaded-from-a-network-stream-to-pdf-and-write-to-response-stream.cs](./convert-cmx-image-loaded-from-a-network-stream-to-pdf-and-write-to-response-stream.cs) | |
| [convert-cmx-to-jpeg-using-a-custom-quality-setting-read-from-configuration-file.cs](./convert-cmx-to-jpeg-using-a-custom-quality-setting-read-from-configuration-file.cs) | |
| [convert-cmx-to-jpeg-with-custom-background-color-for-transparent-regions-to-avoid-artifacts.cs](./convert-cmx-to-jpeg-with-custom-background-color-for-transparent-regions-to-avoid-artifacts.cs) | |
| [convert-cmx-to-jpeg-with-exif-orientation-tag-preserved-from-source-image.cs](./convert-cmx-to-jpeg-with-exif-orientation-tag-preserved-from-source-image.cs) | |
| [convert-cmx-to-multi-page-pdf-where-each-cmx-page-becomes-a-separate-pdf-page.cs](./convert-cmx-to-multi-page-pdf-where-each-cmx-page-becomes-a-separate-pdf-page.cs) | |
| [convert-cmx-to-pdf-with-custom-document-title-set-via-pdfoptions-title-for-identification.cs](./convert-cmx-to-pdf-with-custom-document-title-set-via-pdfoptions-title-for-identification.cs) | |
| [convert-cmx-to-single-page-pdf-by-flattening-all-pages-onto-one-page.cs](./convert-cmx-to-single-page-pdf-by-flattening-all-pages-onto-one-page.cs) | |
| [convert-cmx-to-tiff-using-a-custom-image-encoder-to-embed-custom-tags.cs](./convert-cmx-to-tiff-using-a-custom-image-encoder-to-embed-custom-tags.cs) | |
| [convert-cmx-to-tiff-with-custom-color-depth-of-8-bits-per-pixel.cs](./convert-cmx-to-tiff-with-custom-color-depth-of-8-bits-per-pixel.cs) | |
| [create-a-console-application-that-accepts-input-cmx-path-and-output-format-as-arguments.cs](./create-a-console-application-that-accepts-input-cmx-path-and-output-format-as-arguments.cs) | |
| [detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs](./detect-whether-the-loaded-cmx-image-contains-multiple-pages-using-the-image-ismultipage-property.cs) | |
| [generate-a-thumbnail-of-a-cmx-image-before-conversion-using-image-resize-for-preview.cs](./generate-a-thumbnail-of-a-cmx-image-before-conversion-using-image-resize-for-preview.cs) | |
| [implement-asynchronous-conversion-of-cmx-to-jpeg-using-async-await-pattern-for-non-blocking-ui.cs](./implement-asynchronous-conversion-of-cmx-to-jpeg-using-async-await-pattern-for-non-blocking-ui.cs) | |
| [implement-logging-of-conversion-parameters-using-nlog-for-each-cmx-conversion-operation.cs](./implement-logging-of-conversion-parameters-using-nlog-for-each-cmx-conversion-operation.cs) | |
| [load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs](./load-a-cmx-file-from-a-local-path-using-the-image-load-method.cs) | |
| [optimize-memory-usage-when-converting-large-multi-page-cmx-files-by-streaming-pages.cs](./optimize-memory-usage-when-converting-large-multi-page-cmx-files-by-streaming-pages.cs) | |
| [preserve-cmx-metadata-when-converting-to-pdf-by-copying-imageproperties-to-the-pdf-document.cs](./preserve-cmx-metadata-when-converting-to-pdf-by-copying-imageproperties-to-the-pdf-document.cs) | |
| [save-converted-tiff-images-with-ccitt-group-4-compression-for-monochrome-output.cs](./save-converted-tiff-images-with-ccitt-group-4-compression-for-monochrome-output.cs) | |
| [save-converted-tiff-images-with-lzw-compression-and-verify-file-size-reduction.cs](./save-converted-tiff-images-with-lzw-compression-and-verify-file-size-reduction.cs) | |
| [set-dpi-of-output-jpeg-image-to-300-using-jpegoptions-resolutionx-and-resolutiony.cs](./set-dpi-of-output-jpeg-image-to-300-using-jpegoptions-resolutionx-and-resolutiony.cs) | |
| [use-aspose-imaging-to-convert-cmx-stream-from-memory-to-tiff-without-temporary-files.cs](./use-aspose-imaging-to-convert-cmx-stream-from-memory-to-tiff-without-temporary-files.cs) | |
| *...and 4 more files* | [View all ↗](https://github.com/aspose-imaging/agentic-net-examples/tree/main/convert-cmx-images) |

## Requirements
- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9** or later

[← Back to main README](../README.md)