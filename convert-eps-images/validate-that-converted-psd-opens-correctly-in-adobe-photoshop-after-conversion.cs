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
                    // Use default version (6) and other defaults
                };

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }

            // Validate that the saved PSD can be loaded (basic sanity check)
            using (Image psdImage = Image.Load(outputPath))
            {
                // Simple validation: check dimensions are non-zero
                if (psdImage.Width > 0 && psdImage.Height > 0)
                {
                    Console.WriteLine("PSD conversion succeeded and file is loadable.");
                }
                else
                {
                    Console.Error.WriteLine("Loaded PSD has invalid dimensions.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}