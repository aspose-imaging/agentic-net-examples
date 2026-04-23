using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Cast to TiffImage to access resolution properties
                TiffImage tiff = (TiffImage)tiffImage;
                double dpiX = tiff.HorizontalResolution;
                double dpiY = tiff.VerticalResolution;

                // Apply the same resolution to the image before saving
                tiff.SetResolution(dpiX, dpiY);

                // Prepare WebP save options (default settings)
                WebPOptions webpOptions = new WebPOptions();

                // Save as WebP with the same resolution metadata
                tiff.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}