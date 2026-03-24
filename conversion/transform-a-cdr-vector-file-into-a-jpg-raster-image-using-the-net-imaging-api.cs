using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR vector image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare JPEG save options with rasterization settings for CDR
            var jpegOptions = new JpegOptions
            {
                // Set background color if needed (optional)
                // BackgroundColor = Color.White,

                // Configure vector rasterization specific to CDR
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    // Example: keep original size, no scaling
                    ScaleX = 1.0f,
                    ScaleY = 1.0f,
                    // Optional: set background color for rasterization
                    BackgroundColor = Color.White,
                    // Optional: improve rendering quality
                    SmoothingMode = SmoothingMode.None,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    Positioning = PositioningTypes.DefinedByDocument
                }
            };

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}