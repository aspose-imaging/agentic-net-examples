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
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output_compressed.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TIFF save options with LZW compression (lossless) and a predictor
            var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Lzw,
                Predictor = TiffPredictor.Horizontal
            };

            // Save the image using the configured options
            image.Save(outputPath, saveOptions);
        }
    }
}