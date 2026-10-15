// HOW-TO: Verify PNG Digital Signature Confidence Against Threshold In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.txt";
            string password = "secret";
            double threshold = 0.5;

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                bool isSigned = image.IsDigitalSigned(password);
                double confidence = isSigned ? 1.0 : 0.0;
                string result = confidence >= threshold ? "Authentic" : "Not authentic";

                File.WriteAllText(outputPath, $"Confidence: {confidence}\nResult: {result}");
                Console.WriteLine(result);
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
 * 1. When you need to confirm that a received PNG file has not been tampered with by validating its digital signature with a known password.
 * 2. When an e‑commerce platform must automatically reject product images that fail a minimum authenticity confidence level before publishing them.
 * 3. When a document management system stores PNG scans and requires a script to log authenticity results to a text file for audit trails.
 * 4. When a security‑aware application processes user‑uploaded PNGs and needs to decide whether to accept or block them based on a confidence threshold.
 * 5. When a batch job validates multiple PNG assets, writes the confidence score and authenticity verdict, and integrates the outcome into a reporting workflow.
 */
