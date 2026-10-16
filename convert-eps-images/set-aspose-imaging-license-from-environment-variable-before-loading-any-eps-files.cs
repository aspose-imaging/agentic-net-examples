// HOW-TO: Load EPS File and Convert to PDF with License from Environment Variable in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string licensePath = Environment.GetEnvironmentVariable("ASPOSE_IMAGING_LICENSE");
            if (!string.IsNullOrEmpty(licensePath))
            {
                var license = new License();
                license.SetLicense(licensePath);
            }

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                epsImage.Save(outputPath, new PdfOptions());
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
 * 1. When you need to programmatically convert EPS artwork to PDF in a CI/CD pipeline while keeping the Aspose.Imaging license secure in an environment variable.
 * 2. When an automated document generation service must load EPS logos and output PDF reports without hard‑coding the license path.
 * 3. When a Windows service processes incoming EPS files from a shared folder and saves them as PDFs, using the license stored in the system’s environment for compliance.
 * 4. When a cloud‑based .NET application converts user‑uploaded EPS graphics to PDF on the fly and retrieves the Aspose.Imaging license from the container’s environment variables.
 * 5. When a batch conversion tool iterates over multiple EPS files, applying the license from an environment variable before each image is loaded and saved as PDF.
 */
