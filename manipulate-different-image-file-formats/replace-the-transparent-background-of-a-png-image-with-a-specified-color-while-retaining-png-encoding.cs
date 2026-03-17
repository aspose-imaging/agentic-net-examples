using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG with transparent background
        string inputPath = "input.png";
        // Output PNG with background replaced
        string outputPath = "output.png";
        // Color to replace transparent pixels (example: solid blue)
        Aspose.Imaging.Color replaceColor = Aspose.Imaging.Color.Blue;

        // Load the PNG as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Get the full image bounds
            Aspose.Imaging.Rectangle bounds = raster.Bounds;

            // Load ARGB pixel data
            int[] pixels = raster.LoadArgb32Pixels(bounds);

            // Replace fully transparent pixels (alpha == 0) with the specified color
            int replaceArgb = (0xFF << 24) | (replaceColor.ToArgb() & 0x00FFFFFF);
            for (int i = 0; i < pixels.Length; i++)
            {
                int alpha = (pixels[i] >> 24) & 0xFF;
                if (alpha == 0)
                {
                    pixels[i] = replaceArgb;
                }
            }

            // Save the modified pixel data back to the image
            raster.SaveArgb32Pixels(bounds, pixels);

            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions
            {
                // Ensure the output is written as a PNG file
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the image with PNG encoding
            raster.Save(outputPath, pngOptions);
        }
    }
}