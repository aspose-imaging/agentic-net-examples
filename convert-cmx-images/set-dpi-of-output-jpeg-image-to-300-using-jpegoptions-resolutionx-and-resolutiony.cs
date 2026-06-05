using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.jpg";
        string outputPath = @"C:\Temp\output_300dpi.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure JPEG save options with 300 DPI resolution
            JpegOptions saveOptions = new JpegOptions
            {
                // Set horizontal and vertical resolution to 300 dots per inch
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                ResolutionUnit = ResolutionUnit.Inch,
                // Optional: set quality to maximum
                Quality = 100
            };

            // Load the source image and save it with the specified options
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}