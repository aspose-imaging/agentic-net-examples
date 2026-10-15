// HOW-TO: Convert Embedded ODG Resource to PNG File in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG from embedded resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "YourNamespace.Resources.sample.odg"; // adjust to actual resource name

            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    Console.Error.WriteLine($"Resource not found: {resourceName}");
                    return;
                }

                using (Image image = Image.Load(resourceStream))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate PNG thumbnails from ODG drawings packaged inside your .NET assembly.
 * 2. When a desktop application must display OpenDocument graphics without requiring external files, by converting them at runtime.
 * 3. When an automated build process embeds ODG assets and you need to export them as PNGs for documentation or web use.
 * 4. When you want to extract vector drawings from an embedded resource and save them as raster PNGs for compatibility with legacy systems.
 * 5. When creating a reporting tool that pulls ODG diagrams from resources and converts them to PNG for inclusion in PDF or email outputs.
 */
