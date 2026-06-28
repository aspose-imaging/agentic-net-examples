# Aspose.Imaging for .NET — Agentic C# Examples

## Statistics

| Metric | Value |
|--------|-------|
| Total Examples | 4720 |
| Categories | 17 |
| Overall Pass Rate | 100.0% |
| Last Updated | 2026-06-28 |

## Repository Structure

```
agents.md
README.md
+-- conversion/
+-- convert-apng/
+-- convert-cdr/
+-- convert-cmx-images/
+-- convert-dicom-images/
+-- convert-eps-images/
+-- convert-open-document-graphics/
+-- convert-raster-image/
+-- convert-svg-to-raster-images/
+-- convert-webp-images/
+-- converting-wmf-and-emf/
+-- image-and-photo-filters/
+-- kernel-filters/
+-- manipulate-different-image-file-formats/
+-- manipulating-images/
+-- merge-images/
+-- working-with-drawing-images/
```

## Categories

| Category | Examples | Pass Rate | Details |
|----------|----------|-----------|---------|
| [Conversion](./conversion/) | 162 | 100.0% | [agents.md](./conversion/agents.md) |
| [Convert APNG](./convert-apng/) | 102 | 100.0% | [agents.md](./convert-apng/agents.md) |
| [Convert CDR](./convert-cdr/) | 90 | 100.0% | [agents.md](./convert-cdr/agents.md) |
| [Convert CMX Images](./convert-cmx-images/) | 68 | 100.0% | [agents.md](./convert-cmx-images/agents.md) |
| [Convert DICOM Images](./convert-dicom-images/) | 60 | 100.0% | [agents.md](./convert-dicom-images/agents.md) |
| [Convert EPS Images](./convert-eps-images/) | 120 | 100.0% | [agents.md](./convert-eps-images/agents.md) |
| [Convert Open Document Graphics](./convert-open-document-graphics/) | 240 | 100.0% | [agents.md](./convert-open-document-graphics/agents.md) |
| [Convert Raster Image](./convert-raster-image/) | 279 | 100.0% | [agents.md](./convert-raster-image/agents.md) |
| [Convert SVG to Raster Images](./convert-svg-to-raster-images/) | 80 | 100.0% | [agents.md](./convert-svg-to-raster-images/agents.md) |
| [Convert webp Images](./convert-webp-images/) | 60 | 100.0% | [agents.md](./convert-webp-images/agents.md) |
| [Converting WMF and EMF](./converting-wmf-and-emf/) | 58 | 100.0% | [agents.md](./converting-wmf-and-emf/agents.md) |
| [Image and Photo Filters](./image-and-photo-filters/) | 210 | 100.0% | [agents.md](./image-and-photo-filters/agents.md) |
| [Kernel Filters](./kernel-filters/) | 695 | 100.0% | [agents.md](./kernel-filters/agents.md) |
| [Manipulate Different Image File Formats](./manipulate-different-image-file-formats/) | 1032 | 100.0% | [agents.md](./manipulate-different-image-file-formats/agents.md) |
| [Manipulating Images](./manipulating-images/) | 650 | 100.0% | [agents.md](./manipulating-images/agents.md) |
| [Merge Images](./merge-images/) | 175 | 100.0% | [agents.md](./merge-images/agents.md) |
| [Working With Drawing Images](./working-with-drawing-images/) | 639 | 100.0% | [agents.md](./working-with-drawing-images/agents.md) |

## How to Use

```bash
git clone https://github.com/aspose-imaging/agentic-net-examples.git
cd <category>
dotnet run <example-file.cs>
```

## Prerequisites

- .NET SDK (net9.0)
- Aspose.Imaging for .NET (via NuGet)

## Agent Pipeline

The agent that generates these examples follows a three-attempt pipeline per task:

| Attempt | Strategy | Trigger |
|---------|----------|---------|
| 1 | Raw MCP call with path-safety rules | Always |
| 2 | MCP call with LLM-selected category rules | Attempt 1 fails |
| 3 | LLM direct fix with compiler errors + rules | Attempt 2 fails |

After all tasks complete, a **retry pass** automatically re-runs any failed tasks through the full 1→2→3 pipeline once more. Only examples that pass both `dotnet build` and `dotnet run` are committed to the repository.

## Validation

Every pull request is automatically validated by GitHub Actions (`validate-pr.yml`):

- `dotnet build` — **required**, blocks merge on failure
- `dotnet run` — **informational**, runtime errors are expected when input files are absent

## Versioning

