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
        string outputPath = @"C:\Images\output\large_processed.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set memory usage limit to 500 MB via LoadOptions
        var loadOptions = new LoadOptions
        {
            BufferSizeHint = 500 // limit internal buffers to 500 MB
        };

        // Load the TIFF image with the memory limit applied
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Prepare save options for TIFF and apply the same memory limit
            var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BufferSizeHint = 500 // limit internal buffers during saving
            };

            // Save the processed image
            image.Save(outputPath, saveOptions);
        }
    }
}