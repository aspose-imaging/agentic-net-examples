// HOW-TO: Batch Crop EMF Images In Folder By Fixed Pixels Using C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing EMF files
            string inputDirectory = @"C:\Images\Input";

            // Ensure the directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Get all EMF files in the directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the EMF image
                using (EmfImage image = (EmfImage)Image.Load(inputPath))
                {
                    // Crop by shifts: remove 10 pixels from each side
                    int left = 10;
                    int right = 10;
                    int top = 10;
                    int bottom = 10;
                    image.Crop(left, right, top, bottom);

                    // Overwrite the original file
                    string outputPath = inputPath;

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the cropped image
                    image.Save(outputPath);
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
 * 1. When you need to remove a uniform border from a large set of EMF vector graphics before publishing them.
 * 2. When an automated build process must trim whitespace from all EMF files in a resource directory without creating new files.
 * 3. When a desktop application has to prepare EMF icons by cropping 10‑pixel margins in bulk to fit UI guidelines.
 * 4. When a migration script must standardize the canvas size of existing EMF diagrams by cropping identical amounts on each side.
 * 5. When a reporting tool generates EMF charts and you must programmatically eliminate extra padding from every chart file in a folder.
 */
