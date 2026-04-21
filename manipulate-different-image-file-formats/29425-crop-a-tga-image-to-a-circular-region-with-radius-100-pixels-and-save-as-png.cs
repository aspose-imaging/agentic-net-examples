using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.png";

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
            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = (RasterImage)image;

                // Determine the center of the image
                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;

                // Create a circular mask with radius 100 pixels
                CircleMask mask = new CircleMask(centerX, centerY, 100);

                // Apply the mask to the image (makes outside area transparent)
                mask.ApplyTo(raster);

                // Save the result as PNG
                raster.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}