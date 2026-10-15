// HOW-TO: Resize SVG While Maintaining Aspect Ratio and Export to JPEG 90 Quality in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\drawing.svg";
            string outputPath = "Output\\drawing_resized.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;
                int originalWidth = svgImage.Width;
                int originalHeight = svgImage.Height;

                int targetWidth = 800;
                int targetHeight = (int)Math.Round((double)originalHeight * targetWidth / originalWidth);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = targetWidth,
                        PageHeight = targetHeight
                    }
                };

                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate thumbnail previews of SVG logos for a web gallery without distorting their proportions.
 * 2. When an e‑commerce platform must convert scalable product illustrations to JPEGs for email newsletters while keeping visual fidelity.
 * 3. When a reporting tool has to embed vector diagrams into PDF reports that only accept raster images, requiring a fixed width and high‑quality JPEG output.
 * 4. When a mobile app downloads SVG assets and must resize them on the server to a specific pixel width before sending them to devices with limited bandwidth.
 * 5. When a content management system automates batch processing of SVG icons, resizing each to a uniform size and storing them as JPEGs with 90 % quality for faster rendering.
 */
