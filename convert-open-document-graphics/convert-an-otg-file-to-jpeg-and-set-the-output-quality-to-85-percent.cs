using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with quality 85
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85
                };

                // Set up rasterization options for vector to raster conversion
                OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRaster;

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate web‑ready preview images from OTG vector graphics for an e‑commerce product catalog.
 * 2. When an automated reporting system must embed high‑quality JPEG thumbnails of OTG diagrams into PDF reports.
 * 3. When a mobile app backend converts user‑uploaded OTG files to compressed JPEGs for faster download and storage.
 * 4. When a content management workflow requires batch conversion of OTG assets to JPEG with a specific 85 % quality setting for archival.
 * 5. When a digital signage solution rasterizes OTG artwork into JPEGs to match the display hardware’s supported image format.
 */