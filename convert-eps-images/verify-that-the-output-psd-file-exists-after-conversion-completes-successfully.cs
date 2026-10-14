// HOW-TO: Convert EPS to PSD and Verify Output File Exists in C# (Aspose.Imaging for .NET)
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

namespace AsposeImagingConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.eps";
                string outputPath = "output.psd";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as PSD using default options
                    PsdOptions psdOptions = new PsdOptions();
                    image.Save(outputPath, psdOptions);
                }

                // Verify output PSD file exists
                if (File.Exists(outputPath))
                {
                    Console.WriteLine("Output PSD file exists.");
                }
                else
                {
                    Console.Error.WriteLine($"Output PSD file not found: {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically convert vector EPS artwork to a Photoshop PSD file for further editing in a .NET application.
 * 2. When you must ensure the converted PSD file was created successfully before proceeding with downstream image processing steps.
 * 3. When you are building an automated workflow that reads EPS files from a folder, converts them to PSD, and validates the output to avoid missing files.
 * 4. When you want to use Aspose.Imaging to load an EPS image, save it as PSD with default options, and confirm the file exists to handle errors gracefully.
 * 5. When you are integrating image format conversion into a C# service and need to check the existence of the resulting PSD to trigger subsequent business logic.
 */
