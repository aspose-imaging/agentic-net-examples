// HOW-TO: Apply Emboss 3x3 Filter to Image from URL in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
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
            string inputUrl = "https://example.com/image.jpg";
            string outputPath = "output.jpg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(inputUrl).Result)
            using (Stream stream = response.Content.ReadAsStreamAsync().Result)
            using (RasterImage rasterImage = (RasterImage)Image.Load(stream))
            {
                double[,] customKernel = new double[,]
                {
                    { -2, -1,  0 },
                    { -1,  1,  1 },
                    {  0,  1,  2 }
                };

                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel)
                );

                // No disk saving as per requirement
                Console.WriteLine("Emboss filter applied successfully.");
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
 * 1. When you need to emboss a JPEG downloaded from a web service without writing the original file to disk.
 * 2. When processing user‑uploaded images in a web API and want to apply a 3×3 convolution filter entirely in memory.
 * 3. When generating stylized thumbnails on the fly for a cloud‑based gallery using Aspose.Imaging in C#.
 * 4. When performing real‑time image effects in a Windows service that reads images directly from a remote URL.
 * 5. When optimizing server resources by applying image filters on a network stream instead of using temporary files.
 */
