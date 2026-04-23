using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\large.tif";
        string outputPath = @"C:\Images\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set memory usage limit (500 MB) when loading the TIFF
            var loadOptions = new LoadOptions
            {
                BufferSizeHint = 500 // MB
            };

            // Load the large TIFF with the memory limit applied
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare TIFF save options with the same memory limit
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BufferSizeHint = 500 // MB
                };

                // Save the image to the output path
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}