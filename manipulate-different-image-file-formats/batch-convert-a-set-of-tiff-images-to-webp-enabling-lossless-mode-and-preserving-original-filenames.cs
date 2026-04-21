using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\input\";
            string outputDir = @"C:\output\";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path preserving original filename (change extension to .webp)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save as lossless WebP
                using (Image image = Image.Load(inputPath))
                {
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };
                    image.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}