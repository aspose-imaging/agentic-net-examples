using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.psd";
        string outputPath = @"C:\Images\sample_converted.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options with text rendering hint
            PngOptions pngOptions = new PngOptions
            {
                // Vector rasterization options are required to set the text rendering hint
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                }
            };

            // Save the image as PNG using the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}