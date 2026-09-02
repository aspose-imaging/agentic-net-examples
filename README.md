# Aspose.Imaging for .NET — Agentic C# Examples

## Statistics

| Metric | Value |
|--------|-------|
| Total Examples | 2901 |
| Categories | 17 |
| Overall Pass Rate | 100.0% |
| Last Updated | 2026-08-20 |

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
| [Convert APNG](./convert-apng/) | 51 | 100.0% | [agents.md](./convert-apng/agents.md) |
| [Convert CDR](./convert-cdr/) | 30 | 100.0% | [agents.md](./convert-cdr/agents.md) |
| [Convert CMX Images](./convert-cmx-images/) | 34 | 100.0% | [agents.md](./convert-cmx-images/agents.md) |
| [Convert DICOM Images](./convert-dicom-images/) | 30 | 100.0% | [agents.md](./convert-dicom-images/agents.md) |
| [Convert EPS Images](./convert-eps-images/) | 60 | 100.0% | [agents.md](./convert-eps-images/agents.md) |
| [Convert Open Document Graphics](./convert-open-document-graphics/) | 120 | 100.0% | [agents.md](./convert-open-document-graphics/agents.md) |
| [Convert Raster Image](./convert-raster-image/) | 139 | 100.0% | [agents.md](./convert-raster-image/agents.md) |
| [Convert SVG to Raster Images](./convert-svg-to-raster-images/) | 40 | 100.0% | [agents.md](./convert-svg-to-raster-images/agents.md) |
| [Convert webp Images](./convert-webp-images/) | 30 | 100.0% | [agents.md](./convert-webp-images/agents.md) |
| [Converting WMF and EMF](./converting-wmf-and-emf/) | 29 | 100.0% | [agents.md](./converting-wmf-and-emf/agents.md) |
| [Image and Photo Filters](./image-and-photo-filters/) | 148 | 100.0% | [agents.md](./image-and-photo-filters/agents.md) |
| [Kernel Filters](./kernel-filters/) | 465 | 100.0% | [agents.md](./kernel-filters/agents.md) |
| [Manipulate Different Image File Formats](./manipulate-different-image-file-formats/) | 602 | 100.0% | [agents.md](./manipulate-different-image-file-formats/agents.md) |
| [Manipulating Images](./manipulating-images/) | 425 | 100.0% | [agents.md](./manipulating-images/agents.md) |
| [Merge Images](./merge-images/) | 135 | 100.0% | [agents.md](./merge-images/agents.md) |
| [Working With Drawing Images](./working-with-drawing-images/) | 401 | 100.0% | [agents.md](./working-with-drawing-images/agents.md) |

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

| Version | Total Examples | 2901 | Framework |
|---------|---------------|-----------|----------|
| 26.6.0 | 2909 | 100.0% | net9.0 |

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


## Resources

