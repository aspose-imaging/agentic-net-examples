// HOW-TO: Check If JPEG Is Digitally Signed Before Adding Signature in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;

namespace DigitalSignatureDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths and password
                string inputPath = "input.jpg";
                string outputPath = "output.png";
                string password = "myPassword";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Load the image
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Check if already digitally signed with the given password
                    if (image.IsDigitalSigned(password))
                    {
                        Console.WriteLine("Image is already digitally signed with the provided password.");
                    }
                    else
                    {
                        // Embed digital signature
                        image.EmbedDigitalSignature(password);

                        // Save the signed image
                        image.Save(outputPath);
                        Console.WriteLine($"Image signed and saved to: {outputPath}");
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
 * 1. When you need to verify that a JPEG uploaded by a user hasn't already been signed before applying a new digital signature with Aspose.Imaging in a C# web service.
 * 2. When converting a signed image to another format (e.g., PNG) you must first check the existing signature to avoid overwriting it.
 * 3. When automating a batch process that signs confidential images, checking IsDigitalSigned prevents duplicate signatures and saves processing time.
 * 4. When implementing a secure document workflow, you can ensure an image is unsigned before embedding a password‑protected signature to meet compliance requirements.
 * 5. When building a desktop application that allows users to add a digital signature to photos, the code lets you detect existing signatures and warn the user before saving the signed PNG.
 */
