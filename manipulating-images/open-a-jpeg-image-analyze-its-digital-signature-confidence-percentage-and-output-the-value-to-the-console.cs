// HOW-TO: How To Get Digital Signature Confidence Percentage From A JPEG In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (var image = Image.Load(inputPath) as RasterImage)
            {
                if (image == null)
                {
                    Console.Error.WriteLine("Failed to load image as RasterImage.");
                    return;
                }

                string password = "password";
                int confidence = image.AnalyzePercentageDigitalSignature(password);
                Console.WriteLine($"Digital signature confidence: {confidence}%");
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
 * 1. When you need to verify the authenticity of a JPEG received from a client by checking its digital signature confidence percentage in a C# application.
 * 2. When integrating Aspose.Imaging into a document management system to ensure uploaded images have not been tampered with by reading the signature confidence before storage.
 * 3. When building a forensic analysis tool that reports the trust level of image files by extracting the digital signature confidence from JPEGs using C#.
 * 4. When creating an automated quality‑control pipeline that flags images with low signature confidence for manual review in a .NET image‑processing workflow.
 * 5. When developing a secure image‑sharing service that displays the digital signature confidence to end users to reassure them of the image’s integrity.
 */