| Resource | Link |
|----------|------|
| 📖 Documentation | [docs.aspose.com/imaging/net](https://docs.aspose.com/imaging/net/) |
| 📦 NuGet Package | [www.nuget.org/packages/aspose.imaging](https://www.nuget.org/packages/aspose.imaging) |
| 🚀 Release Notes | [releases.aspose.com/imaging/net](https://releases.aspose.com/imaging/net/) |
| 🌐 Online Apps | [products.aspose.app/imaging/family](https://products.aspose.app/imaging/family/) |
| 🔑 Free Temporary License | [purchase.aspose.com/temporary-license](https://purchase.aspose.com/temporary-license) |
| 🤝 Consulting (paid implementation help) | [consulting.aspose.com](https://consulting.aspose.com/) |
| 🤖 Agent API | [agent.json](/.well-known/agent.json) |

| Category                              | Examples | Key APIs                                                                                 |
|---------------------------------------|----------|------------------------------------------------------------------------------------------|
| conversion                            | 162      | ApngFrame, ApngImage, BmpOptions, CdrImage                                                |
| convert-apng                          | 51       | ApngFrame, ApngImage, ApngOptions, BmpOptions                                            |
| convert-cdr                           | 30       | CdrImage, CdrLoadOptions, CdrRasterizationOptions, JpegOptions                         |
| convert-cmx-images                    | 34       | BmpOptions, CmxImage, CmxLoadOptions, CmxRasterizationOptions                           |
| convert-dicom-images                  | 30       | ApngOptions, DicomImage, DicomOptions, LoadOptions                                      |
| convert-eps-images                    | 60       | ApngOptions, BmpOptions, EpsImage, EpsLoadOptions                                        |
| convert-open-document-graphics        | 120      | BmpImage, BmpOptions, GaussianBlurFilterOptions, Graphics                               |
| convert-raster-image                  | 139      | BmpImage, BmpOptions, ConvolutionFilterOptions, GaussianBlurFilterOptions               |
| convert-svg-to-raster-images          | 40       | BmpImage, BmpOptions, Graphics, Html5CanvasOptions                                      |
| convert-webp-images                   | 30       | GifImage, GifOptions, JpegOptions, PdfCoreOptions                                        |
| converting-wmf-and-emf                | 29       | BmpImage, BmpOptions, EmfImage, EmfRasterizationOptions                                 |
| image-and-photo-filters               | 148      | AutoMaskingGraphCutOptions, BigTiffImage, BilateralSmoothingFilterOptions, BmpImage    |
| kernel-filters                        | 465      | ApngFrame, ApngImage, ApngOptions, BilateralSmoothingFilterOptions                      |
| manipulate-different-image-file-formats| 602     | BigTiffImage, BigTiffOptions, BmpImage, BmpOptions                                       |
| manipulating-images                   | 425      | ApngFrame, ApngImage, ApngOptions, AutoMaskingGraphCutOptions                           |
| merge-images                          | 135      | ApngImage, ApngOptions, BigTiffImage, BigTiffOptions                                    |
| working-with-drawing-images           | 401      | ApngOptions, BmpImage, BmpOptions, ConvolutionFilterOptions                            |

## Related Resources  
If you need to **convert svg to png c#**, the *convert-svg-to-raster-images* examples show a straightforward way to rasterize SVG files in a .NET application. For medical and document formats, see *convert-dicom-images* (which includes a **convert dicom image to jpeg c#** sample) and *convert-eps-images* for a **convert eps file to pdf c#** workflow. The *kernel-filters* collection demonstrates how to **apply kernel filter to bitmap c#**, while *image-and-photo-filters* offers additional styling options. Finally, the *merge-images* and *convert-apng* samples illustrate how to **merge multiple png files into one image c#** and how to **convert apng to gif using asp.net** with Aspose.Imaging for .NET.

## Frequently Asked Questions

### Q: What image formats can Aspose.Imaging convert in .NET?  
Aspose.Imaging supports raster formats (JPEG, PNG, BMP, TIFF, GIF) and vector formats (SVG, EPS, EMF, WMF) as well as medical formats such as DICOM and PDF. You can use `Image.Load` together with format‑specific options like `PngOptions` or `PdfOptions` to **convert svg to png c#** or **convert eps file to pdf c#** in just a few lines of code. The library also handles multi‑page documents and animated formats, making it a one‑stop solution for most image conversion scenarios.

### Q: How do I apply photo filters to an image using Aspose.Imaging?  
The `ImageProcessor` class lets you chain filters; for example, `new ConvolutionFilter(kernel)` applies a custom kernel to a bitmap. By loading the image with `RasterImage` and calling `processor.Apply(new ConvolutionFilter(kernel))`, you can **apply kernel filter to bitmap c#** efficiently. After processing, save the result with the appropriate `ImageOptions` (e.g., `JpegOptions`).  

### Q: Can I merge several images into one file with Aspose.Imaging for .NET?  
Yes—use the `ImageCollection` class to load each source image and then call `Image.Save` with `PngOptions` on a new `RasterImage` that has the combined dimensions. This approach lets you **merge multiple png files into one image c#** without manual pixel manipulation. The example in the repository demonstrates positioning each image on a canvas and exporting the final composite.  

### Q: Which categories contain examples for converting medical DICOM images?  
Check the **Medical Imaging → DICOM** folder; it includes samples that load a `DicomImage`, adjust window/level, and then save to common formats. The code uses `DicomImage` together with `JpegOptions` to **convert dicom image to jpeg c#**. Additional examples show conversion to PNG and BMP for downstream processing.  

### Q: Is there a sample for converting WMF or EMF files to PNG with Aspose.Imaging?  
The **Vector Formats** section contains a snippet that loads a `MetafileImage` (WMF/EMF) and saves it with `PngOptions`. While reviewing that folder you’ll also find a related demo that **convert apng to gif using asp.net**, illustrating how the same API can handle animated PNG to GIF conversion in a web context. The sample demonstrates a one‑line `image.Save("output.png", new PngOptions())` call.

## Why Aspose.Imaging for .NET
This library covers 17 real‑world image‑processing scenarios—from format conversion (APNG, CDR, DICOM, EPS, SVG, WebP, WMF/EMF, etc.) to filters, kernel operations, merging and drawing—so you won’t have to stitch together multiple third‑party tools. Because Aspose.Imaging for .NET is a UI‑agnostic backend API, it runs everywhere .NET runs (ASP.NET Core, console apps, Azure Functions, Docker containers) without requiring a display or UI framework. You can get a free temporary license to evaluate it today, and you’ll find production customers and success‑story references on the Aspose website if you need proof of reliability. For organizations that need implementation assistance, paid consulting services are available, making it easier to integrate the library into larger products.
---
*Maintained by an [agentic example generation workflow](https://metrics.aspose.com/agents/product-families/imaging/) | For AI-friendly guidance, see [AGENTS.md](https://github.com/aspose-imaging/agentic-net-examples/blob/main/agents.md) | Last updated: 2026-06-29*
