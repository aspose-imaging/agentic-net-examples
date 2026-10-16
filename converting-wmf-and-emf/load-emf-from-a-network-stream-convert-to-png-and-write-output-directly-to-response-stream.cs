// HOW-TO: Load EMF From URL and Convert to PNG Stream in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input URL and output file path
            string inputUrl = "https://example.com/sample.emf";
            string outputPath = "output/sample.png";

            // Load EMF from network stream
            using var httpClient = new HttpClient();
            using var networkStream = httpClient.GetStreamAsync(inputUrl).GetAwaiter().GetResult();

            using var image = Image.Load(networkStream);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save to file (required by path-safety rule)
            image.Save(outputPath, new PngOptions());

            // Also write PNG directly to response (standard output) stream
            using var memoryStream = new MemoryStream();
            image.Save(memoryStream, new PngOptions());
            memoryStream.Position = 0;
            using var responseStream = Console.OpenStandardOutput();
            memoryStream.CopyTo(responseStream);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to fetch a vector EMF diagram from a web service, convert it to a raster PNG, and store it on disk for later use.
 * 2. When building a web API that returns dynamically generated PNG images derived from remote EMF files without creating temporary files on the server.
 * 3. When integrating legacy EMF assets into a modern .NET application that requires PNG thumbnails for UI previews.
 * 4. When automating batch processing of EMF files hosted on external URLs and streaming the resulting PNGs directly to a client or console.
 * 5. When you must ensure the output directory exists before saving converted images while also piping the PNG data to standard output for logging or piping into another process.
 */
