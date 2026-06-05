using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputTiffs";
            string outputDirectory = @"C:\OutputPngs";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Rotate 90 degrees clockwise, resizing proportionally and using black background
                    tiffImage.Rotate(90f, true, Color.Black);

                    // Save as PNG
                    tiffImage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}