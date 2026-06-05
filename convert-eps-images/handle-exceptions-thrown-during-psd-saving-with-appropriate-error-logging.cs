using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.psd";

        // Validate input file existence
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
                // Configure PSD saving options
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale
                };

                // Save the image as PSD with the specified options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Log any errors that occur during processing or saving
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}