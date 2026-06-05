using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for the EMF source
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Configure TIFF options for CCITT Group 4 (Fax4) compression (black‑and‑white)
                var tiffOptions = new TiffOptions(TiffExpectedFormat.TiffCcittFax4)
                {
                    BitsPerSample = new ushort[] { 1 },                     // 1 bit per pixel
                    Compression = TiffCompressions.CcittFax4,              // CCITT Group 4
                    Photometric = TiffPhotometrics.MinIsBlack,             // 0 = black, 1 = white
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}