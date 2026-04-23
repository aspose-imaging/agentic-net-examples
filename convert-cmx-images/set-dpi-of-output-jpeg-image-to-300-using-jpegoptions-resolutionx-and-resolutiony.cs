using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_300dpi.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare JPEG save options with 300 DPI resolution
            JpegOptions saveOptions = new JpegOptions
            {
                // Set horizontal and vertical resolution to 300 DPI
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                // Define the resolution unit as inches
                ResolutionUnit = ResolutionUnit.Inch,
                // Optional: keep default quality (100) and other settings
                Quality = 100
            };

            // Save the image with the specified DPI
            image.Save(outputPath, saveOptions);
        }
    }
}