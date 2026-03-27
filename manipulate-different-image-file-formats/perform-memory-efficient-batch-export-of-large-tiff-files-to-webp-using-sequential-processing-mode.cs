using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "large.tif");
        string outputDir = "Output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the large TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Set up sequential processing for each page/frame
            tiffImage.PageExportingAction = delegate (int index, Image page)
            {
                // Build output path for the current page
                string outputPath = Path.Combine(outputDir, $"page_{index}.webp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the current page as WebP
                var webpOptions = new WebPOptions(); // default options
                ((RasterImage)page).Save(outputPath, webpOptions);
            };

            // Trigger the page exporting action by saving to a dummy TIFF (the file is not needed)
            string dummyOutput = Path.Combine(outputDir, "dummy.tif");
            Directory.CreateDirectory(Path.GetDirectoryName(dummyOutput));
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffImage.Save(dummyOutput, tiffOptions);
        }
    }
}