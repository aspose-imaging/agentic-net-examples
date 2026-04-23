using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.dng";
            string outputPath = @"C:\Images\Result\sample.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage (DngImage derives from RasterImage)
                RasterImage raster = (RasterImage)image;

                // Reduce the palette to 256 colors using Floyd‑Steinberg dithering (8‑bit palette)
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Save the result as GIF
                GifOptions gifOptions = new GifOptions(); // default options are sufficient
                raster.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}