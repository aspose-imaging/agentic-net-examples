---
name: convert-open-document-graphics
description: C# examples for Convert Open Document Graphics using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Convert Open Document Graphics

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Convert Open Document Graphics** category.
This folder contains standalone C# examples for Convert Open Document Graphics operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using Aspose.Imaging;` (122/120 files) ← category-specific
- `using System;` (120/120 files)
- `using System.IO;` (120/120 files)
- `using Aspose.Imaging.ImageOptions;` (119/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.OpenDocument;` (25/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (14/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (8/120 files) ← category-specific
- `using Aspose.Imaging.ImageFilters.FilterOptions;` (8/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (7/120 files) ← category-specific
- `using System.Threading.Tasks;` (4/120 files)
- `using Aspose.Imaging.Sources;` (4/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (4/120 files) ← category-specific
- `using System.Xml;` (2/120 files)
- `using System.Xml.Schema;` (2/120 files)
- `using System.Net.Sockets;` (2/120 files)
- `using System.Linq;` (2/120 files)
- `using System.Diagnostics;` (2/120 files)
- `using System.Xml.Linq;` (2/120 files)
- `using System.Reflection;` (2/120 files)
- `using Aspose.Imaging.Brushes;` (2/120 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Png;` (1/120 files) ← category-specific
- `using System.Text;` (1/120 files)
- `using System.Text.RegularExpressions;` (1/120 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs](./load-an-odg-file-and-save-it-as-a-png-image-using-image-save.cs) | `OdgRasterizationOptions`, `PngOptions` | Load an ODG file and save it as a PNG image using Image.Save. |
| [load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs](./load-an-odg-file-and-convert-it-to-jpeg-format-with-default-compression-settings.cs) | `JpegOptions`, `VectorRasterizationOptions` | Load an ODG file and convert it to JPEG format with default compression settings... |
| [load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs](./load-an-odg-file-and-export-it-as-a-bmp-image-preserving-original-dimensions.cs) | `BmpOptions`, `OdgImage`, `OdgRasterizationOptions` | Load an ODG file and export it as a BMP image preserving original dimensions. |
| [load-an-odg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs](./load-an-odg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs) | `OdgRasterizationOptions`, `PdfOptions` | Load an ODG file and save it as a PDF document using default PDF options. |
| [load-an-odg-file-and-convert-it-to-svg-while-preserving-vector-information.cs](./load-an-odg-file-and-convert-it-to-svg-while-preserving-vector-information.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load an ODG file and convert it to SVG while preserving vector information. |
| [load-an-otg-file-and-save-it-as-a-png-image-with-default-rasterization-settings.cs](./load-an-otg-file-and-save-it-as-a-png-image-with-default-rasterization-settings.cs) | `OtgRasterizationOptions`, `PngOptions` | Load an OTG file and save it as a PNG image with default rasterization settings. |
| [load-an-otg-file-and-convert-it-to-jpeg-format-applying-standard-quality-level.cs](./load-an-otg-file-and-convert-it-to-jpeg-format-applying-standard-quality-level.cs) | `JpegOptions`, `OtgRasterizationOptions` | Load an OTG file and convert it to JPEG format applying standard quality level. |
| [load-an-otg-file-and-export-it-as-a-bmp-image-maintaining-original-size.cs](./load-an-otg-file-and-export-it-as-a-bmp-image-maintaining-original-size.cs) | `BmpOptions`, `OtgRasterizationOptions` | Load an OTG file and export it as a BMP image maintaining original size. |
| [load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs](./load-an-otg-file-and-save-it-as-a-pdf-document-using-default-pdf-options.cs) | `OtgRasterizationOptions`, `PdfOptions` | Load an OTG file and save it as a PDF document using default PDF options. |
| [load-an-otg-file-and-convert-it-to-svg-while-keeping-vector-data-intact.cs](./load-an-otg-file-and-convert-it-to-svg-while-keeping-vector-data-intact.cs) | `OtgRasterizationOptions`, `SvgOptions` | Load an OTG file and convert it to SVG while keeping vector data intact. |
| [create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs](./create-rasterizationoptions-for-odg-set-resolution-and-save-the-image-as-png.cs) | `OdgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for ODG, set resolution, and save the image as PNG. |
| [create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-odg-configure-jpeg-quality-and-save-as-jpeg-file.cs) | `JpegOptions`, `OdgRasterizationOptions` | Create RasterizationOptions for ODG, configure JPEG quality, and save as JPEG fi... |
| [create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs](./create-rasterizationoptions-for-otg-set-background-color-and-save-as-png-image.cs) | `OtgRasterizationOptions`, `PngOptions` | Create RasterizationOptions for OTG, set background color, and save as PNG image... |
| [create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs](./create-rasterizationoptions-for-otg-define-jpeg-compression-level-and-save-as-jpeg-file.cs) | `JpegOptions`, `OtgRasterizationOptions` | Create RasterizationOptions for OTG, define JPEG compression level, and save as ... |
| [load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-odg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load ODG and save as SVG while preserving all vector layers and attributes. |
| [load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs](./load-otg-and-save-as-svg-while-preserving-all-vector-layers-and-attributes.cs) | `SvgOptions`, `SvgRasterizationOptions` | Load OTG and save as SVG while preserving all vector layers and attributes. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-png.cs) | `MedianFilterOptions`, `OdgRasterizationOptions`, `PngOptions` | Apply a median filter to an ODG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-png.cs) | `MedianFilterOptions`, `OtgRasterizationOptions`, `PngOptions` | Apply a median filter to an OTG image before converting and saving it as PNG. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `MedianFilterOptions`, `RasterImage` | Apply a median filter to an ODG image before converting and saving it as BMP. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-bmp.cs) | `BmpOptions`, `MedianFilterOptions`, `OtgRasterizationOptions` | Apply a median filter to an OTG image before converting and saving it as BMP. |
| [iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs](./iterate-over-a-folder-of-odg-files-and-batch-convert-each-to-png-format.cs) | `PngOptions`, `VectorRasterizationOptions` | Iterate over a folder of ODG files and batch convert each to PNG format. |
| [iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs](./iterate-over-a-folder-of-otg-files-and-batch-convert-each-to-pdf-format.cs) | `PdfOptions`, `VectorRasterizationOptions` | Iterate over a folder of OTG files and batch convert each to PDF format. |
| [convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-odg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `PdfOptions`, `VectorRasterizationOptions` | Convert an ODG file to PDF while specifying a custom page size for the document. |
| [convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs](./convert-an-otg-file-to-pdf-while-specifying-a-custom-page-size-for-the-document.cs) | `PdfOptions`, `VectorRasterizationOptions` | Convert an OTG file to PDF while specifying a custom page size for the document. |
| [convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-odg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions` | Convert an ODG file to JPEG and set the output quality to 85 percent. |
| [convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs](./convert-an-otg-file-to-jpeg-and-set-the-output-quality-to-85-percent.cs) | `JpegOptions`, `OtgRasterizationOptions` | Convert an OTG file to JPEG and set the output quality to 85 percent. |
| [convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-odg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions` | Convert an ODG file to BMP while preserving transparency information in the outp... |
| [convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs](./convert-an-otg-file-to-bmp-while-preserving-transparency-information-in-the-output-image.cs) | `BmpOptions`, `OtgRasterizationOptions` | Convert an OTG file to BMP while preserving transparency information in the outp... |
| [convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-odg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `OdgRasterizationOptions`, `SvgOptions` | Convert an ODG file to SVG and ensure original layer names are retained in the o... |
| [convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs](./convert-an-otg-file-to-svg-and-ensure-original-layer-names-are-retained-in-the-output.cs) | `OtgRasterizationOptions`, `SvgOptions` | Convert an OTG file to SVG and ensure original layer names are retained in the o... |
| [load-an-odg-file-from-a-memory-stream-and-save-it-as-png-using-image-save.cs](./load-an-odg-file-from-a-memory-stream-and-save-it-as-png-using-image-save.cs) | `PngOptions` | Load an ODG file from a memory stream and save it as PNG using Image.Save. |
| [load-an-otg-file-from-a-memory-stream-and-save-it-as-png-using-image-save.cs](./load-an-otg-file-from-a-memory-stream-and-save-it-as-png-using-image-save.cs) | `OtgRasterizationOptions`, `PngOptions` | Load an OTG file from a memory stream and save it as PNG using Image.Save. |
| [save-an-odg-image-as-png-while-retaining-all-original-metadata-properties.cs](./save-an-odg-image-as-png-while-retaining-all-original-metadata-properties.cs) | `PngOptions`, `VectorRasterizationOptions` | Save an ODG image as PNG while retaining all original metadata properties. |
| [save-an-otg-image-as-png-while-retaining-all-original-metadata-properties.cs](./save-an-otg-image-as-png-while-retaining-all-original-metadata-properties.cs) | `OtgRasterizationOptions`, `PngOptions` | Save an OTG image as PNG while retaining all original metadata properties. |
| [convert-an-odg-file-to-pdf-and-embed-the-necessary-fonts-for-accurate-rendering.cs](./convert-an-odg-file-to-pdf-and-embed-the-necessary-fonts-for-accurate-rendering.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF and embed the necessary fonts for accurate rendering. |
| [convert-an-otg-file-to-pdf-and-embed-the-necessary-fonts-for-accurate-rendering.cs](./convert-an-otg-file-to-pdf-and-embed-the-necessary-fonts-for-accurate-rendering.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF and embed the necessary fonts for accurate rendering. |
| [use-task-parallel-library-to-convert-multiple-odg-files-to-png-concurrently-for-faster-processing.cs](./use-task-parallel-library-to-convert-multiple-odg-files-to-png-concurrently-for-faster-processing.cs) | `OdgRasterizationOptions`, `PngOptions` | Use Task Parallel Library to convert multiple ODG files to PNG concurrently for ... |
| [use-task-parallel-library-to-convert-multiple-otg-files-to-pdf-concurrently-for-faster-processing.cs](./use-task-parallel-library-to-convert-multiple-otg-files-to-pdf-concurrently-for-faster-processing.cs) | `OtgRasterizationOptions`, `PdfOptions` | Use Task Parallel Library to convert multiple OTG files to PDF concurrently for ... |
| [set-dpi-to-300-when-rasterizing-an-odg-file-to-jpeg-for-high-resolution-output.cs](./set-dpi-to-300-when-rasterizing-an-odg-file-to-jpeg-for-high-resolution-output.cs) | `JpegOptions`, `OdgRasterizationOptions` | Set DPI to 300 when rasterizing an ODG file to JPEG for high‑resolution output. |
| [set-dpi-to-300-when-rasterizing-an-otg-file-to-jpeg-for-high-resolution-output.cs](./set-dpi-to-300-when-rasterizing-an-otg-file-to-jpeg-for-high-resolution-output.cs) | `JpegOptions`, `OtgRasterizationOptions` | Set DPI to 300 when rasterizing an OTG file to JPEG for high‑resolution output. |
| [apply-a-specific-icc-color-profile-to-an-odg-image-before-saving-it-as-png.cs](./apply-a-specific-icc-color-profile-to-an-odg-image-before-saving-it-as-png.cs) | `PngOptions` | Apply a specific ICC color profile to an ODG image before saving it as PNG. |
| [apply-a-specific-icc-color-profile-to-an-otg-image-before-saving-it-as-png.cs](./apply-a-specific-icc-color-profile-to-an-otg-image-before-saving-it-as-png.cs) | `PngOptions` | Apply a specific ICC color profile to an OTG image before saving it as PNG. |
| [convert-an-odg-file-to-bmp-using-an-8-bit-palette-to-reduce-file-size.cs](./convert-an-odg-file-to-bmp-using-an-8-bit-palette-to-reduce-file-size.cs) | `BmpOptions`, `OdgRasterizationOptions`, `RasterImage` | Convert an ODG file to BMP using an 8‑bit palette to reduce file size. |
| [convert-an-otg-file-to-bmp-using-an-8-bit-palette-to-reduce-file-size.cs](./convert-an-otg-file-to-bmp-using-an-8-bit-palette-to-reduce-file-size.cs) | `BmpOptions`, `OtgRasterizationOptions`, `RasterImage` | Convert an OTG file to BMP using an 8‑bit palette to reduce file size. |
| [convert-an-odg-file-to-png-with-interlacing-enabled-for-progressive-rendering.cs](./convert-an-odg-file-to-png-with-interlacing-enabled-for-progressive-rendering.cs) | `PngOptions` | Convert an ODG file to PNG with interlacing enabled for progressive rendering. |
| [convert-an-otg-file-to-png-with-interlacing-enabled-for-progressive-rendering.cs](./convert-an-otg-file-to-png-with-interlacing-enabled-for-progressive-rendering.cs) | `OtgRasterizationOptions`, `PngOptions` | Convert an OTG file to PNG with interlacing enabled for progressive rendering. |
| [convert-an-odg-file-to-pdf-and-set-a-specific-compression-level-for-the-output.cs](./convert-an-odg-file-to-pdf-and-set-a-specific-compression-level-for-the-output.cs) | `OdgRasterizationOptions`, `PdfCoreOptions`, `PdfOptions` | Convert an ODG file to PDF and set a specific compression level for the output. |
| [convert-an-otg-file-to-pdf-and-set-a-specific-compression-level-for-the-output.cs](./convert-an-otg-file-to-pdf-and-set-a-specific-compression-level-for-the-output.cs) | `OtgRasterizationOptions`, `PdfCoreOptions`, `PdfOptions` | Convert an OTG file to PDF and set a specific compression level for the output. |
| [validate-the-generated-svg-from-an-odg-conversion-against-the-svg-xml-schema.cs](./validate-the-generated-svg-from-an-odg-conversion-against-the-svg-xml-schema.cs) | `SvgOptions`, `SvgRasterizationOptions` | Validate the generated SVG from an ODG conversion against the SVG XML schema. |
| [validate-the-generated-svg-from-an-otg-conversion-against-the-svg-xml-schema.cs](./validate-the-generated-svg-from-an-otg-conversion-against-the-svg-xml-schema.cs) | `SvgImage` | Validate the generated SVG from an OTG conversion against the SVG XML schema. |
| [apply-a-gaussian-blur-filter-to-an-odg-image-before-converting-and-saving-as-jpeg.cs](./apply-a-gaussian-blur-filter-to-an-odg-image-before-converting-and-saving-as-jpeg.cs) | `GaussianBlurFilterOptions`, `JpegOptions`, `PngOptions` | Apply a Gaussian blur filter to an ODG image before converting and saving as JPE... |
| [apply-a-gaussian-blur-filter-to-an-otg-image-before-converting-and-saving-as-jpeg.cs](./apply-a-gaussian-blur-filter-to-an-otg-image-before-converting-and-saving-as-jpeg.cs) | `GaussianBlurFilterOptions`, `JpegOptions`, `OtgRasterizationOptions` | Apply a Gaussian blur filter to an OTG image before converting and saving as JPE... |
| [load-an-odg-file-convert-it-to-png-and-write-the-result-into-a-memorystream.cs](./load-an-odg-file-convert-it-to-png-and-write-the-result-into-a-memorystream.cs) | `PngOptions` | Load an ODG file, convert it to PNG, and write the result into a MemoryStream. |
| [load-an-otg-file-convert-it-to-png-and-write-the-result-into-a-memorystream.cs](./load-an-otg-file-convert-it-to-png-and-write-the-result-into-a-memorystream.cs) | `OtgRasterizationOptions`, `PngOptions` | Load an OTG file, convert it to PNG, and write the result into a MemoryStream. |
| [load-an-odg-file-convert-it-to-jpeg-and-send-the-output-through-a-network-stream.cs](./load-an-odg-file-convert-it-to-jpeg-and-send-the-output-through-a-network-stream.cs) | `JpegOptions` | Load an ODG file, convert it to JPEG, and send the output through a network stre... |
| [load-an-otg-file-convert-it-to-jpeg-and-send-the-output-through-a-network-stream.cs](./load-an-otg-file-convert-it-to-jpeg-and-send-the-output-through-a-network-stream.cs) | `JpegOptions`, `OtgRasterizationOptions` | Load an OTG file, convert it to JPEG, and send the output through a network stre... |
| [iterate-over-mixed-odg-and-otg-files-batch-convert-each-to-svg-while-preserving-vectors.cs](./iterate-over-mixed-odg-and-otg-files-batch-convert-each-to-svg-while-preserving-vectors.cs) | `SvgOptions`, `SvgRasterizationOptions` | Iterate over mixed ODG and OTG files, batch convert each to SVG while preserving... |
| [iterate-over-mixed-odg-and-otg-files-batch-convert-each-to-pdf-with-uniform-page-size.cs](./iterate-over-mixed-odg-and-otg-files-batch-convert-each-to-pdf-with-uniform-page-size.cs) | `OdgRasterizationOptions`, `OtgRasterizationOptions`, `PdfOptions` | Iterate over mixed ODG and OTG files, batch convert each to PDF with uniform pag... |
| [convert-an-odg-file-to-png-and-ensure-transparent-background-is-correctly-maintained.cs](./convert-an-odg-file-to-png-and-ensure-transparent-background-is-correctly-maintained.cs) | `OdgRasterizationOptions`, `PngOptions` | Convert an ODG file to PNG and ensure transparent background is correctly mainta... |
| [convert-an-otg-file-to-png-and-ensure-transparent-background-is-correctly-maintained.cs](./convert-an-otg-file-to-png-and-ensure-transparent-background-is-correctly-maintained.cs) | `OtgRasterizationOptions`, `PngOptions` | Convert an OTG file to PNG and ensure transparent background is correctly mainta... |
| [convert-an-odg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs](./convert-an-odg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs) | `JpegOptions` | Convert an ODG file to JPEG using progressive encoding for faster web loading. |
| [convert-an-otg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs](./convert-an-otg-file-to-jpeg-using-progressive-encoding-for-faster-web-loading.cs) | `JpegOptions`, `OtgRasterizationOptions` | Convert an OTG file to JPEG using progressive encoding for faster web loading. |
| [convert-an-odg-file-to-bmp-and-specify-a-custom-resolution-of-150-dpi.cs](./convert-an-odg-file-to-bmp-and-specify-a-custom-resolution-of-150-dpi.cs) | `BmpImage`, `BmpOptions`, `OdgImage` | Convert an ODG file to BMP and specify a custom resolution of 150 DPI. |
| [convert-an-otg-file-to-bmp-and-specify-a-custom-resolution-of-150-dpi.cs](./convert-an-otg-file-to-bmp-and-specify-a-custom-resolution-of-150-dpi.cs) | `BmpImage`, `BmpOptions`, `OtgRasterizationOptions` | Convert an OTG file to BMP and specify a custom resolution of 150 DPI. |
| [configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-odg-to-png-for-smoother-visual-results.cs](./configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-odg-to-png-for-smoother-visual-results.cs) | `OdgRasterizationOptions`, `PngOptions` | Configure RasterizationOptions to enable anti‑aliasing when converting ODG to PN... |
| [configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-otg-to-png-for-smoother-results.cs](./configure-rasterizationoptions-to-enable-anti-aliasing-when-converting-otg-to-png-for-smoother-results.cs) | `OtgRasterizationOptions`, `PngOptions` | Configure RasterizationOptions to enable anti‑aliasing when converting OTG to PN... |
| [convert-an-odg-file-to-pdf-and-add-password-protection-to-restrict-access.cs](./convert-an-odg-file-to-pdf-and-add-password-protection-to-restrict-access.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF and add password protection to restrict access. |
| [convert-an-otg-file-to-pdf-and-add-password-protection-to-restrict-access.cs](./convert-an-otg-file-to-pdf-and-add-password-protection-to-restrict-access.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF and add password protection to restrict access. |
| [convert-an-odg-file-to-svg-and-embed-css-styles-for-consistent-appearance.cs](./convert-an-odg-file-to-svg-and-embed-css-styles-for-consistent-appearance.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an ODG file to SVG and embed CSS styles for consistent appearance. |
| [convert-an-otg-file-to-svg-and-embed-css-styles-for-consistent-appearance.cs](./convert-an-otg-file-to-svg-and-embed-css-styles-for-consistent-appearance.cs) | `OtgRasterizationOptions`, `SvgOptions` | Convert an OTG file to SVG and embed CSS styles for consistent appearance. |
| [load-an-odg-image-crop-a-specific-region-and-save-the-result-as-png.cs](./load-an-odg-image-crop-a-specific-region-and-save-the-result-as-png.cs) | `OdgImage`, `PngOptions` | Load an ODG image, crop a specific region, and save the result as PNG. |
| [load-an-otg-image-crop-a-specific-region-and-save-the-result-as-png.cs](./load-an-otg-image-crop-a-specific-region-and-save-the-result-as-png.cs) | `PngOptions` | Load an OTG image, crop a specific region, and save the result as PNG. |
| [load-an-odg-file-rotate-it-ninety-degrees-clockwise-and-save-as-jpeg.cs](./load-an-odg-file-rotate-it-ninety-degrees-clockwise-and-save-as-jpeg.cs) | `JpegOptions`, `OdgImage` | Load an ODG file, rotate it ninety degrees clockwise, and save as JPEG. |
| [load-an-otg-file-rotate-it-ninety-degrees-clockwise-and-save-as-jpeg.cs](./load-an-otg-file-rotate-it-ninety-degrees-clockwise-and-save-as-jpeg.cs) | `JpegOptions` | Load an OTG file, rotate it ninety degrees clockwise, and save as JPEG. |
| [convert-an-odg-file-to-png-and-log-the-conversion-time-for-performance-analysis.cs](./convert-an-odg-file-to-png-and-log-the-conversion-time-for-performance-analysis.cs) | `OdgRasterizationOptions`, `PngOptions` | Convert an ODG file to PNG and log the conversion time for performance analysis. |
| [convert-an-otg-file-to-png-and-log-the-conversion-time-for-performance-analysis.cs](./convert-an-otg-file-to-png-and-log-the-conversion-time-for-performance-analysis.cs) | `OtgRasterizationOptions`, `PngOptions` | Convert an OTG file to PNG and log the conversion time for performance analysis. |
| [convert-an-odg-file-to-pdf-and-include-custom-metadata-such-as-author-and-title.cs](./convert-an-odg-file-to-pdf-and-include-custom-metadata-such-as-author-and-title.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF and include custom metadata such as author and title. |
| [convert-an-otg-file-to-pdf-and-include-custom-metadata-such-as-author-and-title.cs](./convert-an-otg-file-to-pdf-and-include-custom-metadata-such-as-author-and-title.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF and include custom metadata such as author and title. |
| [convert-an-odg-file-to-bmp-and-set-the-background-color-to-white-during-rasterization.cs](./convert-an-odg-file-to-bmp-and-set-the-background-color-to-white-during-rasterization.cs) | `BmpOptions`, `OdgRasterizationOptions` | Convert an ODG file to BMP and set the background color to white during rasteriz... |
| [convert-an-otg-file-to-bmp-and-set-the-background-color-to-white-during-rasterization.cs](./convert-an-otg-file-to-bmp-and-set-the-background-color-to-white-during-rasterization.cs) | `BmpOptions`, `OtgRasterizationOptions` | Convert an OTG file to BMP and set the background color to white during rasteriz... |
| [convert-an-odg-file-to-svg-and-remove-unnecessary-group-elements-to-simplify-output.cs](./convert-an-odg-file-to-svg-and-remove-unnecessary-group-elements-to-simplify-output.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an ODG file to SVG and remove unnecessary group elements to simplify out... |
| [convert-an-otg-file-to-svg-and-remove-unnecessary-group-elements-to-simplify-output.cs](./convert-an-otg-file-to-svg-and-remove-unnecessary-group-elements-to-simplify-output.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an OTG file to SVG and remove unnecessary group elements to simplify out... |
| [wrap-odg-to-png-conversion-inside-a-using-block-to-ensure-proper-disposal-of-resources.cs](./wrap-odg-to-png-conversion-inside-a-using-block-to-ensure-proper-disposal-of-resources.cs) | `OdgRasterizationOptions`, `PngOptions` | Wrap ODG to PNG conversion inside a using block to ensure proper disposal of res... |
| [wrap-otg-to-png-conversion-inside-a-using-block-to-ensure-proper-disposal-of-resources.cs](./wrap-otg-to-png-conversion-inside-a-using-block-to-ensure-proper-disposal-of-resources.cs) | `OtgRasterizationOptions`, `PngOptions` | Wrap OTG to PNG conversion inside a using block to ensure proper disposal of res... |
| [convert-an-odg-file-to-jpeg-while-preserving-exif-orientation-metadata-in-the-output.cs](./convert-an-odg-file-to-jpeg-while-preserving-exif-orientation-metadata-in-the-output.cs) | `JpegOptions`, `OdgImage`, `VectorRasterizationOptions` | Convert an ODG file to JPEG while preserving EXIF orientation metadata in the ou... |
| [convert-an-otg-file-to-jpeg-while-preserving-exif-orientation-metadata-in-the-output.cs](./convert-an-otg-file-to-jpeg-while-preserving-exif-orientation-metadata-in-the-output.cs) | `JpegOptions`, `OtgRasterizationOptions` | Convert an OTG file to JPEG while preserving EXIF orientation metadata in the ou... |
| [convert-an-odg-file-to-pdf-and-set-a-custom-author-property-in-the-document-metadata.cs](./convert-an-odg-file-to-pdf-and-set-a-custom-author-property-in-the-document-metadata.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF and set a custom author property in the document meta... |
| [convert-an-otg-file-to-pdf-and-set-a-custom-author-property-in-the-document-metadata.cs](./convert-an-otg-file-to-pdf-and-set-a-custom-author-property-in-the-document-metadata.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF and set a custom author property in the document meta... |
| [convert-an-odg-file-to-png-and-apply-gamma-correction-for-accurate-brightness-representation.cs](./convert-an-odg-file-to-png-and-apply-gamma-correction-for-accurate-brightness-representation.cs) | `PngOptions` | Convert an ODG file to PNG and apply gamma correction for accurate brightness re... |
| [convert-an-otg-file-to-png-and-apply-gamma-correction-for-accurate-brightness-representation.cs](./convert-an-otg-file-to-png-and-apply-gamma-correction-for-accurate-brightness-representation.cs) | `OtgRasterizationOptions`, `PngOptions` | Convert an OTG file to PNG and apply gamma correction for accurate brightness re... |
| [implement-asynchronous-batch-conversion-of-odg-files-to-bmp-using-async-await-for-non-blocking-i-o.cs](./implement-asynchronous-batch-conversion-of-odg-files-to-bmp-using-async-await-for-non-blocking-i-o.cs) | `BmpOptions`, `OdgRasterizationOptions` | Implement asynchronous batch conversion of ODG files to BMP using async/await fo... |
| [implement-asynchronous-batch-conversion-of-otg-files-to-bmp-using-async-await-for-non-blocking-i-o.cs](./implement-asynchronous-batch-conversion-of-otg-files-to-bmp-using-async-await-for-non-blocking-i-o.cs) | `BmpOptions`, `OtgRasterizationOptions` | Implement asynchronous batch conversion of OTG files to BMP using async/await fo... |
| [convert-an-odg-file-to-pdf-and-embed-xmp-metadata-for-enhanced-document-information.cs](./convert-an-odg-file-to-pdf-and-embed-xmp-metadata-for-enhanced-document-information.cs) | `PdfOptions` | Convert an ODG file to PDF and embed XMP metadata for enhanced document informat... |
| [convert-an-otg-file-to-pdf-and-embed-xmp-metadata-for-enhanced-document-information.cs](./convert-an-otg-file-to-pdf-and-embed-xmp-metadata-for-enhanced-document-information.cs) | `PdfOptions`, `VectorRasterizationOptions` | Convert an OTG file to PDF and embed XMP metadata for enhanced document informat... |
| [convert-an-odg-file-to-svg-and-ensure-the-viewbox-attribute-is-correctly-set.cs](./convert-an-odg-file-to-svg-and-ensure-the-viewbox-attribute-is-correctly-set.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an ODG file to SVG and ensure the viewBox attribute is correctly set. |
| [convert-an-otg-file-to-svg-and-ensure-the-viewbox-attribute-is-correctly-set.cs](./convert-an-otg-file-to-svg-and-ensure-the-viewbox-attribute-is-correctly-set.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an OTG file to SVG and ensure the viewBox attribute is correctly set. |
| [load-an-odg-file-from-an-embedded-resource-convert-to-png-and-save-to-disk.cs](./load-an-odg-file-from-an-embedded-resource-convert-to-png-and-save-to-disk.cs) | `PngOptions` | Load an ODG file from an embedded resource, convert to PNG, and save to disk. |
| [load-an-otg-file-from-an-embedded-resource-convert-to-png-and-save-to-disk.cs](./load-an-otg-file-from-an-embedded-resource-convert-to-png-and-save-to-disk.cs) | `OtgRasterizationOptions`, `PngOptions` | Load an OTG file from an embedded resource, convert to PNG, and save to disk. |
| [convert-an-odg-file-to-jpeg-and-specify-custom-chroma-subsampling-for-color-fidelity.cs](./convert-an-odg-file-to-jpeg-and-specify-custom-chroma-subsampling-for-color-fidelity.cs) | `JpegOptions`, `VectorRasterizationOptions` | Convert an ODG file to JPEG and specify custom chroma subsampling for color fide... |
| [convert-an-otg-file-to-jpeg-and-specify-custom-chroma-subsampling-for-color-fidelity.cs](./convert-an-otg-file-to-jpeg-and-specify-custom-chroma-subsampling-for-color-fidelity.cs) | `JpegOptions` | Convert an OTG file to JPEG and specify custom chroma subsampling for color fide... |
| [convert-an-odg-file-to-pdf-set-custom-dpi-and-define-page-margins-for-layout.cs](./convert-an-odg-file-to-pdf-set-custom-dpi-and-define-page-margins-for-layout.cs) | `PdfOptions`, `VectorRasterizationOptions` | Convert an ODG file to PDF, set custom DPI, and define page margins for layout. |
| [convert-an-otg-file-to-pdf-set-custom-dpi-and-define-page-margins-for-layout.cs](./convert-an-otg-file-to-pdf-set-custom-dpi-and-define-page-margins-for-layout.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF, set custom DPI, and define page margins for layout. |
| [apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-jpeg.cs](./apply-a-median-filter-to-an-odg-image-before-converting-and-saving-it-as-jpeg.cs) | `JpegOptions`, `MedianFilterOptions`, `PngOptions` | Apply a median filter to an ODG image before converting and saving it as JPEG. |
| [apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-jpeg.cs](./apply-a-median-filter-to-an-otg-image-before-converting-and-saving-it-as-jpeg.cs) | `JpegOptions`, `MedianFilterOptions`, `OtgRasterizationOptions` | Apply a median filter to an OTG image before converting and saving it as JPEG. |
| [convert-an-odg-file-to-png-and-set-lossless-compression-level-to-maximum-for-smallest-size.cs](./convert-an-odg-file-to-png-and-set-lossless-compression-level-to-maximum-for-smallest-size.cs) | `OdgRasterizationOptions`, `PngOptions` | Convert an ODG file to PNG and set lossless compression level to maximum for sma... |
| [convert-an-otg-file-to-png-and-set-lossless-compression-level-to-maximum-for-smallest-size.cs](./convert-an-otg-file-to-png-and-set-lossless-compression-level-to-maximum-for-smallest-size.cs) | `OtgRasterizationOptions`, `PngOptions` | Convert an OTG file to PNG and set lossless compression level to maximum for sma... |
| [convert-an-odg-file-to-svg-and-preserve-original-layer-names-in-the-output-file.cs](./convert-an-odg-file-to-svg-and-preserve-original-layer-names-in-the-output-file.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an ODG file to SVG and preserve original layer names in the output file. |
| [convert-an-otg-file-to-svg-and-preserve-original-layer-names-in-the-output-file.cs](./convert-an-otg-file-to-svg-and-preserve-original-layer-names-in-the-output-file.cs) | `OtgRasterizationOptions`, `SvgOptions` | Convert an OTG file to SVG and preserve original layer names in the output file. |
| [convert-an-odg-file-to-jpeg-and-embed-an-icc-profile-for-color-management.cs](./convert-an-odg-file-to-jpeg-and-embed-an-icc-profile-for-color-management.cs) | `JpegOptions` | Convert an ODG file to JPEG and embed an ICC profile for color management. |
| [convert-an-otg-file-to-jpeg-and-embed-an-icc-profile-for-color-management.cs](./convert-an-otg-file-to-jpeg-and-embed-an-icc-profile-for-color-management.cs) | `JpegOptions`, `OtgRasterizationOptions` | Convert an OTG file to JPEG and embed an ICC profile for color management. |
| [convert-an-odg-file-to-pdf-and-set-the-document-title-property-in-the-metadata.cs](./convert-an-odg-file-to-pdf-and-set-the-document-title-property-in-the-metadata.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF and set the document title property in the metadata. |
| [convert-an-otg-file-to-pdf-and-set-the-document-title-property-in-the-metadata.cs](./convert-an-otg-file-to-pdf-and-set-the-document-title-property-in-the-metadata.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF and set the document title property in the metadata. |
| [convert-an-odg-file-to-bmp-and-apply-a-threshold-filter-to-create-a-binary-image.cs](./convert-an-odg-file-to-bmp-and-apply-a-threshold-filter-to-create-a-binary-image.cs) | `BmpOptions`, `OdgRasterizationOptions`, `RasterImage` | Convert an ODG file to BMP and apply a threshold filter to create a binary image... |
| [convert-an-otg-file-to-bmp-and-apply-a-threshold-filter-to-create-a-binary-image.cs](./convert-an-otg-file-to-bmp-and-apply-a-threshold-filter-to-create-a-binary-image.cs) | `BmpOptions`, `OtgRasterizationOptions` | Convert an OTG file to BMP and apply a threshold filter to create a binary image... |
| [convert-an-odg-file-to-png-and-add-a-watermark-text-overlay-before-saving.cs](./convert-an-odg-file-to-png-and-add-a-watermark-text-overlay-before-saving.cs) | `Graphics`, `OdgRasterizationOptions`, `PngOptions` | Convert an ODG file to PNG and add a watermark text overlay before saving. |
| [convert-an-otg-file-to-png-and-add-a-watermark-text-overlay-before-saving.cs](./convert-an-otg-file-to-png-and-add-a-watermark-text-overlay-before-saving.cs) | `Graphics`, `PngOptions`, `RasterImage` | Convert an OTG file to PNG and add a watermark text overlay before saving. |
| [convert-an-odg-file-to-pdf-and-flatten-annotations-to-produce-a-static-document.cs](./convert-an-odg-file-to-pdf-and-flatten-annotations-to-produce-a-static-document.cs) | `OdgRasterizationOptions`, `PdfOptions` | Convert an ODG file to PDF and flatten annotations to produce a static document. |
| [convert-an-otg-file-to-pdf-and-flatten-annotations-to-produce-a-static-document.cs](./convert-an-otg-file-to-pdf-and-flatten-annotations-to-produce-a-static-document.cs) | `OtgRasterizationOptions`, `PdfOptions` | Convert an OTG file to PDF and flatten annotations to produce a static document. |
| [convert-an-odg-file-to-svg-and-minify-the-output-xml-to-reduce-file-size.cs](./convert-an-odg-file-to-svg-and-minify-the-output-xml-to-reduce-file-size.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an ODG file to SVG and minify the output XML to reduce file size. |
| [convert-an-otg-file-to-svg-and-minify-the-output-xml-to-reduce-file-size.cs](./convert-an-otg-file-to-svg-and-minify-the-output-xml-to-reduce-file-size.cs) | `SvgOptions`, `SvgRasterizationOptions` | Convert an OTG file to SVG and minify the output XML to reduce file size. |

## Category Statistics
- Total examples: 120
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `BmpImage`
- `BmpOptions`
- `GaussianBlurFilterOptions`
- `Graphics`
- `JpegOptions`
- `MedianFilterOptions`
- `OdgImage`
- `OdgRasterizationOptions`
- `OtgRasterizationOptions`
- `PdfCoreOptions`
- `PdfOptions`
- `PngOptions`
- `RasterImage`
- `SolidBrush`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `VectorRasterizationOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-03-27 | Run: `20260327_081135` | Examples: 120
<!-- AUTOGENERATED:END -->