using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.bmp";

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

            // Load the TGA image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Preserve the original bits per pixel
                int bitsPerPixel = raster.BitsPerPixel;

                // Create a BMP image with the same bit depth and resolution
                using (BmpImage bmp = new BmpImage(
                    raster,
                    (ushort)bitsPerPixel,
                    BitmapCompression.Rgb,
                    raster.HorizontalResolution,
                    raster.VerticalResolution))
                {
                    // Save as BMP, preserving alpha channel if present
                    bmp.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}