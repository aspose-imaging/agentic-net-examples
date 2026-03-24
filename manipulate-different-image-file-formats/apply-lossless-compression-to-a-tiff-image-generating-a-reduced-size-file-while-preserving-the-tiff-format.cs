using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.tif";
        string outputPath = @"C:\Temp\output_compressed.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure lossless LZW compression for the output TIFF
            var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Lzw,
                // Optional: predictor can improve LZW size for continuous-tone images
                Predictor = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPredictor.Horizontal
            };

            // Save the image with the specified options
            image.Save(outputPath, saveOptions);
        }
    }
}