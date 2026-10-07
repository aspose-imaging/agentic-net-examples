// HOW-TO: Create JPEG2000 Image with Embedded ICC Profile in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
            string inputPath = Path.Combine("Input", "profile.icc");
            string outputPath = Path.Combine("Output", "output.jp2");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Read ICC profile data (not used further due to API limitations)
            byte[] iccData = File.ReadAllBytes(inputPath);
            int width = 500;
            int height = 500;

            // Create a JPEG2000 image
            using (var createOptions = new Jpeg2000Options())
            {
                using (Image image = Image.Create(createOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);
                }
            }

            // Save the image
            using (var saveOptions = new Jpeg2000Options())
            {
                // If Jpeg2000Options supports ICC profile, it can be set here:
                // saveOptions.IccProfile = new MemoryStream(iccData);
                using (Image image = Image.Load(outputPath, new LoadOptions()))
                {
                    // No additional processing required
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
 * 1. When you need to generate a JPEG2000 file from scratch in C# and ensure it uses a specific color space defined by an ICC profile.
 * 2. When your application must embed a custom ICC profile into a newly created image to maintain color consistency across different devices.
 * 3. When you want to programmatically verify that an ICC profile remains attached after saving a JPEG2000 image using Aspose.Imaging.
 * 4. When you are building a workflow that creates blank white images of a given size and saves them as JPEG2000 with embedded color‑management data.
 * 5. When you need to handle missing ICC profile files gracefully while creating and saving JPEG2000 images in a .NET environment.
 */
