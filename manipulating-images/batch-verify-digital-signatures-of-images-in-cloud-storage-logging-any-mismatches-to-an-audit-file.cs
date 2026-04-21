using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input image paths
            string[] inputPaths = new string[]
            {
                "cloudstorage/image1.jpg",
                "cloudstorage/image2.png",
                "cloudstorage/image3.tif"
            };

            // Password used for digital signature verification
            string password = "SecretPassword";

            // Audit log file path
            string auditFilePath = "audit/mismatches.txt";

            // Ensure audit directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(auditFilePath));

            using (var auditWriter = new StreamWriter(auditFilePath, true))
            {
                foreach (var inputPath in inputPaths)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Load image and check digital signature
                    using (Image image = Image.Load(inputPath))
                    {
                        // Cast to RasterImage to access IsDigitalSigned
                        var raster = image as RasterImage;
                        if (raster != null)
                        {
                            bool signed = raster.IsDigitalSigned(password);
                            if (!signed)
                            {
                                auditWriter.WriteLine($"{DateTime.UtcNow:u} - Signature mismatch: {inputPath}");
                            }
                        }
                        else
                        {
                            // If not a raster image, treat as unsigned
                            auditWriter.WriteLine($"{DateTime.UtcNow:u} - Unable to verify (non-raster): {inputPath}");
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