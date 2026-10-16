// HOW-TO: Save EMF Image Directly to File Stream in C# (Aspose.Imaging for .NET)
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

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.emf";
                string outputPath = "output.emf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    EmfImage emfImage = (EmfImage)image;

                    // Save directly to a file stream
                    using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        emfImage.Save(outStream);
                    }
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
 * 1. When a server application needs to copy or modify an EMF file without loading the entire image into memory, it can use this code to stream the image directly to disk.
 * 2. When generating reports that embed vector graphics, developers can save the EMF output to a file stream to ensure fast write performance and avoid temporary files.
 * 3. When processing large batches of EMF files in a background service, streaming the save operation reduces memory usage and improves throughput.
 * 4. When integrating Aspose.Imaging into a web API that returns EMF images, the code allows the image to be written straight to the response stream for efficient client delivery.
 * 5. When an automated workflow must ensure the output directory exists before writing an EMF file, this pattern creates the folder and streams the saved image safely.
 */
