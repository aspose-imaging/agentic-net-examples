using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dng";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DNG image
        using (Aspose.Imaging.FileFormats.Dng.DngImage dng = (Aspose.Imaging.FileFormats.Dng.DngImage)Image.Load(inputPath))
        {
            int width = dng.Width;
            int height = dng.Height;

            // Create a TIFF canvas with the same dimensions
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Load ARGB32 pixels from DNG
                int[] pixels = ((RasterImage)dng).LoadArgb32Pixels(new Rectangle(0, 0, width, height));

                // Write pixels to TIFF canvas
                tiff.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                // Adjust contrast by 30 (range -100 to 100)
                tiff.AdjustContrast(30f);

                // Save the result as TIFF
                tiff.Save(outputPath);
            }
        }
    }
}