// HOW-TO: Convert APNG Animation to GIF with 256‑Color Palette in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "animation.apng");
            string outputPath = Path.Combine("Output", "animation.gif");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
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
 * 1. When you need to display an animated PNG on platforms that only support GIF, you can convert it to a GIF with a 256‑color palette using C#.
 * 2. When preparing assets for email newsletters that require GIF animations, you can transform APNG files to GIF while ensuring compatibility.
 * 3. When optimizing web content for older browsers that cannot render APNG, you can programmatically convert the animation to a GIF with reduced colors.
 * 4. When building a batch processing tool that standardizes animation formats for a digital asset pipeline, this code lets you convert APNG to GIF in .NET.
 * 5. When creating a fallback animation for mobile apps that only support GIF, you can use this snippet to generate a compatible GIF from an APNG source.
 */
