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
                    // Example settings – can be adjusted as needed
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Grayscale
                };

                // Save the image as PSD
                image.Save(outputPath, psdOptions);
            }

            // Verify that the output PSD file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("Conversion succeeded, output file exists.");
            }
            else
            {
                Console.Error.WriteLine("Output file not found after conversion.");
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors without throwing
            Console.Error.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}