Examples are versioned by NuGet release. Each version gets its own branch and a GitHub release tag. When a new NuGet version is available, the agent creates a release tag on `main`, bumps the NuGet version, and starts generating examples on a new branch. Once complete, the branch is merged into `main`.

## REST API

The agent exposes a public REST API for programmatic access:

| Method | Endpoint | Description |
|--------|----------|--------------|
| `POST` | `/api/v1/run/prompt` | Submit a single task |
| `POST` | `/api/v1/run/category` | Submit a full category run |
| `GET` | `/api/v1/status/<job_id>` | Poll job status |
| `GET` | `/api/v1/results/<category>` | Get category results |
| `GET` | `/api/v1/categories` | List available categories |
| `GET` | `/api/v1/stats` | Overall stats from GitHub |

> API documentation is available at `/api/v1/docs`. The API is intended for internal team use.

## Evaluation & Benchmarks

All examples are compiler-validated against the target NuGet version before being committed. The benchmark is a 100% build pass rate across all generated examples.

| Version | Total Examples | Pass Rate | Framework |
|---------|---------------|-----------|----------|
| 26.6.0 | 4720 | 100.0% | net9.0 |

Pass rate is enforced by the agent pipeline — only examples that pass both `dotnet build` and `dotnet run` are committed.

## How to Run Validation

Validation runs automatically on every pull request targeting `main` via GitHub Actions (`validate-pr.yml`).

To trigger validation:
1. Push your branch to GitHub
2. Open a pull request targeting `main`
3. GitHub Actions will automatically build and run all changed `.cs` files
4. Build failures block the merge — runtime errors are informational only

## Metrics

Each pipeline run ships telemetry to a central metrics store including examples discovered, passed and failed per category, LLM token usage, MCP and LLM API call counts, and pipeline duration.

## Capability Matrix

| Operation                     | Formats Supported                                          | Examples Count | Key Classes                              |
|-------------------------------|------------------------------------------------------------|----------------|------------------------------------------|
| General Conversion            | BMP, JPEG, PNG, TIFF, GIF, WebP, SVG, PSD, PDF, DICOM, CDR, CMX, EPS, ODG, APNG | 45             | Image, RasterImage, VectorImage, ImageOptionsBase |
| APNG Conversion               | APNG → PNG, GIF                                            | 5              | ApngOptions, PngOptions, Image          |
| CDR Conversion                | CDR → BMP, JPEG, PNG, TIFF, PDF                            | 4              | CdrImage, Image, BmpOptions, JpegOptions |
| CMX Images Conversion         | CMX → BMP, JPEG, PNG, TIFF                                 | 3              | CmxImage, Image, PngOptions              |
| DICOM Images Conversion       | DICOM → BMP, JPEG, PNG, TIFF, PDF                          | 6              | DicomImage, Image, TiffOptions           |
| EPS Images Conversion         | EPS → BMP, JPEG, PNG, TIFF, PDF                            | 5              | EpsImage, Image, PngOptions              |
| Open Document Graphics (ODG) | ODG → BMP, JPEG, PNG, TIFF, PDF                            | 4              | OdgImage, Image, JpegOptions             |
| Raster Image Conversion       | BMP, JPEG, PNG, TIFF, GIF, WebP                            | 12             | RasterImage, Image, BmpOptions, WebpOptions |
| SVG to Raster Images          | SVG → PNG, JPEG, BMP, TIFF, WebP                           | 8              | SvgImage, RasterImage, PngOptions, WebpOptions |
| WebP Images Conversion        | WebP ↔ BMP, JPEG, PNG, TIFF                                | 5              | WebpImage, Image, BmpOptions, JpegOptions |

## Related Resources  
Explore the full range of Aspose.Imaging for .NET C# image processing examples. If you need to transform vector graphics, see the **convert-svg-to-raster-images** and **convert-open-document-graphics** samples; for raster workflows, the **conversion** and **convert-webp-images** categories demonstrate image conversion C# techniques. The **image-and-photo-filters** and **kernel-filters** sections showcase advanced capabilities of this C# imaging library, while **merge-images** and **working-with-drawing-images** illustrate how to combine and draw on images using Aspose.Imaging examples. All of these resources are part of the dotnet image processing suite to help you get up and running quickly.

## Frequently Asked Questions

### Q: How to convert an image format using Aspose.Imaging for .NET  
Use the `ImageConverter` class or call `Image.Save` with a different `ImageFormat`. Load the source file with `Image.Load`, then invoke `image.Save("output.png", new PngOptions())` to perform image conversion C#. The Aspose.Imaging examples in the repository demonstrate this workflow for common formats.

