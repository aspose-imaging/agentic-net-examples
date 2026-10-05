// HOW-TO: Batch Verify Image Digital Signatures and Log Mismatches in C# (Aspose.Imaging for .NET)
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
            // Hardcoded paths
            string inputDirectory = @"C:\Images\Input";
            string auditFilePath = @"C:\Images\Audit\audit.txt";
            string password = "SecretPwd";

            // Ensure audit directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(auditFilePath));

            // Open audit file for appending
            using (var auditWriter = new StreamWriter(auditFilePath, true))
            {
                // Get all files in the input directory (non-recursive)
                foreach (string filePath in Directory.GetFiles(inputDirectory))
                {
                    // Verify file existence
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Load image
                    using (Image img = Image.Load(filePath))
                    {
                        // Ensure we are working with a RasterImage
                        if (img is RasterImage rasterImg)
                        {
                            bool isSigned = rasterImg.IsDigitalSigned(password);
                            if (!isSigned)
                            {
                                // Log mismatch
                                auditWriter.WriteLine($"{DateTime.UtcNow:u} - Signature mismatch: {filePath}");
                            }
                        }
                        else
                        {
                            // Not a raster image; skip or log as needed
                            Console.Error.WriteLine($"Unsupported image format: {filePath}");
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
 * 1. When a compliance system must confirm that all uploaded PNG or JPEG files are digitally signed before they are archived, this code can scan the folder and record any unsigned images.
 * 2. When a medical imaging workflow needs to detect tampered raster images by checking their digital signatures and writing discrepancies to an audit log.
 * 3. When a content management platform stores user‑generated images in cloud storage and wants to run a nightly job that validates each file’s signature using Aspose.Imaging and logs failures for review.
 * 4. When a legal firm requires proof that evidence photos have not been altered, they can use this routine to batch‑verify signatures and generate a timestamped audit trail.
 * 5. When an e‑commerce site processes product photos and must ensure that no image has been modified after upload, this script can automatically flag and log any signature mismatches.
 */
