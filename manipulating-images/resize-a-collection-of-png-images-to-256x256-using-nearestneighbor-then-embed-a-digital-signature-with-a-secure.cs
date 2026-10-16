// HOW-TO: Resize PNG Images to 256x256 and Add Password Protected Digital Signature in C# (Aspose.Imaging for .NET)
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

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDirectory = "Input";
                string outputDirectory = "Output";

                if (!Directory.Exists(inputDirectory))
                {
                    Directory.CreateDirectory(inputDirectory);
                    Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                    return;
                }

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                string[] files = Directory.GetFiles(inputDirectory, "*.png");

                foreach (string inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + "_signed.png");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (RasterImage image = (RasterImage)Image.Load(inputPath))
                    {
                        image.Resize(256, 256, ResizeType.NearestNeighbourResample);
                        string password = "StrongPassword123!";
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑process a folder of PNG files to create uniform 256×256 thumbnails for a web gallery while ensuring each image is tamper‑evident with a password‑protected digital signature.
 * 2. When an e‑commerce platform must generate small product icons from high‑resolution PNG assets and embed a secure signature to verify the source before uploading to a CDN.
 * 3. When a mobile app requires pre‑scaled PNG assets for offline use and wants to protect the assets from unauthorized modification by embedding a digital signature with a strong password.
 * 4. When a document management system stores PNG scans and needs to standardize their size for indexing while adding a cryptographic signature to meet compliance requirements.
 * 5. When a game developer wants to automatically resize character sprites to 256×256 pixels and lock them with a password‑protected signature to prevent cheating or asset piracy.
 */
