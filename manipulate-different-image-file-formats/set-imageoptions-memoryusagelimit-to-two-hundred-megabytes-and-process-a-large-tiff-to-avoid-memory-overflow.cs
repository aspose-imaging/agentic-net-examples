using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\large_input.tif";
        string outputPath = @"C:\Images\large_output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the large TIFF with a memory limit of 200 MB
        var loadOptions = new LoadOptions
        {
            BufferSizeHint = 200 // memory limit in megabytes
        };

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Example processing: no operation, just re-save
            // (Insert any image manipulation here if needed)

            // Prepare save options with the same memory limit
            var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BufferSizeHint = 200 // memory limit in megabytes
            };

            // Save the processed image
            image.Save(outputPath, saveOptions);
        }
    }
}