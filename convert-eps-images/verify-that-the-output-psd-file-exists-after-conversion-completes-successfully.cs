using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
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

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Example settings (optional)
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

                // Save the image as PSD
                image.Save(outputPath, psdOptions);
            }

            // Verify that the PSD file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"Conversion successful. PSD file created at: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine("Conversion failed: PSD file was not created.");
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors without throwing
            Console.Error.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}