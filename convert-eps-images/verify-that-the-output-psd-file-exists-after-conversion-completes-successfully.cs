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
                    ColorMode = ColorModes.Rgb
                };

                // Save the image as PSD
                image.Save(outputPath, psdOptions);
            }

            // Verify that the PSD file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("PSD file created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create PSD file.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}