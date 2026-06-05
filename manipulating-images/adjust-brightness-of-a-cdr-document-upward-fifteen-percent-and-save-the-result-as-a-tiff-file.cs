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
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample_adjusted.tif";

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
                // Adjust brightness upward by ~15% of the maximum value (255 * 0.15 ≈ 38)
                const int brightnessIncrease = 38;

                // Apply brightness adjustment depending on the actual image type
                if (image is RasterImage raster)
                {
                    raster.AdjustBrightness(brightnessIncrease);
                }
                else if (image is TiffImage tiffImg)
                {
                    tiffImg.AdjustBrightness(brightnessIncrease);
                }
                else
                {
                    // Fallback: try generic AdjustBrightness if available via reflection (not required here)
                }

                // Save the result as a TIFF file
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}