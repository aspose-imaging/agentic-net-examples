using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.eps";
        string outputPath = @"C:\Temp\sample_converted.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PSD save options
            var psdOptions = new PsdOptions
            {
                // Example: use RLE compression and RGB color mode
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                // Preserve layers by exporting each page as a separate layer (if multipage)
                MultiPageOptions = null
            };

            // If the EPS contains multiple pages, export them as layers
            if (image is IMultipageImage multipage && multipage.PageCount > 1)
            {
                // Export all pages; each page becomes a layer in the PSD
                psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount));
            }

            // Save as PSD preserving layers
            image.Save(outputPath, psdOptions);
        }
    }
}