using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create first mask from point (100,150) and union it with a second mask from point (200,250)
                var combinedMask = MagicWandTool.Select(image, new MagicWandSettings(100, 150))
                                               .Union(new MagicWandSettings(200, 250));

                // Apply the combined mask to the image
                combinedMask.Apply();

                // Save the masked image back to TIFF format
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}