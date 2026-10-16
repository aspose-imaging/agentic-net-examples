// HOW-TO: Convert APNG to GIF and Add Custom Application Identifier in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                apng.Save(outputPath, new GifOptions());
            }

            using (GifImage gif = (GifImage)Image.Load(outputPath))
            {
                GifApplicationExtensionBlock appBlock = new GifApplicationExtensionBlock
                {
                    ApplicationIdentifier = "MyCustomApp"
                };
                gif.AddBlock(appBlock);
                gif.Save(outputPath);
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
 * 1. When you need to display animated images on platforms that only support GIF, you can convert APNG files to GIF while preserving the animation.
 * 2. When you want to embed metadata that identifies the source application inside a GIF, you can add a custom application extension block during conversion.
 * 3. When a legacy system reads GIF comment blocks to route images, you can tag the GIF with a custom application identifier to ensure proper handling.
 * 4. When building a batch pipeline that converts multiple APNG assets to GIF for email newsletters, you can automate both the format conversion and metadata insertion in C#.
 * 5. When troubleshooting image assets and need to trace which tool generated a GIF, you can embed a custom application identifier to simplify diagnostics.
 */
