using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // If the loaded image is a TIFF image, use its Dither method
                if (image is TiffImage tiffImage)
                {
                    tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);
                    tiffImage.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                }
                // Otherwise, treat it as a raster image and apply dithering
                else if (image is RasterImage rasterImage)
                {
                    rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                    rasterImage.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image format for dithering.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}