// HOW-TO: Embed Password Protected Digital Signature into JPEG and Verify in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/signed.jpg";
            string password = "Secret123";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Image img = Image.Load(fs))
                {
                    RasterImage raster = img as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine("Failed to load image as RasterImage.");
                        return;
                    }

                    raster.EmbedDigitalSignature(password);
                    raster.Save(outputPath);

                    bool isSigned = raster.IsDigitalSigned(password);
                    Console.WriteLine(isSigned ? "Image is digitally signed and verified." : "Verification failed.");
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
 * 1. When you need to protect a JPEG photo from tampering by embedding a password‑protected digital signature before sending it to a client.
 * 2. When an application must load an image from a file stream, sign it with a secret key, and store the signed version on disk for later audit.
 * 3. When you want to verify that a received JPEG image has not been altered by checking its digital signature using the same password.
 * 4. When integrating Aspose.Imaging into a C# workflow that requires secure image storage for legal or compliance documentation.
 * 5. When building a batch process that signs multiple JPEG files and confirms each signature before publishing them to a web portal.
 */
