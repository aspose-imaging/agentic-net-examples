using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Preserve original color depth if possible
                if (image is RasterImage raster)
                {
                    // Clamp to supported PNG bit depths (1,2,4,8,16)
                    int bits = raster.BitsPerPixel;
                    if (bits == 1 || bits == 2 || bits == 4 || bits == 8 || bits == 16)
                    {
                        pngOptions.BitDepth = (byte)bits;
                    }
                    else
                    {
                        // Default to 8 bits per channel for typical truecolor images
                        pngOptions.BitDepth = 8;
                    }

                    // Preserve alpha channel if present
                    if (raster.HasAlpha)
                    {
                        pngOptions.ColorType = PngColorType.TruecolorWithAlpha;
                    }
                }

                // Save as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}