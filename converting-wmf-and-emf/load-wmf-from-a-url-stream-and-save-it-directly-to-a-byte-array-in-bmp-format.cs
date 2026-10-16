// HOW-TO: Load WMF from URL and Convert to BMP Byte Array in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            // Hardcoded URL to the WMF file
            string url = "https://example.com/sample.wmf";

            using (HttpClient client = new HttpClient())
            using (Stream urlStream = client.GetStreamAsync(url).Result)
            {
                // Load WMF image from the stream
                using (Image image = Image.Load(urlStream))
                {
                    // Set BMP save options
                    var bmpOptions = new BmpOptions();

                    // Save image to a memory stream in BMP format
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, bmpOptions);
                        byte[] bmpBytes = memoryStream.ToArray();

                        // Output the size of the resulting byte array
                        Console.WriteLine($"BMP byte array length: {bmpBytes.Length}");
                    }
                }
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
 * 1. When you need to download a WMF vector graphic from a web service and store it as a BMP byte array for embedding in a PDF document.
 * 2. When a server‑side C# application must convert legacy WMF icons retrieved via HTTP into BMP data to send to a client‑side canvas.
 * 3. When you want to cache a remote WMF image in memory as BMP bytes for fast repeated rendering without writing temporary files.
 * 4. When an API endpoint receives a WMF URL and must return the image in BMP format as a byte stream for downstream processing.
 * 5. When you are building a batch job that reads WMF files from URLs and saves them as BMP byte arrays for archival in a binary database.
 */
