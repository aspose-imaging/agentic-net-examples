// HOW-TO: Batch Convert BMP to SVG with Timestamped Filenames in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputBmp";
            string outputDirectory = @"C:\OutputSvg";

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Create a timestamp prefix for uniqueness
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string outputFileName = $"{timestamp}_{Path.GetFileNameWithoutExtension(inputPath)}.svg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP and save as SVG
                using (Image image = Image.Load(inputPath))
                {
                    var svgOptions = new SvgOptions();
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to migrate a folder of legacy BMP icons to scalable SVG format while ensuring each output file has a unique timestamp to avoid overwriting existing assets.
 * 2. When an automated build process must convert user‑uploaded BMP drawings into SVG for web display and requires unique filenames to prevent naming collisions.
 * 3. When a desktop application processes scanned BMP documents in bulk and saves them as SVG with timestamp prefixes for easy chronological tracking.
 * 4. When a content management system needs to generate SVG versions of BMP graphics for responsive design and wants each file uniquely identified by its creation time.
 * 5. When a data‑archiving script must preserve original BMP files while creating timestamped SVG copies for long‑term storage and version control.
 */
