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
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create PSD save options
                PsdOptions psdOptions = new PsdOptions();

                // Set high resolution (e.g., 300 DPI) before saving
                psdOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0);

                // Optional: set additional PSD options
                psdOptions.CompressionMethod = CompressionMethod.RLE;
                psdOptions.ColorMode = ColorModes.Rgb;

                // Save the image as PSD with the configured options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}