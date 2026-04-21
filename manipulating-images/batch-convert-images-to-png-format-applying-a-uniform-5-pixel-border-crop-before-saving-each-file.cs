using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"c:\input\";
            string outputDir = @"c:\output\";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir);

            foreach (string inputPath in inputFiles)
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
                    // Calculate crop rectangle (5-pixel border on each side)
                    int cropX = 5;
                    int cropY = 5;
                    int cropWidth = Math.Max(0, image.Width - 2 * cropX);
                    int cropHeight = Math.Max(0, image.Height - 2 * cropY);
                    var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                    // Prepare PNG save options
                    var pngOptions = new PngOptions();

                    // Build output file path with .png extension
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                    // Ensure the output directory exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the cropped image as PNG
                    image.Save(outputPath, pngOptions, cropRect);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}