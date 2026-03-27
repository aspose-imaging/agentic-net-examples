using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputDirectory = @"C:\temp\output_webp";
        string dummyOutputPath = @"C:\temp\dummy_output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(outputDirectory);
        Directory.CreateDirectory(Path.GetDirectoryName(dummyOutputPath));

        // Load the multi‑page TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Set batch processing action for each page
            tiffImage.PageExportingAction = (int index, Image page) =>
            {
                // Build output file name for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{index + 1}.webp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the current page as WebP
                page.Save(outputPath, new WebPOptions());

                // Resources for this page will be released automatically after this delegate returns
            };

            // Trigger the batch export by saving to a dummy file
            tiffImage.Save(dummyOutputPath);
        }
    }
}