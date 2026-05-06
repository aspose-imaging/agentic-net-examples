using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.dng";
            string outputPath = @"C:\Images\output.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Image dngImageBase = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)dngImageBase;
                int width = dngImage.Width;
                int height = dngImage.Height;

                // Create a TIFF canvas with the same dimensions
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // Copy pixel data from DNG to TIFF
                    tiffImage.SavePixels(tiffImage.Bounds, ((RasterImage)dngImage).LoadPixels(dngImage.Bounds));

                    // Adjust contrast by 30 (range -100 to 100)
                    tiffImage.AdjustContrast(30f);

                    // Save the result as TIFF
                    tiffImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}