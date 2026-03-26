using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for the EMF vector image
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            // Set up TIFF save options with CCITT Group 4 compression (black‑and‑white)
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 1 },                     // 1 bit per pixel
                Compression = TiffCompressions.CcittFax4,              // CCITT Group 4
                Photometric = TiffPhotometrics.MinIsBlack,            // 0 = black, 1 = white
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}