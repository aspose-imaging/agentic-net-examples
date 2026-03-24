---
name: merge-images
description: C# examples for Merge Images using Aspose.Imaging for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Merge Images

## Persona

You are a C# developer specializing in image processing using Aspose.Imaging for .NET,
working within the **Merge Images** category.
This folder contains standalone C# examples for Merge Images operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using Aspose.Imaging;` (96/95 files) ← category-specific
- `using System;` (95/95 files)
- `using System.IO;` (95/95 files)
- `using Aspose.Imaging.ImageOptions;` (89/95 files) ← category-specific
- `using System.Collections.Generic;` (56/95 files)
- `using Aspose.Imaging.Sources;` (43/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg;` (22/95 files) ← category-specific
- `using System.Linq;` (18/95 files)
- `using Aspose.Imaging.FileFormats.Png;` (12/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Pdf;` (8/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Apng;` (4/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff;` (4/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Dicom;` (3/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Jpeg2000;` (3/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg;` (3/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.BigTiff;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tiff.Enums;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Bmp;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Ico;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Psd;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Webp;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Emf;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.OpenDocument;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Wmf;` (2/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif;` (1/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Gif.Blocks;` (1/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Cmx;` (1/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Tga;` (1/95 files) ← category-specific
- `using Aspose.Imaging.FileFormats.Svg.Graphics;` (1/95 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [combine-multiple-jpg-images-into-a-single-jpeg-file-while-preserving-original-resolution-and-quality.cs](./combine-multiple-jpg-images-into-a-single-jpeg-file-while-preserving-original-resolution-and-quality.cs) | `JpegOptions` | 13361 combine multiple jpg images into a single jpeg file while preserving origi... |
| [combine-multiple-images-into-a-single-jpeg-with-a-horizontal-arrangement-preserving-original-dimensions.cs](./combine-multiple-images-into-a-single-jpeg-with-a-horizontal-arrangement-preserving-original-dimensions.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 13362 combine multiple images into a single jpeg with a horizontal arrangement p... |
| [combine-multiple-images-into-a-single-vertically-arranged-jpeg-file-maintaining-the-original-image-order.cs](./combine-multiple-images-into-a-single-vertically-arranged-jpeg-file-maintaining-the-original-image-order.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 13363 combine multiple images into a single vertically arranged jpeg file mainta... |
| [combine-multiple-jpeg-images-into-a-single-pdf-document-preserving-original-jpeg-quality-and-image-dimensions.cs](./combine-multiple-jpeg-images-into-a-single-pdf-document-preserving-original-jpeg-quality-and-image-dimensions.cs) | `PdfOptions` | 13364 combine multiple jpeg images into a single pdf document preserving origina... |
| [combine-multiple-jpeg-images-into-a-single-png-file-while-preserving-jpeg-compression-characteristics.cs](./combine-multiple-jpeg-images-into-a-single-png-file-while-preserving-jpeg-compression-characteristics.cs) | `PngOptions`, `RasterImage` | 13365 combine multiple jpeg images into a single png file while preserving jpeg ... |
| [programmatically-combine-multiple-jpg-images-into-a-single-apng-file-while-preserving-each-image-s-original-dimensions-and-color-fidelity.cs](./programmatically-combine-multiple-jpg-images-into-a-single-apng-file-while-preserving-each-image-s-original-dimensions-and-color-fidelity.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | 14022 programmatically combine multiple jpg images into a single apng file while... |
| [programmatically-and-efficiently-combine-multiple-jpg-images-into-a-single-avif-file-preserving-image-quality.cs](./programmatically-and-efficiently-combine-multiple-jpg-images-into-a-single-avif-file-preserving-image-quality.cs) |  | 14023 programmatically and efficiently combine multiple jpg images into a single... |
| [programmatically-combine-multiple-jpg-images-into-a-single-bigtiff-file-preserving-image-fidelity-while-maintaining-original-metadata.cs](./programmatically-combine-multiple-jpg-images-into-a-single-bigtiff-file-preserving-image-fidelity-while-maintaining-original-metadata.cs) | `BigTiffImage`, `BigTiffOptions`, `RasterImage` | 14024 programmatically combine multiple jpg images into a single bigtiff file pr... |
| [programmatically-combine-multiple-jpeg-files-into-a-single-jpeg-output-by-converting-and-merging-through-bmp-format.cs](./programmatically-combine-multiple-jpeg-files-into-a-single-jpeg-output-by-converting-and-merging-through-bmp-format.cs) | `BmpOptions`, `JpegOptions`, `RasterImage` | 14025 programmatically combine multiple jpeg files into a single jpeg output by ... |
| [programmatically-combine-multiple-jpg-images-into-a-single-cdr-file-while-preserving-image-quality.cs](./programmatically-combine-multiple-jpg-images-into-a-single-cdr-file-while-preserving-image-quality.cs) |  | 14026 programmatically combine multiple jpg images into a single cdr file while ... |
| [programmatically-merge-multiple-jpg-images-into-a-single-jpg-output-utilizing-the-cmx-file-format.cs](./programmatically-merge-multiple-jpg-images-into-a-single-jpg-output-utilizing-the-cmx-file-format.cs) | `JpegOptions` | 14027 programmatically merge multiple jpg images into a single jpg output utiliz... |
| [programmatically-merge-multiple-jpg-images-into-a-single-jpg-output-while-employing-the-dib-format.cs](./programmatically-merge-multiple-jpg-images-into-a-single-jpg-output-while-employing-the-dib-format.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 14028 programmatically merge multiple jpg images into a single jpg output while ... |
| [programmatically-combine-multiple-jpg-images-into-a-single-dicom-file-while-maintaining-image-fidelity.cs](./programmatically-combine-multiple-jpg-images-into-a-single-dicom-file-while-maintaining-image-fidelity.cs) | `DicomImage`, `DicomOptions`, `RasterImage` | 14029 programmatically combine multiple jpg images into a single dicom file whil... |
| [programmatically-combine-multiple-jpg-images-into-a-single-djvu-file-while-preserving-image-quality.cs](./programmatically-combine-multiple-jpg-images-into-a-single-djvu-file-while-preserving-image-quality.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 14030 programmatically combine multiple jpg images into a single djvu file while... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpg-utilizing-dng-as-the-intermediate-format.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpg-utilizing-dng-as-the-intermediate-format.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 14031 programmatically combine multiple jpg images into a single jpg utilizing d... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-utilizing-the-emf-format-as-an-intermediate.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-utilizing-the-emf-format-as-an-intermediate.cs) | `EmfOptions`, `JpegOptions` | 14032 programmatically combine multiple jpg images into a single jpg output util... |
| [implement-a-routine-that-programmatically-merges-multiple-jpeg-images-into-a-single-jpeg-using-eps-as-the-intermediate-format.cs](./implement-a-routine-that-programmatically-merges-multiple-jpeg-images-into-a-single-jpeg-using-eps-as-the-intermediate-format.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 14033 implement a routine that programmatically merges multiple jpeg images into... |
| [combine-multiple-jpg-images-into-a-single-gif-file-using-a-programmatic-merging-operation.cs](./combine-multiple-jpg-images-into-a-single-gif-file-using-a-programmatic-merging-operation.cs) | `GifImage`, `RasterImage` | 14034 combine multiple jpg images into a single gif file using a programmatic me... |
| [programmatically-combine-multiple-jpg-images-into-a-single-ico-file-while-preserving-image-quality.cs](./programmatically-combine-multiple-jpg-images-into-a-single-ico-file-while-preserving-image-quality.cs) | `IcoImage`, `IcoOptions` | 14035 programmatically combine multiple jpg images into a single ico file while ... |
| [combine-multiple-jpg-files-programmatically-into-a-single-jpeg-image-while-maintaining-original-compression-parameters.cs](./combine-multiple-jpg-files-programmatically-into-a-single-jpeg-image-while-maintaining-original-compression-parameters.cs) | `Graphics`, `JpegOptions` | 14036 combine multiple jpg files programmatically into a single jpeg image while... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpeg2000-file-preserving-image-quality-and-metadata.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpeg2000-file-preserving-image-quality-and-metadata.cs) | `Jpeg2000Image`, `Jpeg2000Options`, `JpegImage` | 14037 programmatically combine multiple jpg images into a single jpeg2000 file p... |
| [programmatically-combine-multiple-jpg-images-into-a-single-odg-file-while-preserving-image-integrity.cs](./programmatically-combine-multiple-jpg-images-into-a-single-odg-file-while-preserving-image-integrity.cs) |  | 14038 programmatically combine multiple jpg images into a single odg file while ... |
| [programmatically-combine-multiple-jpg-images-into-a-single-otg-file-while-maintaining-image-fidelity.cs](./programmatically-combine-multiple-jpg-images-into-a-single-otg-file-while-maintaining-image-fidelity.cs) |  | 14039 programmatically combine multiple jpg images into a single otg file while ... |
| [programmatically-combine-several-jpg-files-into-one-png-image-while-maintaining-original-pixel-data.cs](./programmatically-combine-several-jpg-files-into-one-png-image-while-maintaining-original-pixel-data.cs) | `Graphics`, `PngOptions` | 14040 programmatically combine several jpg files into one png image while mainta... |
| [programmatically-combine-multiple-jpg-images-into-a-single-psd-file-preserving-each-image-as-separate-layers.cs](./programmatically-combine-multiple-jpg-images-into-a-single-psd-file-preserving-each-image-as-separate-layers.cs) | `PsdOptions` | 14041 programmatically combine multiple jpg images into a single psd file preser... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-by-leveraging-svg-as-an-intermediate-format.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-by-leveraging-svg-as-an-intermediate-format.cs) | `Graphics`, `JpegOptions`, `RasterImage` | 14042 programmatically combine multiple jpg images into a single jpg output by l... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-utilizing-the-svgz-intermediate-format.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-utilizing-the-svgz-intermediate-format.cs) | `JpegOptions`, `PngOptions`, `RasterImage` | 14043 programmatically combine multiple jpg images into a single jpg output util... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-utilizing-tga-as-the-intermediate-format.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-utilizing-tga-as-the-intermediate-format.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 14044 programmatically combine multiple jpg images into a single jpg output util... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-by-utilizing-tiff-as-an-intermediate-format.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-by-utilizing-tiff-as-an-intermediate-format.cs) | `Graphics`, `JpegOptions`, `TiffFrame` | 14045 programmatically combine multiple jpg images into a single jpg output by u... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-by-utilizing-wmf-as-the-intermediate-format.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-by-utilizing-wmf-as-the-intermediate-format.cs) | `JpegOptions`, `WmfOptions` | 14046 programmatically combine multiple jpg images into a single jpg output by u... |
| [programmatically-combine-multiple-jpg-images-into-a-single-emz-file-while-preserving-image-quality.cs](./programmatically-combine-multiple-jpg-images-into-a-single-emz-file-while-preserving-image-quality.cs) | `EmfOptions` | Programmatically combine multiple JPG images into a single EMZ file while preser... |
| [programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-employing-the-wmz-format.cs](./programmatically-combine-multiple-jpg-images-into-a-single-jpg-output-employing-the-wmz-format.cs) | `JpegOptions` | 14048 programmatically combine multiple jpg images into a single jpg output empl... |
| [programmatically-combine-multiple-jpg-files-into-a-single-image-and-output-the-result-in-webp-format.cs](./programmatically-combine-multiple-jpg-files-into-a-single-image-and-output-the-result-in-webp-format.cs) | `RasterImage`, `WebPOptions` | 14049 programmatically combine multiple jpg files into a single image and output... |
| [create-programmatically-a-side-by-side-composition-of-images-and-output-the-result-in-apng-format.cs](./create-programmatically-a-side-by-side-composition-of-images-and-output-the-result-in-apng-format.cs) | `ApngImage`, `ApngOptions`, `PngOptions` | 14050 create programmatically a side by side composition of images and output th... |
| [create-a-side-by-side-composition-of-images-encoded-in-avif-format-within-a-single-horizontal-layout.cs](./create-a-side-by-side-composition-of-images-encoded-in-avif-format-within-a-single-horizontal-layout.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 14051 create a side by side composition of images encoded in avif format within ... |
| [combine-jpg-images-into-a-pdf-document-by-first-converting-them-to-apng-format-and-embedding-them-accordingly.cs](./combine-jpg-images-into-a-pdf-document-by-first-converting-them-to-apng-format-and-embedding-them-accordingly.cs) | `ApngOptions`, `PdfOptions` | 14052 combine jpg images into a pdf document by first converting them to apng fo... |
| [combine-jpg-images-into-a-pdf-document-encoding-the-images-as-avif-format-to-optimize-size.cs](./combine-jpg-images-into-a-pdf-document-encoding-the-images-as-avif-format-to-optimize-size.cs) | `PdfCoreOptions`, `PdfOptions` | 14053 combine jpg images into a pdf document encoding the images as avif format ... |
| [combine-multiple-jpg-images-into-a-single-pdf-document-utilizing-the-bigtiff-format-for-high-resolution-output.cs](./combine-multiple-jpg-images-into-a-single-pdf-document-utilizing-the-bigtiff-format-for-high-resolution-output.cs) | `PdfOptions` | 14054 combine multiple jpg images into a single pdf document utilizing the bigti... |
| [merge-multiple-jpeg-images-into-a-single-pdf-by-converting-each-image-to-bmp-format-before-inclusion.cs](./merge-multiple-jpeg-images-into-a-single-pdf-by-converting-each-image-to-bmp-format-before-inclusion.cs) | `BmpOptions`, `PdfOptions` | 14055 merge multiple jpeg images into a single pdf by converting each image to b... |
| [merge-jpeg-images-into-a-pdf-document-by-converting-them-through-the-cdr-format.cs](./merge-jpeg-images-into-a-pdf-document-by-converting-them-through-the-cdr-format.cs) | `PdfOptions` | 14056 merge jpeg images into a pdf document by converting them through the cdr f... |
| [combine-jpg-images-into-a-single-pdf-document-using-the-cmx-format-to-maintain-color-fidelity.cs](./combine-jpg-images-into-a-single-pdf-document-using-the-cmx-format-to-maintain-color-fidelity.cs) | `CmxImage`, `JpegImage`, `JpegOptions` | 14057 combine jpg images into a single pdf document using the cmx format to main... |
| [convert-and-merge-jpg-images-into-a-pdf-document-utilizing-dib-format-for-image-representation.cs](./convert-and-merge-jpg-images-into-a-pdf-document-utilizing-dib-format-for-image-representation.cs) | `PdfOptions` | 14058 convert and merge jpg images into a pdf document utilizing dib format for ... |
| [combine-jpg-images-into-a-pdf-document-using-dicom-formatting-while-maintaining-image-fidelity.cs](./combine-jpg-images-into-a-pdf-document-using-dicom-formatting-while-maintaining-image-fidelity.cs) | `DicomImage`, `DicomOptions`, `PdfOptions` | 14059 combine jpg images into a pdf document using dicom formatting while mainta... |
| [combine-a-jpeg-image-into-a-pdf-document-by-first-converting-it-to-djvu-format-and-then-merging.cs](./combine-a-jpeg-image-into-a-pdf-document-by-first-converting-it-to-djvu-format-and-then-merging.cs) | `PdfOptions` | 14060 combine a jpeg image into a pdf document by first converting it to djvu fo... |
| [combine-multiple-jpg-images-into-a-single-pdf-document-by-processing-them-through-the-dng-format.cs](./combine-multiple-jpg-images-into-a-single-pdf-document-by-processing-them-through-the-dng-format.cs) | `PdfOptions` | 14061 combine multiple jpg images into a single pdf document by processing them ... |
| [combine-jpg-images-into-a-pdf-document-by-converting-them-to-emf-format-while-preserving-vector-fidelity.cs](./combine-jpg-images-into-a-pdf-document-by-converting-them-to-emf-format-while-preserving-vector-fidelity.cs) | `EmfOptions`, `EmfRasterizationOptions`, `PdfOptions` | 14062 combine jpg images into a pdf document by converting them to emf format wh... |
| [convert-jpeg-images-to-eps-and-combine-them-into-a-single-pdf-document-while-preserving-image-fidelity.cs](./convert-jpeg-images-to-eps-and-combine-them-into-a-single-pdf-document-while-preserving-image-fidelity.cs) | `PdfOptions` | 14063 convert jpeg images to eps and combine them into a single pdf document whi... |
| [combine-a-jpg-image-into-a-pdf-document-by-first-converting-it-to-gif-format-before-merging.cs](./combine-a-jpg-image-into-a-pdf-document-by-first-converting-it-to-gif-format-before-merging.cs) | `PdfOptions` | 14064 combine a jpg image into a pdf document by first converting it to gif form... |
| [combine-jpg-images-into-a-pdf-document-embedding-an-ico-file-as-the-document-s-icon.cs](./combine-jpg-images-into-a-pdf-document-embedding-an-ico-file-as-the-document-s-icon.cs) | `PdfCoreOptions`, `PdfOptions` | 14065 combine jpg images into a pdf document embedding an ico file as the docume... |
| [combine-jpeg-images-into-a-single-pdf-document-while-retaining-original-jpeg-quality-and-encoding.cs](./combine-jpeg-images-into-a-single-pdf-document-while-retaining-original-jpeg-quality-and-encoding.cs) |  | 14066 combine jpeg images into a single pdf document while retaining original jp... |
| [combine-jpeg-images-into-a-pdf-document-employing-the-jpeg2000-compression-format-while-maintaining-image-fidelity-and-document-integrity.cs](./combine-jpeg-images-into-a-pdf-document-employing-the-jpeg2000-compression-format-while-maintaining-image-fidelity-and-document-integrity.cs) | `Graphics`, `Jpeg2000Options`, `PdfOptions` | 14067 combine jpeg images into a pdf document employing the jpeg2000 compression... |
| [combine-jpeg-images-into-a-single-pdf-document-utilizing-the-odg-format-as-the-intermediate-representation.cs](./combine-jpeg-images-into-a-single-pdf-document-utilizing-the-odg-format-as-the-intermediate-representation.cs) | `OdgRasterizationOptions`, `PdfOptions` | 14068 combine jpeg images into a single pdf document utilizing the odg format as... |
| [combine-multiple-jpg-images-into-a-single-pdf-document-utilizing-the-otg-format-for-optimized-output.cs](./combine-multiple-jpg-images-into-a-single-pdf-document-utilizing-the-otg-format-for-optimized-output.cs) | `OtgRasterizationOptions`, `PdfOptions` | 14069 combine multiple jpg images into a single pdf document utilizing the otg f... |
| [combine-jpg-images-into-a-pdf-document-converting-each-image-to-png-format-before-merging.cs](./combine-jpg-images-into-a-pdf-document-converting-each-image-to-png-format-before-merging.cs) | `PdfOptions`, `PngOptions` | 14070 combine jpg images into a pdf document converting each image to png format... |
| [combine-jpg-images-into-a-pdf-document-by-first-converting-them-to-psd-format.cs](./combine-jpg-images-into-a-pdf-document-by-first-converting-them-to-psd-format.cs) | `PdfOptions`, `PsdOptions` | 14071 combine jpg images into a pdf document by first converting them to psd for... |
| [combine-multiple-jpg-images-into-a-single-pdf-document-by-first-converting-them-to-svg-format.cs](./combine-multiple-jpg-images-into-a-single-pdf-document-by-first-converting-them-to-svg-format.cs) | `PdfOptions`, `SvgOptions`, `SvgRasterizationOptions` | 14072 combine multiple jpg images into a single pdf document by first converting... |
| [combine-multiple-jpg-images-into-a-single-pdf-file-by-converting-them-through-the-svgz-vector-format.cs](./combine-multiple-jpg-images-into-a-single-pdf-file-by-converting-them-through-the-svgz-vector-format.cs) | `PdfOptions`, `SvgOptions`, `SvgRasterizationOptions` | 14073 combine multiple jpg images into a single pdf file by converting them thro... |
| [combine-a-jpg-image-into-a-pdf-document-by-converting-it-through-the-tga-format.cs](./combine-a-jpg-image-into-a-pdf-document-by-converting-it-through-the-tga-format.cs) | `JpegImage`, `PdfOptions`, `TgaImage` | 14074 combine a jpg image into a pdf document by converting it through the tga f... |
| [combine-multiple-jpg-images-into-a-single-pdf-by-first-converting-them-to-a-tiff-intermediate.cs](./combine-multiple-jpg-images-into-a-single-pdf-by-first-converting-them-to-a-tiff-intermediate.cs) | `PdfOptions`, `TiffFrame`, `TiffImage` | 14075 combine multiple jpg images into a single pdf by first converting them to ... |
| [combine-jpg-images-into-a-pdf-document-by-converting-them-to-wmf-format-before-merging.cs](./combine-jpg-images-into-a-pdf-document-by-converting-them-to-wmf-format-before-merging.cs) | `PdfOptions`, `WmfOptions`, `WmfRasterizationOptions` | 14076 combine jpg images into a pdf document by converting them to wmf format be... |
| [combine-jpg-images-into-a-pdf-document-by-converting-them-to-emz-format-during-the-merging-process.cs](./combine-jpg-images-into-a-pdf-document-by-converting-them-to-emz-format-during-the-merging-process.cs) | `EmfOptions`, `EmfRasterizationOptions`, `PdfOptions` | 14077 combine jpg images into a pdf document by converting them to emz format du... |
| [combine-jpg-images-into-a-single-pdf-document-employing-the-wmz-format-for-compression-and-packaging.cs](./combine-jpg-images-into-a-single-pdf-document-employing-the-wmz-format-for-compression-and-packaging.cs) | `PdfCoreOptions`, `PdfOptions` | 14078 combine jpg images into a single pdf document employing the wmz format for... |
| [combine-multiple-jpg-images-into-a-single-pdf-document-by-first-converting-them-to-webp-format.cs](./combine-multiple-jpg-images-into-a-single-pdf-document-by-first-converting-them-to-webp-format.cs) | `PdfOptions`, `WebPOptions` | 14079 combine multiple jpg images into a single pdf document by first converting... |
| [combine-one-or-more-jpg-images-into-an-animated-png-apng-file-while-preserving-image-quality.cs](./combine-one-or-more-jpg-images-into-an-animated-png-apng-file-while-preserving-image-quality.cs) | `ApngImage`, `ApngOptions`, `RasterImage` | 14080 combine one or more jpg images into an animated png apng file while preser... |
| [merge-jpg-files-into-a-png-output-utilizing-the-avif-format-for-efficient-encoding.cs](./merge-jpg-files-into-a-png-output-utilizing-the-avif-format-for-efficient-encoding.cs) | `PngOptions`, `RasterImage` | 14081 merge jpg files into a png output utilizing the avif format for efficient ... |
| [combine-multiple-jpeg-images-into-a-single-png-output-while-employing-the-bigtiff-format-for-high-resolution-handling.cs](./combine-multiple-jpeg-images-into-a-single-png-output-while-employing-the-bigtiff-format-for-high-resolution-handling.cs) | `BigTiffImage`, `BigTiffOptions`, `PngOptions` | 14082 combine multiple jpeg images into a single png output while employing the ... |
| [combine-one-or-more-jpeg-files-into-a-single-png-output-by-internally-converting-them-through-bmp-format.cs](./combine-one-or-more-jpeg-files-into-a-single-png-output-by-internally-converting-them-through-bmp-format.cs) | `BmpOptions`, `PngOptions`, `RasterImage` | 14083 combine one or more jpeg files into a single png output by internally conv... |
| [combine-multiple-jpg-images-into-a-single-png-output-by-leveraging-the-cdr-file-format-conversion-process.cs](./combine-multiple-jpg-images-into-a-single-png-output-by-leveraging-the-cdr-file-format-conversion-process.cs) | `PngOptions` | 14084 combine multiple jpg images into a single png output by leveraging the cdr... |
| [combine-multiple-jpg-images-into-a-single-png-output-employing-the-cmx-format-for-processing.cs](./combine-multiple-jpg-images-into-a-single-png-output-employing-the-cmx-format-for-processing.cs) | `PngOptions` | 14085 combine multiple jpg images into a single png output employing the cmx for... |
| [combine-jpeg-images-into-a-single-png-output-utilizing-the-dib-pixel-format-for-conversion.cs](./combine-jpeg-images-into-a-single-png-output-utilizing-the-dib-pixel-format-for-conversion.cs) | `PngOptions`, `RasterImage` | 14086 combine jpeg images into a single png output utilizing the dib pixel forma... |
| [combine-a-jpeg-image-into-a-png-output-while-encapsulating-the-result-within-a-dicom-container.cs](./combine-a-jpeg-image-into-a-png-output-while-encapsulating-the-result-within-a-dicom-container.cs) | `DicomOptions` | 14087 combine a jpeg image into a png output while encapsulating the result with... |
| [combine-multiple-jpg-files-into-a-single-png-image-by-processing-them-through-the-djvu-format.cs](./combine-multiple-jpg-files-into-a-single-png-image-by-processing-them-through-the-djvu-format.cs) | `PngOptions` | 14088 combine multiple jpg files into a single png image by processing them thro... |
| [convert-and-combine-multiple-jpg-images-into-a-single-png-output-by-processing-them-through-the-dng-format.cs](./convert-and-combine-multiple-jpg-images-into-a-single-png-output-by-processing-them-through-the-dng-format.cs) | `PngOptions`, `RasterImage` | 14089 convert and combine multiple jpg images into a single png output by proces... |
| [combine-jpg-images-into-a-single-png-output-by-converting-through-emf-format-programmatically.cs](./combine-jpg-images-into-a-single-png-output-by-converting-through-emf-format-programmatically.cs) | `EmfOptions`, `EmfRasterizationOptions`, `PngOptions` | 14090 combine jpg images into a single png output by converting through emf form... |
| [combine-multiple-jpg-images-into-a-single-png-output-by-converting-through-eps-format.cs](./combine-multiple-jpg-images-into-a-single-png-output-by-converting-through-eps-format.cs) | `PngOptions` | 14091 combine multiple jpg images into a single png output by converting through... |
| [combine-multiple-jpg-images-into-a-single-png-file-employing-gif-as-an-intermediate-format-during-processing.cs](./combine-multiple-jpg-images-into-a-single-png-file-employing-gif-as-an-intermediate-format-during-processing.cs) | `GifOptions`, `PngOptions`, `RasterImage` | 14092 combine multiple jpg images into a single png file employing gif as an int... |
| [combine-one-or-more-jpg-images-into-a-single-png-file-and-generate-an-ico-file-from-the-result.cs](./combine-one-or-more-jpg-images-into-a-single-png-file-and-generate-an-ico-file-from-the-result.cs) | `IcoImage`, `IcoOptions`, `PngOptions` | 14093 combine one or more jpg images into a single png file and generate an ico ... |
| [combine-jpg-images-into-a-png-output-while-applying-jpeg-compression-settings-during-the-merge.cs](./combine-jpg-images-into-a-png-output-while-applying-jpeg-compression-settings-during-the-merge.cs) | `Graphics`, `PngOptions` | 14094 combine jpg images into a png output while applying jpeg compression setti... |
| [combine-jpeg-images-into-a-single-png-output-employing-jpeg2000-encoding-for-intermediate-processing.cs](./combine-jpeg-images-into-a-single-png-output-employing-jpeg2000-encoding-for-intermediate-processing.cs) | `Jpeg2000Image`, `PngOptions`, `RasterImage` | 14095 combine jpeg images into a single png output employing jpeg2000 encoding f... |
| [combine-multiple-jpg-images-into-a-single-png-output-utilizing-odg-format-as-the-conversion-intermediary.cs](./combine-multiple-jpg-images-into-a-single-png-output-utilizing-odg-format-as-the-conversion-intermediary.cs) | `OdgRasterizationOptions`, `PngOptions` | 14096 combine multiple jpg images into a single png output utilizing odg format ... |
| [combine-multiple-jpg-images-into-a-single-png-file-processing-them-in-memory-using-the-otg-format.cs](./combine-multiple-jpg-images-into-a-single-png-file-processing-them-in-memory-using-the-otg-format.cs) | `PngOptions` | 14097 combine multiple jpg images into a single png file processing them in memo... |
| [combine-multiple-jpg-images-into-a-single-png-file-while-maintaining-png-format-specifications.cs](./combine-multiple-jpg-images-into-a-single-png-file-while-maintaining-png-format-specifications.cs) | `PngOptions`, `RasterImage` | 14098 combine multiple jpg images into a single png file while maintaining png f... |
| [combine-multiple-jpg-images-into-a-single-png-output-by-processing-them-through-psd-format.cs](./combine-multiple-jpg-images-into-a-single-png-output-by-processing-them-through-psd-format.cs) | `PngOptions`, `PsdOptions` | 14099 combine multiple jpg images into a single png output by processing them th... |
| [convert-and-combine-multiple-jpg-images-into-a-single-png-output-by-processing-them-through-svg-format.cs](./convert-and-combine-multiple-jpg-images-into-a-single-png-output-by-processing-them-through-svg-format.cs) | `PngOptions`, `RasterImage`, `SvgRasterizationOptions` | 14100 convert and combine multiple jpg images into a single png output by proces... |
| [combine-jpg-images-into-a-single-png-file-through-an-svgz-intermediate-representation-process.cs](./combine-jpg-images-into-a-single-png-file-through-an-svgz-intermediate-representation-process.cs) | `PngOptions`, `RasterImage` | 14101 combine jpg images into a single png file through an svgz intermediate rep... |
| [combine-jpg-images-into-a-single-png-output-utilizing-tga-as-the-intermediate-format.cs](./combine-jpg-images-into-a-single-png-output-utilizing-tga-as-the-intermediate-format.cs) | `PngOptions`, `RasterImage`, `TgaOptions` | 14102 combine jpg images into a single png output utilizing tga as the intermedi... |
| [combine-multiple-jpeg-images-into-a-single-png-output-by-leveraging-tiff-as-the-intermediate-format.cs](./combine-multiple-jpeg-images-into-a-single-png-output-by-leveraging-tiff-as-the-intermediate-format.cs) | `PngOptions`, `TiffFrame`, `TiffImage` | 14103 combine multiple jpeg images into a single png output by leveraging tiff a... |
| [combine-multiple-jpg-images-into-one-png-file-by-processing-them-through-the-wmf-intermediate-format.cs](./combine-multiple-jpg-images-into-one-png-file-by-processing-them-through-the-wmf-intermediate-format.cs) | `PngOptions`, `WmfOptions`, `WmfRasterizationOptions` | 14104 combine multiple jpg images into one png file by processing them through t... |
| [combine-jpg-images-into-a-single-png-output-encapsulated-within-an-emz-file-while-preserving-visual-fidelity.cs](./combine-jpg-images-into-a-single-png-output-encapsulated-within-an-emz-file-while-preserving-visual-fidelity.cs) | `EmfImage`, `EmfOptions`, `Graphics` | 14105 combine jpg images into a single png output encapsulated within an emz fil... |
| [combine-jpg-images-into-a-single-png-file-efficiently-utilizing-the-wmz-container-format.cs](./combine-jpg-images-into-a-single-png-file-efficiently-utilizing-the-wmz-container-format.cs) | `PngOptions` | 14106 combine jpg images into a single png file efficiently utilizing the wmz co... |
| [combine-jpg-images-and-output-a-png-file-generated-through-the-webp-format-conversion-process.cs](./combine-jpg-images-and-output-a-png-file-generated-through-the-webp-format-conversion-process.cs) | `PngOptions`, `RasterImage`, `WebPImage` | 14107 combine jpg images and output a png file generated through the webp format... |
| [combine-multiple-jpg-images-into-a-single-jpeg-file-via-code-maintaining-image-fidelity.cs](./combine-multiple-jpg-images-into-a-single-jpeg-file-via-code-maintaining-image-fidelity.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 14297 combine multiple jpg images into a single jpeg file via code maintaining i... |
| [combine-multiple-jpg-images-side-by-side-into-a-single-jpeg-file-arranged-horizontally-with-a-consistent-color-profile.cs](./combine-multiple-jpg-images-side-by-side-into-a-single-jpeg-file-arranged-horizontally-with-a-consistent-color-profile.cs) | `JpegImage`, `JpegOptions`, `RasterImage` | 14298 combine multiple jpg images side by side into a single jpeg file arranged ... |
| [combine-multiple-jpg-files-into-a-single-vertically-stacked-jpeg-image-maintaining-original-quality.cs](./combine-multiple-jpg-files-into-a-single-vertically-stacked-jpeg-image-maintaining-original-quality.cs) | `Graphics`, `JpegImage`, `JpegOptions` | 14299 combine multiple jpg files into a single vertically stacked jpeg image mai... |
| [combine-multiple-jpg-images-into-a-single-jpeg-file-while-preserving-original-image-quality-and-metadata.cs](./combine-multiple-jpg-images-into-a-single-jpeg-file-while-preserving-original-image-quality-and-metadata.cs) | `JpegImage`, `JpegOptions` | 14300 combine multiple jpg images into a single jpeg file while preserving origi... |

## Category Statistics
- Total examples: 95
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ApngImage`
- `ApngOptions`
- `BigTiffImage`
- `BigTiffOptions`
- `BmpOptions`
- `CmxImage`
- `DicomImage`
- `DicomOptions`
- `EmfImage`
- `EmfOptions`
- `EmfRasterizationOptions`
- `GifImage`
- `GifOptions`
- `Graphics`
- `IcoImage`
- `IcoOptions`
- `Jpeg2000Image`
- `Jpeg2000Options`
- `JpegImage`
- `JpegOptions`
- `OdgRasterizationOptions`
- `OtgRasterizationOptions`
- `PdfCoreOptions`
- `PdfOptions`
- `PngOptions`
- `PsdOptions`
- `RasterImage`
- `SvgImage`
- `SvgOptions`
- `SvgRasterizationOptions`
- `TgaImage`
- `TgaOptions`
- `TiffFrame`
- `TiffImage`
- `WebPImage`
- `WebPOptions`
- `WmfOptions`
- `WmfRasterizationOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-03-24 | Run: `20260324_031741` | Examples: 95
<!-- AUTOGENERATED:END -->