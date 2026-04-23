using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.emf";
        string outputPath = "output.tif";

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
            // Configure TIFF options for CCITT Group 4 compression (black‑and‑white)
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 1 }; // 1‑bit per pixel
            tiffOptions.Compression = TiffCompressions.CcittFax4; // CCITT Group 4
            tiffOptions.Photometric = TiffPhotometrics.MinIsBlack; // 0 = black, 1 = white

            // Save the image as TIFF with the specified options
            image.Save(outputPath, tiffOptions);
        }
    }
}