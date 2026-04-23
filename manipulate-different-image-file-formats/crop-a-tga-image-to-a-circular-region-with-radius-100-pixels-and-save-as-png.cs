using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.tga";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel operations
                RasterImage raster = (RasterImage)image;

                // Define circle parameters (centered in the image, radius 100)
                int radius = 100;
                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;

                // Create a circular mask
                CircleMask mask = new CircleMask(centerX, centerY, radius);

                // Apply the mask to make pixels outside the circle transparent
                mask.ApplyTo(raster);

                // Crop to the bounding square of the circle
                Rectangle cropRect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                raster.Crop(cropRect);

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