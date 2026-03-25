using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Prepare TIFF options (default format, RGB, 8 bits per sample)
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;

            // Create the first TIFF frame from the first APNG frame
            RasterImage firstRaster = (RasterImage)apng.Pages[0];
            TiffFrame firstFrame = new TiffFrame(firstRaster);

            // Initialize the multi-page TIFF image with the first frame
            using (TiffImage tiffImage = new TiffImage(firstFrame))
            {
                // Add remaining APNG frames as additional TIFF pages
                for (int i = 1; i < apng.PageCount; i++)
                {
                    RasterImage raster = (RasterImage)apng.Pages[i];
                    TiffFrame frame = new TiffFrame(raster);
                    tiffImage.AddFrame(frame);
                }

                // Save the resulting multi-page TIFF
                tiffImage.Save(outputPath);
            }
        }
    }
}