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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

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

                // Build output file path (same name with .png extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load TIFF image and save as APNG with 3 loops
                using (Image image = Image.Load(inputPath))
                {
                    var apngOptions = new ApngOptions
                    {
                        NumPlays = 3 // default loop count
                    };
                    image.Save(outputPath, apngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}