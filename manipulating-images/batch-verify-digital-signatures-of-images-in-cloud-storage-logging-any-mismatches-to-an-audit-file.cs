using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputDirectory = @"C:\Images\Input";
        string auditFilePath = @"C:\Images\Audit\audit.txt";
        string password = "YourPassword"; // password used for signature verification

        // Ensure audit directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(auditFilePath));

        try
        {
            // Get all files in the input directory (including subfolders)
            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.AllDirectories);

            foreach (string inputPath in imageFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access IsDigitalSigned
                    bool isSigned = false;
                    if (image is RasterImage rasterImage)
                    {
                        // Perform fast digital signature check (default threshold)
                        isSigned = rasterImage.IsDigitalSigned(password);
                    }
                    else if (image is RasterCachedImage cachedImage)
                    {
                        isSigned = cachedImage.IsDigitalSigned(password);
                    }
                    else if (image is RasterCachedMultipageImage cachedMultiPageImage)
                    {
                        isSigned = cachedMultiPageImage.IsDigitalSigned(password);
                    }

                    // Log mismatches
                    if (!isSigned)
                    {
                        string logEntry = $"{DateTime.UtcNow:u} - Signature mismatch: {inputPath}{Environment.NewLine}";
                        File.AppendAllText(auditFilePath, logEntry);
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