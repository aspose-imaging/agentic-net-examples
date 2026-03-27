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
        string inputPath = @"C:\Temp\sample.eps";
        string outputPath = @"C:\Temp\sample_converted.psd";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PSD save options
            var psdOptions = new PsdOptions
            {
                // Example: use RAW (no compression) and RGB color mode
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                // Preserve layers if the source supports multipage (each page becomes a layer)
                MultiPageOptions = null
            };

            // If the source image is a multipage vector image, export pages as layers
            if (image is IMultipageImage multipage && multipage.PageCount > 1)
            {
                // Export all pages as separate layers
                psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount));
            }

            // Save the image as PSD, preserving layers
            image.Save(outputPath, psdOptions);
        }
    }
}