// HOW-TO: Batch Embed Digital Signatures into PNG Images with Size Validation in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "input";
            string outputDirectory = "output";
            string password = "password123";

            Directory.CreateDirectory(outputDirectory);

            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png", SearchOption.AllDirectories);
            foreach (string inputPath in pngFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string relativePath = Path.GetRelativePath(inputDirectory, inputPath);
                string outputPath = Path.Combine(outputDirectory, relativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (image.Width < 8 || image.Height < 8)
                    {
                        Console.Error.WriteLine($"Image too small (must be at least 8x8): {inputPath}");
                        continue;
                    }

                    image.EmbedDigitalSignature(password);
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
 * 1. When a company needs to protect a large collection of product screenshots by embedding a digital signature into each PNG file to verify authenticity later.
 * 2. When an automated build pipeline must add a cryptographic signature to every generated PNG asset while skipping images that are smaller than the required 8×8 pixels.
 * 3. When a regulatory‑compliant system has to embed tamper‑evident signatures into PNG diagrams before archiving them in a secure repository.
 * 4. When a developer wants to batch‑process user‑uploaded PNG icons, ensuring each meets the minimum size and is signed with a password‑protected key for later validation.
 * 5. When a digital forensics tool needs to tag a batch of PNG evidence images with a password‑protected signature while preserving the original image dimensions.
 */
