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
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        try
        {
            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output path with .tiff extension, preserving the original filename
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".tiff");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save it as TIFF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    webPImage.Save(outputPath, tiffOptions);
                }

                // Preserve original timestamps
                DateTime creationTime = File.GetCreationTime(inputPath);
                DateTime lastWriteTime = File.GetLastWriteTime(inputPath);
                File.SetCreationTime(outputPath, creationTime);
                File.SetLastWriteTime(outputPath, lastWriteTime);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}