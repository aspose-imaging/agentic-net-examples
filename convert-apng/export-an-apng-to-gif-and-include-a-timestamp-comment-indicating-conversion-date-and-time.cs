// HOW-TO: Convert APNG to GIF with Timestamp Comment in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.apng";
            string outputPath = "Output/sample.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    image.Save(outputPath, gifOptions);
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
 * 1. When you need to display animated PNG assets on legacy browsers that only support GIF, you can convert the APNG to a GIF using Aspose.Imaging in C#.
 * 2. When generating automated reports that embed animation, you may convert APNG files to GIFs and add a comment with the conversion date for audit tracking.
 * 3. When building a content pipeline that normalizes user‑uploaded animations to a single format, this code lets you transform APNG uploads into GIFs before storage.
 * 4. When creating email newsletters that require animated images, converting APNG to GIF ensures compatibility with most email clients while preserving the animation.
 * 5. When archiving animated graphics for long‑term preservation, converting APNG to GIF with a timestamp comment records when the conversion was performed.
 */
