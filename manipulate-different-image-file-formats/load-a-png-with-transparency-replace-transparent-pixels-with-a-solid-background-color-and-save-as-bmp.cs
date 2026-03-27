using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
            outputDir = ".";
        Directory.CreateDirectory(outputDir);

        // Load PNG image as RasterImage
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Load all ARGB pixels
            int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

            // Define solid background color (white)
            int backgroundArgb = Color.FromArgb(255, 255, 255, 255).ToArgb();

            // Replace fully transparent pixels with background color
            for (int i = 0; i < pixels.Length; i++)
            {
                int alpha = (pixels[i] >> 24) & 0xFF;
                if (alpha == 0)
                {
                    pixels[i] = backgroundArgb;
                }
            }

            // Write modified pixels back to the image
            raster.SaveArgb32Pixels(raster.Bounds, pixels);

            // Prepare BMP save options with file source
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the image as BMP
            raster.Save(outputPath, bmpOptions);
        }
    }
}