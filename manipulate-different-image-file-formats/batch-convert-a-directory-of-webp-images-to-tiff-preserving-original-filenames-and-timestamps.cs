using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\InputWebp";
        string outputDir = @"C:\Images\OutputTiff";

        try
        {
            // Ensure output directory exists (will also work if Path.GetDirectoryName returns null)
            Directory.CreateDirectory(outputDir);

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output path with the same filename but .tif extension
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".tif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    // Prepare TIFF save options (default format)
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                    // Save as TIFF
                    webPImage.Save(outputPath, tiffOptions);
                }

                // Preserve original timestamps
                DateTime creationTime = File.GetCreationTime(inputPath);
                DateTime lastWriteTime = File.GetLastWriteTime(inputPath);
                DateTime lastAccessTime = File.GetLastAccessTime(inputPath);

                File.SetCreationTime(outputPath, creationTime);
                File.SetLastWriteTime(outputPath, lastWriteTime);
                File.SetLastAccessTime(outputPath, lastAccessTime);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}