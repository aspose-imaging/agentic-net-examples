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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\output.psd";

            // Verify that the EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Set up PSD options for 16‑bit per channel depth
                PsdOptions psdOptions = new PsdOptions
                {
                    ChannelBitsCount = 16,                         // 16 bits per channel
                    ChannelsCount = 4,                             // RGBA
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
                    Version = 6                                    // Default PSD version
                };

                // Save the image as PSD using the configured options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}