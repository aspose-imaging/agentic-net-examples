# Aspose.Imaging for .NET - Agentic Examples

> AI-generated, compiler-validated C# examples for the [Aspose.Imaging for .NET](https://products.aspose.com/imaging/net/) API.

## Statistics

| Metric | Value |
|--------|-------|
| Total Examples | 3127 |
| Categories | 17 |
| Overall Pass Rate | 100.0% |
| Last Updated | 2026-05-05 |

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
| [Convert APNG](./convert-apng/) | 53 | 100.0% | [agents.md](./convert-apng/agents.md) |
| [Convert CDR](./convert-cdr/) | 30 | 100.0% | [agents.md](./convert-cdr/agents.md) |
| [Convert CMX Images](./convert-cmx-images/) | 35 | 100.0% | [agents.md](./convert-cmx-images/agents.md) |
| [Convert DICOM Images](./convert-dicom-images/) | 30 | 100.0% | [agents.md](./convert-dicom-images/agents.md) |
| [Convert EPS Images](./convert-eps-images/) | 60 | 100.0% | [agents.md](./convert-eps-images/agents.md) |
| [Convert Open Document Graphics](./convert-open-document-graphics/) | 120 | 100.0% | [agents.md](./convert-open-document-graphics/agents.md) |
| [Convert Raster Image](./convert-raster-image/) | 138 | 100.0% | [agents.md](./convert-raster-image/agents.md) |
| [Convert SVG to Raster Images](./convert-svg-to-raster-images/) | 120 | 100.0% | [agents.md](./convert-svg-to-raster-images/agents.md) |
| [Convert webp Images](./convert-webp-images/) | 60 | 100.0% | [agents.md](./convert-webp-images/agents.md) |
| [Converting WMF and EMF](./converting-wmf-and-emf/) | 58 | 100.0% | [agents.md](./converting-wmf-and-emf/agents.md) |
| [Image and Photo Filters](./image-and-photo-filters/) | 209 | 100.0% | [agents.md](./image-and-photo-filters/agents.md) |
| [Kernel Filters](./kernel-filters/) | 465 | 100.0% | [agents.md](./kernel-filters/agents.md) |
| [Manipulate Different Image File Formats](./manipulate-different-image-file-formats/) | 628 | 100.0% | [agents.md](./manipulate-different-image-file-formats/agents.md) |
| [Manipulating Images](./manipulating-images/) | 407 | 100.0% | [agents.md](./manipulating-images/agents.md) |
| [Merge Images](./merge-images/) | 135 | 100.0% | [agents.md](./merge-images/agents.md) |
| [Working With Drawing Images](./working-with-drawing-images/) | 417 | 100.0% | [agents.md](./working-with-drawing-images/agents.md) |

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
| 26.4.0 | 3127 | 100.0% | net9.0 |

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

---
*Maintained by [agent-aspose-imaging-examples](https://github.com/agent-aspose-imaging-examples) | Run `20260505_041608` | 2026-05-05*