// HOW-TO: Asynchronously Convert Multiple OTG Files To BMP In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "input";
            string outputDirectory = "output";

            // Get all OTG files recursively
            var otgFiles = Directory.GetFiles(inputDirectory, "*.otg", SearchOption.AllDirectories);

            // Process each file asynchronously
            var tasks = otgFiles.Select(async filePath =>
            {
                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Determine relative path and corresponding output path with .bmp extension
                string relativePath = Path.GetRelativePath(inputDirectory, filePath);
                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(relativePath, ".bmp"));

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                await ConvertOtgToBmpAsync(filePath, outputPath);
            });

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertOtgToBmpAsync(string inputPath, string outputPath)
    {
        await Task.Run(() =>
        {
            // Load OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Save as BMP using default BmpOptions
                var bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a large collection of OTG drawings to BMP format on a server without blocking the thread pool.
 * 2. When you want to process OTG images stored in nested folders and save the results in a mirrored directory structure using asynchronous I/O.
 * 3. When you are building a .NET application that must keep the UI responsive while converting many OTG files to BMP in the background.
 * 4. When you require a scalable solution that leverages Aspose.Imaging to batch‑convert OTG files to BMP with minimal memory overhead.
 * 5. When you need to integrate non‑blocking image conversion into a cloud‑based workflow that handles OTG to BMP transformations on demand.
 */
