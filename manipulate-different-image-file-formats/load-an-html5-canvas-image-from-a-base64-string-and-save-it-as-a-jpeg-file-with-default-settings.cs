// HOW-TO: Convert Base64 HTML5 Canvas Image To JPEG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Base64-encoded HTML5 Canvas image (example PNG data)
            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=";
            byte[] imageBytes = Convert.FromBase64String(base64);

            using (var ms = new MemoryStream(imageBytes))
            {
                using (Image image = Image.Load(ms))
                {
                    string outputPath = "output/result.jpg";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you receive a PNG image from a web canvas as a base64 string and need to store it as a JPEG file on the server.
 * 2. When you want to reduce the size of a canvas‑generated image by converting it to JPEG before saving it to disk.
 * 3. When you need to integrate client‑side drawing data into a .NET backend for archival or further processing.
 * 4. When you are building an API that accepts base64‑encoded images from browsers and must output standard JPEG files.
 * 5. When you must create a JPEG thumbnail from a base64 canvas snapshot without applying custom compression settings.
 */
