using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.tif";

        // Verify that the source EMF file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization of the vector EMF to a bitmap surface
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,               // Preserve original size
                BackgroundColor = Color.White        // White background for B/W output
            };

            // Set up TIFF save options for CCITT Group 4 (Fax 4) compression
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 1 },                     // 1 bit per pixel (B/W)
                Compression = TiffCompressions.CcittFax4,              // CCITT Group 4 compression
                Photometric = TiffPhotometrics.MinIsBlack,             // 0 = black, 1 = white
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}