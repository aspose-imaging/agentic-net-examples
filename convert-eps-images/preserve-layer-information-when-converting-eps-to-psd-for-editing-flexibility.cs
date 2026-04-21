using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.eps";
        string outputPath = @"C:\temp\result.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PSD save options to preserve layers (pages become layers)
            PsdOptions psdOptions = new PsdOptions
            {
                // Preserve original metadata if needed
                KeepMetadata = true,

                // If the EPS contains multiple pages, export them as separate layers
                MultiPageOptions = null // will be set below if applicable
            };

            // If the loaded image supports multipage (e.g., vector EPS with multiple pages),
            // export the first two pages as layers (example). Adjust as needed.
            if (image is IMultipageImage multipage && multipage.PageCount > 1)
            {
                // Export all pages as layers
                psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount));
            }

            // Save as PSD preserving layers
            image.Save(outputPath, psdOptions);
        }
    }
}