using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
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

            // Load the source JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with 300 DPI resolution
                JpegOptions saveOptions = new JpegOptions
                {
                    // Set horizontal and vertical DPI to 300
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    ResolutionUnit = ResolutionUnit.Inch,
                    // Optional: set quality to maximum
                    Quality = 100
                };

                // Save the image with the specified DPI
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}