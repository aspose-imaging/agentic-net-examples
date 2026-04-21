using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\large_input.tif";
            string outputPath = @"C:\Images\processed_output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set memory usage limit to 500 MB via LoadOptions
            var loadOptions = new LoadOptions { BufferSizeHint = 500 };

            // Load the TIFF image with the memory limit applied
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // (Optional) image processing can be performed here

                // Prepare save options with the same memory limit
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BufferSizeHint = 500
                };

                // Save the processed image
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}