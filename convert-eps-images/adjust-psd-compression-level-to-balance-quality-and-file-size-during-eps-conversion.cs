using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD saving options with balanced compression (RLE)
            PsdOptions psdOptions = new PsdOptions
            {
                // RLE provides a good trade‑off between quality and file size
                CompressionMethod = CompressionMethod.RLE,

                // Optional: set common PSD parameters
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                ChannelBitsCount = 8,
                ChannelsCount = 4,
                Version = 6
            };

            // Save the image as PSD using the configured options
            image.Save(outputPath, psdOptions);
        }
    }
}