using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Define the target color to isolate (pure red)
            int targetR = 255;
            int targetG = 0;
            int targetB = 0;

            // Get all pixels in ARGB format
            var bounds = new Rectangle(0, 0, image.Width, image.Height);
            int[] pixels = image.GetDefaultArgb32Pixels(bounds);

            // Process each pixel: keep if it matches the target color, otherwise make it transparent
            for (int i = 0; i < pixels.Length; i++)
            {
                int argb = pixels[i];
                int a = (argb >> 24) & 0xFF;
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;

                if (r == targetR && g == targetG && b == targetB)
                {
                    // Preserve original pixel (including alpha)
                    pixels[i] = argb;
                }
                else
                {
                    // Make pixel fully transparent
                    pixels[i] = 0;
                }
            }

            // Write the modified pixels back to the image
            image.SaveArgb32Pixels(bounds, pixels);

            // Save the result as PNG with alpha channel
            var saveOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputPath, false)
            };
            image.Save(outputPath, saveOptions);
        }
    }
}