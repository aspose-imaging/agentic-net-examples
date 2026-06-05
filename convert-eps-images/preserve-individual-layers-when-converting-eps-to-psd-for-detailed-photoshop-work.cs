using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.eps";
        string outputPath = @"C:\temp\sample.psd";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options (default settings preserve layers)
                var psdOptions = new PsdOptions
                {
                    // Example optional settings:
                    // CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    // ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                    // Version = 6
                };

                // Save the image as PSD, preserving layers
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}