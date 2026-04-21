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
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\InputWebp";
            string outputDir = @"C:\Images\OutputTiff";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each WebP file in the input directory
            foreach (string fileName in Directory.GetFiles(inputDir, "*.webp"))
            {
                string inputPath = fileName;
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".tif");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WebP image and save as TIFF
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