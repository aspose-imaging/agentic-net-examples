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
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        // Verify that the EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image
        using (var image = Image.Load(inputPath) as EpsImage)
        {
            if (image == null)
            {
                Console.Error.WriteLine("Failed to load EPS image.");
                return;
            }

            // Set up PSD saving options (optional: configure compression, color mode, etc.)
            var psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE, // Example compression
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                ChannelBitsCount = 8,
                ChannelsCount = 4
            };

            // Save the image as PSD
            image.Save(outputPath, psdOptions);
        }

        // Compare file sizes
        long epsSize = new FileInfo(inputPath).Length;
        long psdSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"EPS size: {epsSize} bytes");
        Console.WriteLine($"PSD size: {psdSize} bytes");
    }
}