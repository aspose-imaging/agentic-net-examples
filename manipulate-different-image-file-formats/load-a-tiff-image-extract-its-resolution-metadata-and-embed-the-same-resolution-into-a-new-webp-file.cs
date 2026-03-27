using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/sample.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image tiffImageBase = Image.Load(inputPath))
        {
            // Cast to TiffImage to access resolution properties
            TiffImage tiffImage = (TiffImage)tiffImageBase;
            double dpiX = tiffImage.HorizontalResolution;
            double dpiY = tiffImage.VerticalResolution;

            // Create a WebP image from the loaded TIFF raster data
            using (WebPImage webpImage = new WebPImage((RasterImage)tiffImage))
            {
                // Embed the same resolution metadata
                webpImage.SetResolution(dpiX, dpiY);

                // Save the WebP image
                webpImage.Save(outputPath);
            }
        }
    }
}