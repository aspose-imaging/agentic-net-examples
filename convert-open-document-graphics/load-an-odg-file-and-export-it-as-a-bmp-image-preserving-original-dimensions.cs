using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to the specific OdgImage type
            OdgImage odgImage = (OdgImage)image;

            // Prepare BMP save options with rasterization settings that preserve original size
            var bmpOptions = new BmpOptions
            {
                // Optional: set bits per pixel (24‑bpp is a common choice)
                BitsPerPixel = 24,
                // Configure vector rasterization to match the source dimensions
                VectorRasterizationOptions = new OdgRasterizationOptions
                {
                    // Preserve original dimensions
                    PageSize = odgImage.Size,
                    // Set a background color if needed (white in this case)
                    BackgroundColor = Color.White
                }
            };

            // Save the image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}