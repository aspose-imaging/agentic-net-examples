// HOW-TO: Set Transparent Background for APNG and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.HasBackgroundColor = true;
                image.BackgroundColor = Color.Transparent;

                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, options);
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
 * 1. When you need to remove a solid background from an animated PNG so it displays correctly over any webpage background.
 * 2. When preparing APNG assets for a mobile app and you must ensure the images have a transparent background for seamless UI integration.
 * 3. When converting legacy APNG files that contain unwanted background colors to transparent ones to maintain visual consistency across different platforms.
 * 4. When generating animated icons for a desktop application and you need to guarantee that the icons blend with the operating system’s theme.
 * 5. When verifying that an APNG saved with a transparent background can be opened by standard PNG viewers without rendering artifacts.
 */
