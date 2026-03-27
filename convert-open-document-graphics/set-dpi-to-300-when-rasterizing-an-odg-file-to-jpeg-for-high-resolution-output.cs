using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options with 300 DPI resolution
            JpegOptions jpegOptions = new JpegOptions
            {
                // Set DPI for the rasterized image
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),

                // Enable vector rasterization using ODG rasterization options
                VectorRasterizationOptions = new OdgRasterizationOptions
                {
                    // Use the source image size as the page size
                    PageSize = image.Size,
                    // Optional: set background color if needed
                    BackgroundColor = Color.White
                }
            };

            // Save the rasterized JPEG image
            image.Save(outputPath, jpegOptions);
        }
    }
}