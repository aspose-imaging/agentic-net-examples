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
            // Cast to RasterImage for mask operations
            RasterImage raster = (RasterImage)image;

            // Define circle parameters (centered in the image, radius 100)
            int centerX = raster.Width / 2;
            int centerY = raster.Height / 2;
            int radius = 100;

            // Create a circular mask
            CircleMask mask = new CircleMask(centerX, centerY, radius);

            // Apply the mask to make pixels outside the circle transparent
            mask.ApplyTo(raster);

            // Crop to the bounding square of the circle to remove excess transparent area
            int left = centerX - radius;
            int top = centerY - radius;
            int size = radius * 2;
            raster.Crop(new Aspose.Imaging.Rectangle(left, top, size, size));

            // Save the result as PNG (preserves transparency)
            raster.Save(outputPath, new PngOptions());
        }
    }
}