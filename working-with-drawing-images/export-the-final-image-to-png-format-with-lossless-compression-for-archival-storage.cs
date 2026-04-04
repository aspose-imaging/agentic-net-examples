using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if missing)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG options for lossless archival storage
            PngOptions pngOptions = new PngOptions
            {
                // Use the default (lossless) compression level
                PngCompressionLevel = PngOptions.DefaultCompressionLevel,
                // Preserve original metadata
                KeepMetadata = true
            };

            // Save the image as PNG with the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}