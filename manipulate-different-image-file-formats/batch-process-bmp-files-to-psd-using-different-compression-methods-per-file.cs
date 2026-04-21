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
            // Define batch items: input BMP, output PSD, desired compression method
            var batch = new (string inputPath, string outputPath, CompressionMethod compression)[]
            {
                (@"C:\Images\sample1.bmp", @"C:\Output\sample1_Raw.psd", CompressionMethod.Raw),
                (@"C:\Images\sample2.bmp", @"C:\Output\sample2_RLE.psd", CompressionMethod.RLE),
                // Add more entries as needed
            };

            foreach (var (inputPath, outputPath, compression) in batch)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PSD save options with the specified compression
                    var psdOptions = new PsdOptions
                    {
                        CompressionMethod = compression,
                        // Optional: set other options such as ColorMode if needed
                        ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                    };

                    // Save as PSD
                    image.Save(outputPath, psdOptions);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}' using {compression} compression.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}