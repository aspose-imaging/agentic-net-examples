using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR vector image
        using (Aspose.Imaging.FileFormats.Cdr.CdrImage cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath))
        {
            // Configure PNG save options with lossless (max) compression
            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.CompressionLevel = 9; // maximum lossless compression
                pngOptions.Progressive = false;

                // Set vector rasterization options to preserve original dimensions
                pngOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = cdrImage.Width,
                    PageHeight = cdrImage.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Save the rasterized PNG image
                cdrImage.Save(outputPath, pngOptions);
            }
        }
    }
}