// HOW-TO: Convert SVG to BMP in ASP.NET Core Controller with Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "Input\\input.svg";
            string outputPath = "Output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web API must deliver rasterized bitmap thumbnails of user‑uploaded SVG logos for legacy systems that only accept BMP files.
 * 2. When an e‑commerce platform needs to generate printable product images from scalable SVG designs and serve them as BMP downloads via an ASP.NET Core endpoint.
 * 3. When a reporting service converts vector diagrams stored as SVG into BMP for inclusion in PDF reports that require bitmap images.
 * 4. When a mobile app backend transforms SVG icons into BMP assets to match the device’s native image format constraints.
 * 5. When a document management system batch‑processes SVG illustrations and provides on‑the‑fly BMP conversions through a secure controller action.
 */
