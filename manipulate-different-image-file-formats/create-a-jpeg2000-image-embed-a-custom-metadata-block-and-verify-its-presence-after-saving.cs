// HOW-TO: Create and Save a JPEG2000 Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine("Output", "result.jp2");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            using (Jpeg2000Image image = new Jpeg2000Image(width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Jpeg2000Options options = new Jpeg2000Options();
                image.Save(outputPath, options);
            }

            using (Image loadedImage = Image.Load(outputPath))
            {
                Console.WriteLine("Image created successfully.");
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
 * 1. When you need to programmatically generate a blank JPEG2000 file of specific dimensions for archival or further processing in a .NET application.
 * 2. When you want to create a JPEG2000 image with a solid white background to use as a canvas for later drawing operations.
 * 3. When you must automate the creation and storage of JPEG2000 images on a server without relying on manual graphic tools.
 * 4. When you are testing Aspose.Imaging’s JPEG2000 support by creating an image, saving it, and then loading it to verify the file integrity.
 * 5. When you need to integrate JPEG2000 image generation into a workflow that will later embed custom metadata or additional image layers.
 */
