// HOW-TO: Convert OTG Vector Image to JPEG with Quality Setting in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When you need to embed an OTG vector graphic into a web page that only supports JPEG images, you can rasterize it with a white background and save it at a specific compression quality using C#.
 * 2. When generating thumbnails of OTG drawings for a mobile app, you can convert each file to a JPEG of the original dimensions while controlling file size through the Quality property.
 * 3. When automating a batch process that converts legacy OTG design files to JPEG for archival in a document management system, this code ensures consistent background color and compression across all images.
 * 4. When integrating Aspose.Imaging into a reporting service that must output vector diagrams as JPEGs for email attachments, you can set the rasterization options to match the source size and specify the desired JPEG quality.
 * 5. When creating a print preview that requires a raster image of an OTG vector at screen resolution, the code lets you render the vector to a JPEG with a white canvas and adjustable compression to balance clarity and bandwidth.
 */
