using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

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

            // Process 50 JPEG images named image1.jpg ... image50.jpg
            for (int i = 1; i <= 50; i++)
            {
                string inputPath = Path.Combine(inputDir, $"image{i}.jpg");
                string outputPath = Path.Combine(outputDir, $"image{i}_masked.jpg");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply magic wand mask, and save the result
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Create a mask using MagicWandTool with a reference point (0,0)
                    MagicWandTool
                        .Select(image, new MagicWandSettings(0, 0))
                        .Apply();

                    // Save the masked image as JPEG
                    image.Save(outputPath, new JpegOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}