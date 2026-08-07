using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory and audit file paths
            string inputDirectory = @"C:\Images\Input";
            string auditFilePath = @"C:\Images\Audit\audit.txt";
            string password = "mySecret";

            // Ensure the audit directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(auditFilePath));

            // Open audit file for writing (overwrite existing)
            using (var auditWriter = new StreamWriter(auditFilePath, false))
            {
                // Supported image extensions
                string[] extensions = { ".png", ".jpg", ".jpeg", ".tiff", ".bmp", ".gif" };

                // Enumerate all files in the input directory
                var files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.AllDirectories);
                foreach (var filePath in files)
                {
                    // Process only supported image types
                    if (Array.IndexOf(extensions, Path.GetExtension(filePath).ToLower()) < 0)
                        continue;

                    // Verify the file exists
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    // Load the image using Aspose.Imaging
                    using (var image = Image.Load(filePath))
                    {
                        bool isSigned = false;

                        // Call the appropriate IsDigitalSigned overload based on the concrete type
                        if (image is RasterImage rasterImage)
                        {
                            isSigned = rasterImage.IsDigitalSigned(password);
                        }
                        else if (image is RasterCachedImage cachedImage)
                        {
                            isSigned = cachedImage.IsDigitalSigned(password);
                        }
                        else if (image is RasterCachedMultipageImage multiPageImage)
                        {
                            isSigned = multiPageImage.IsDigitalSigned(password);
                        }

                        // Log any mismatches to the audit file
                        if (!isSigned)
                        {
                            auditWriter.WriteLine($"{filePath} - signature mismatch");
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
 * 1. When a financial institution stores scanned checks in Azure Blob Storage and must verify that each PNG or TIFF file is digitally signed before processing payments, they can use this code to batch‑validate signatures and record any mismatches in an audit log.
 * 2. When a medical imaging provider archives DICOM‑derived JPEG and BMP images on Amazon S3 and needs to ensure regulatory compliance by confirming each image’s digital signature and logging failures for a HIPAA audit, this routine provides an automated solution.
 * 3. When an e‑commerce platform uploads product photos to Google Cloud Storage and wants to protect against tampering by checking the digital signature of every GIF, PNG, or JPEG before publishing, the code can scan the directory, verify signatures, and write discrepancies to an audit file.
 * 4. When a legal firm maintains a repository of signed evidence photos in a shared network drive and must generate a tamper‑evidence report for court, they can run this C# script to batch verify signatures across all supported image formats and capture any mismatches in a text audit.
 * 5. When a government agency archives satellite imagery in a cloud bucket and requires periodic integrity checks of signed GeoTIFF files, this example lets developers programmatically verify each image’s digital signature and log any anomalies for an audit trail.
 */