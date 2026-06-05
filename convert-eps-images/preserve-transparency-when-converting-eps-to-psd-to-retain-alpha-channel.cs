using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.eps";
        string outputPath = "output.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD saving options preserving transparency
                var psdOptions = new PsdOptions
                {
                    // 8 bits per channel
                    ChannelBitsCount = 8,
                    // 4 channels: R, G, B, Alpha
                    ChannelsCount = 4,
                    // Use RGB color mode (supports alpha)
                    ColorMode = ColorModes.Rgb,
                    // No compression (or use CompressionMethod.RLE if desired)
                    CompressionMethod = CompressionMethod.Raw
                };

                // If the source is a vector image, set rasterization options
                if (image is VectorImage vectorImage)
                {
                    var rasterOptions = new VectorRasterizationOptions
                    {
                        // Use original dimensions
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height,
                        // Preserve transparent background
                        BackgroundColor = Color.Transparent
                    };
                    psdOptions.VectorRasterizationOptions = rasterOptions;
                }

                // Save as PSD with the configured options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}