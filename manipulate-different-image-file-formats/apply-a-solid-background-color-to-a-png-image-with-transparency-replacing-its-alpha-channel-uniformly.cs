using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Define the solid background color (e.g., opaque red)
        Color backgroundColor = Color.FromArgb(255, 255, 0, 0);
        int backgroundArgb = backgroundColor.ToArgb();

        // Load the PNG image as a raster image
        using (RasterImage png = (RasterImage)Image.Load(inputPath))
        {
            // Load all ARGB pixels
            int[] pixels = png.LoadArgb32Pixels(png.Bounds);

            // Replace fully transparent pixels with the background color
            for (int i = 0; i < pixels.Length; i++)
            {
                int alpha = (pixels[i] >> 24) & 0xFF;
                if (alpha == 0)
                {
                    pixels[i] = backgroundArgb;
                }
            }

            // Save the modified pixels back to the image
            png.SaveArgb32Pixels(png.Bounds, pixels);

            // Prepare output options and source
            Source source = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions() { Source = source };

            // Save the image with the specified options
            png.Save(outputPath, options);
        }
    }
}