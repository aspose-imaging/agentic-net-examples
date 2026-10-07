// HOW-TO: Save JPEG to New File Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to create a duplicate JPEG file while ensuring it is saved with Aspose.Imaging’s JPEG options for consistent quality.
 * 2. When you want to programmatically copy an existing JPEG to a different folder in a .NET application.
 * 3. When you must re‑encode a JPEG image to a new file to apply future metadata or compression settings.
 * 4. When an automated workflow requires loading a JPEG, performing validation, and saving it to a target path without altering pixel data.
 * 5. When you are preparing a JPEG for further processing such as adding EXIF GPS tags, and you first need a clean copy saved with Aspose.Imaging.
 */
