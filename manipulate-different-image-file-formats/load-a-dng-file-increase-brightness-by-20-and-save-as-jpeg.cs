using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dng";
        string outputPath = "output/output.jpg";

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
            // Cast to RasterImage to adjust brightness
            RasterImage raster = (RasterImage)image;

            // Increase brightness by approximately 20% (51 out of 255)
            raster.AdjustBrightness(51);

            // Prepare JPEG save options
            JpegOptions jpegOptions = new JpegOptions();

            // Save the adjusted image as JPEG
            raster.Save(outputPath, jpegOptions);
        }
    }
}