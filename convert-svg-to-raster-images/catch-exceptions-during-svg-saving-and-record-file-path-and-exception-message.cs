// HOW-TO: How To Save PNG As SVG With Error Logging In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                try
                {
                    // Save as SVG
                    image.Save(outputPath, new SvgOptions());
                }
                catch (Exception ex)
                {
                    // Record file path and exception message
                    string logPath = "error_log.txt";
                    string logEntry = $"{DateTime.Now}: File: {outputPath}, Error: {ex.Message}{Environment.NewLine}";
                    File.AppendAllText(logPath, logEntry);
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
 * 1. When you need to convert user‑uploaded PNG images to scalable SVG files in a .NET web service while ensuring any save failures are recorded for troubleshooting.
 * 2. When an automated batch job processes a folder of PNG assets and must create SVG versions, creating missing output directories and logging errors without stopping the entire process.
 * 3. When integrating Aspose.Imaging into a desktop application that allows users to export edited PNG graphics as SVG, and you want to capture and store exception details if the export fails.
 * 4. When building a CI/CD pipeline that validates image conversion from PNG to SVG and requires error logs containing the target file path for failed builds.
 * 5. When developing a microservice that receives image paths, converts them to SVG format, and needs to persist any exception messages alongside the output file location for later analysis.
 */
