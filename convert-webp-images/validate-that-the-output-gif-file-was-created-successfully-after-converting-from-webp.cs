// HOW-TO: Convert WebP to GIF and Verify Output File in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
            }

            if (File.Exists(outputPath))
            {
                Console.WriteLine($"GIF file created successfully: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine($"Failed to create GIF file: {outputPath}");
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
 * 1. When you need to display animated WebP assets on platforms that only support GIF, you can convert the WebP file to GIF using Aspose.Imaging in C# and confirm the conversion succeeded.
 * 2. When automating a batch process that prepares images for email newsletters, you can transform each WebP image to a GIF and verify the output file exists before sending.
 * 3. When integrating image handling in a web application that receives user‑uploaded WebP pictures, you can convert them to GIF for legacy browsers and ensure the file was created successfully.
 * 4. When building a migration tool that moves graphics from a modern format to a legacy format, you can use this code to convert WebP to GIF and check the result to avoid broken links.
 * 5. When creating a server‑side service that generates GIF previews from WebP thumbnails, the code lets you perform the conversion and validate the preview file was generated without errors.
 */
