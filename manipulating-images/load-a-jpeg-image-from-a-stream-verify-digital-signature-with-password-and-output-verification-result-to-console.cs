// HOW-TO: Verify JPEG Digital Signature From Stream Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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

namespace DigitalSignatureVerifier
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.jpg";
                string password = "secret123";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    using (RasterImage image = (RasterImage)Image.Load(fs))
                    {
                        bool isSigned = image.IsDigitalSigned(password);
                        Console.WriteLine(isSigned ? "Image is digitally signed." : "Image is NOT digitally signed.");
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
 * 1. When you need to confirm that a received JPEG image has not been tampered with by checking its embedded digital signature before processing it.
 * 2. When an application must validate the authenticity of user‑uploaded photos in a secure workflow using a password‑protected signature.
 * 3. When integrating a compliance check that ensures archived JPEG files retain their original digital signature during batch import.
 * 4. When building a server‑side service that reads image data from a stream and verifies the signature to grant or deny access.
 * 5. When troubleshooting image security by printing to the console whether a JPEG file is digitally signed with the expected password.
 */