### Q: How to resize an image in C# with Aspose.Imaging  
Instantiate a `ResizeOptions` object and set `Width`, `Height`, and `ResizeMode`, then call `image.Resize(resizeOptions)`. For loss‑less scaling, use `image.Save("resized.jpg", new JpegOptions { Quality = 90 })`. This is a typical pattern in dotnet image processing with the C# imaging library.

### Q: How to apply filters to images in dotnet  
Create a filter such as `GaussianBlurFilter` or `SharpenFilter` and pass it to `image.ApplyFilter(filter)`. After applying, save the result with the appropriate options, e.g., `image.Save("filtered.bmp")`. The Aspose.Imaging for .NET documentation includes code snippets for these C# image processing tasks.

### Q: How to draw shapes on images in C#  
Use the `Graphics` class obtained via `new Graphics(image)` and call methods like `DrawRectangle`, `DrawEllipse`, or `DrawLine` with a `Pen`. Remember to dispose the `Graphics` object to commit changes, then save the image. This approach is highlighted in the Aspose.Imaging examples for drawing with the C# imaging library.

### Q: How to merge multiple images in dotnet  
Load each image as a `RasterImage`, create a new canvas with the combined dimensions, and draw each source image onto it using `Graphics.DrawImage`. Finally, save the canvas as a single file, e.g., `merged.png`. The repository contains Aspose.Imaging for .NET sample code for image merging.

### Q: How to process DICOM medical images in C#  
Open a DICOM file with `DicomImage dicom = new DicomImage("file.dcm")` and access pixel data via `dicom.GetImage()`. You can then convert, resize, or apply filters just like any other raster image. This demonstrates powerful C# image processing capabilities of the Aspose.Imaging library.

### Q: How to convert SVG to raster images in dotnet  
Load the vector file using `SvgImage svg = (SvgImage)Image.Load("vector.svg")` and rasterize it with `svg.Save("output.png", new PngOptions())`. You can also specify size through `svg.Width` and `svg.Height` before saving. The Aspose.Imaging examples show this straightforward SVG conversion workflow.

### Q: How to create animated APNG files in C#  
Create an `ApngImage` instance, add frames with `apng.AddFrame(frameImage, frameDelay)`, and finally call `apng.Save("animation.apng")`. Each frame can be a `RasterImage` processed with the same C# imaging library tools. This is a common pattern in Aspose.Imaging for .NET for animated PNG generation.

### Q: How to use Aspose.Imaging without a license  
You can run the library in evaluation mode; simply omit the `License` registration code. The unlicensed mode adds a watermark to output images and limits some features, but all core C# image processing functions remain accessible. Refer to the Aspose.Imaging examples for guidance on handling the evaluation behavior.

### Q: What image formats does Aspose.Imaging support  
Aspose.Imaging for .NET supports raster formats (BMP, JPEG, PNG, TIFF, GIF, WebP), vector formats (SVG, EPS, WMF), medical formats (DICOM), and animated formats (APNG, animated GIF). The library also handles raw and proprietary formats through dedicated classes like `RawImage` and `DicomImage`. Check the official documentation for the full list of supported formats.

## Related Agentic .NET Example Repositories

Part of the Aspose agentic examples ecosystem — compiler-validated C# examples generated and maintained by AI agents:

| Repository | Product |
|------------|---------|
| [aspose-pdf/agentic-net-examples](https://github.com/aspose-pdf/agentic-net-examples) | Aspose.PDF for .NET |
| [aspose-words/agentic-net-examples](https://github.com/aspose-words/agentic-net-examples) | Aspose.Words for .NET |
| [aspose-cells/agentic-net-examples](https://github.com/aspose-cells/agentic-net-examples) | Aspose.Cells for .NET |
| [aspose-slides/agentic-net-examples](https://github.com/aspose-slides/agentic-net-examples) | Aspose.Slides for .NET |
| [aspose-email/agentic-net-examples](https://github.com/aspose-email/agentic-net-examples) | Aspose.Email for .NET |
| [aspose-barcode/agentic-net-examples](https://github.com/aspose-barcode/agentic-net-examples) | Aspose.BarCode for .NET |

---
*Maintained by an [agentic example generation workflow](https://metrics.aspose.com/agents/product-families/imaging/) | For AI-friendly guidance, see [AGENTS.md](https://github.com/aspose-imaging/agentic-net-examples/blob/main/agents.md) | Last updated: 2026-06-28*
