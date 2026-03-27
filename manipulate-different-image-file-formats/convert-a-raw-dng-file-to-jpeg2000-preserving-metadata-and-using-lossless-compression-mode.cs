using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.dng";
        string outputPath = @"C:\temp\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DngImage to access raw data if needed
            DngImage dngImage = (DngImage)image;

            // Configure JPEG2000 options for lossless compression and metadata preservation
            Jpeg2000Options jpeg2000Options = new Jpeg2000Options
            {
                // Irreversible = false means lossless DWT 5-3 (default), set explicitly for clarity
                Irreversible = false,
                // Preserve original metadata
                KeepMetadata = true
            };

            // Save as JPEG2000
            dngImage.Save(outputPath, jpeg2000Options);
        }
    }
}