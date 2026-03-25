using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TIFF save options for monochrome CCITT Group 4 compression
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                // 1 bit per pixel (monochrome)
                BitsPerSample = new ushort[] { 1 },

                // CCITT Group 4 (Fax4) compression
                Compression = TiffCompressions.CcittFax4,

                // Black is represented by 0 (MinIsBlack)
                Photometric = TiffPhotometrics.MinIsBlack
            };

            // Save the image as a TIFF with the specified options
            image.Save(outputPath, tiffOptions);
        }
    }
}