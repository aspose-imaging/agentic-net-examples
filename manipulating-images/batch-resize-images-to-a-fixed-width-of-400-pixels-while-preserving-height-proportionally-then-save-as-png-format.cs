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

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir);

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output file path (PNG format)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, resize width to 400 pixels proportionally, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    // Resize width proportionally; default resample type is used
                    image.ResizeWidthProportionally(400);

                    // Save the resized image as PNG
                    image.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}