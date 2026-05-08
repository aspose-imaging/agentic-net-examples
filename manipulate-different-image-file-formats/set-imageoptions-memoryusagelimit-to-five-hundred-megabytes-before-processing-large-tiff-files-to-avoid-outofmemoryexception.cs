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
        string inputPath = @"C:\Images\large_input.tif";
        string outputPath = @"C:\Images\processed_output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image with a memory usage limit of 500 MB
            var loadOptions = new LoadOptions
            {
                BufferSizeHint = 500 // limit internal buffers to 500 MB
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare save options with the same memory limit
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BufferSizeHint = 500 // limit internal buffers during save
                };

                // Save the image to the output path
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}