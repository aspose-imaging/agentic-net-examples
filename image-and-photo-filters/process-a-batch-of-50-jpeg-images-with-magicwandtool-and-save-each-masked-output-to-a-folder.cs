using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output folders
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output folder exists
            Directory.CreateDirectory(outputFolder);

            // Process 50 JPEG images
            for (int i = 1; i <= 50; i++)
            {
                // Build input and output file paths
                string inputPath = Path.Combine(inputFolder, $"image{i}.jpg");
                string outputPath = Path.Combine(outputFolder, $"image{i}_masked.png");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists (handles nested paths)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply magic wand mask, and save the result
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Create a mask using a reference point (10,10) and apply it
                    MagicWandTool.Select(image, new MagicWandSettings(10, 10)).Apply();

                    // Save the masked image
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}