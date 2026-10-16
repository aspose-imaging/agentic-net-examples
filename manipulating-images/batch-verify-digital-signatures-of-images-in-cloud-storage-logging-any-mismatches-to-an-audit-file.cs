// HOW-TO: Batch Verify Image Digital Signatures And Log Mismatches In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths and password
            string inputFolder = @"C:\Images\Input";
            string auditFilePath = @"C:\Images\audit.txt";
            string password = "SecretPwd";

            // Ensure the audit file directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(auditFilePath));

            using (var writer = new StreamWriter(auditFilePath, append: true))
            {
                // Get all files in the input folder (including subfolders)
                foreach (string filePath in Directory.GetFiles(inputFolder, "*.*", SearchOption.AllDirectories))
                {
                    // Verify file existence
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Load the image
                    using (Image image = Image.Load(filePath))
                    {
                        // Work with raster images that support digital signatures
                        if (image is RasterImage rasterImage)
                        {
                            bool isSigned = rasterImage.IsDigitalSigned(password);
                            if (!isSigned)
                            {
                                writer.WriteLine($"{filePath} - signature mismatch");
                            }
                        }
                        else
                        {
                            // Non‑raster images are ignored for signature verification
                            continue;
                        }
                    }
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
 * 1. When you need to ensure that a large collection of JPEG or PNG files stored in a cloud bucket has not been tampered with, you can batch‑verify their digital signatures and record any mismatches.
 * 2. When regulatory compliance requires an audit trail of image integrity checks, this code logs every signature failure to a text file for later review.
 * 3. When a document management system imports scanned raster images and must reject any files whose embedded digital signature does not match the expected password, the routine automatically filters them.
 * 4. When migrating legacy image archives to a new server, you can run this script to confirm that each raster image’s digital signature remains valid before the transfer.
 * 5. When building a scheduled maintenance job that scans all subfolders of an image repository, the program quickly identifies unsigned or corrupted images and writes their paths to an audit log.
 */
