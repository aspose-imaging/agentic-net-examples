using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb,
                    // Optional: set other properties as needed
                };

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }

            // Attempt to load the saved PSD to verify it is not corrupted
            using (Image savedPsd = Image.Load(outputPath))
            {
                // If loading succeeds, consider the conversion successful
                Console.WriteLine("PSD conversion succeeded and file is loadable.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}