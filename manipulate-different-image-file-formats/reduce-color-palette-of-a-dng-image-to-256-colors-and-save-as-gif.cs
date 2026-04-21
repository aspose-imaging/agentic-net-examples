using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths (relative)
        string inputPath = "Input\\sample.dng";
        string outputPath = "Output\\sample.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DNG image
        using (DngImage dng = (DngImage)Image.Load(inputPath))
        {
            // Cast to RasterImage to apply dithering (8-bit = 256 colors)
            RasterImage raster = dng;
            raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

            // Prepare GIF save options
            using (GifOptions gifOptions = new GifOptions())
            {
                // Optional: improve palette selection
                gifOptions.DoPaletteCorrection = true;

                // Save as GIF with reduced palette
                dng.Save(outputPath, gifOptions);
            }
        }
    }
}