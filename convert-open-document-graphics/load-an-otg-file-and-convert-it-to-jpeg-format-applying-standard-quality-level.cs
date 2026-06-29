using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with default quality
                JpegOptions jpegOptions = new JpegOptions();

                // Configure vector rasterization for OTG files
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRasterization;

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
 * 1. When a developer needs to generate a JPEG preview of an OpenDocument graphic (OTG) for web display or email attachment.
 * 2. When an application must batch‑convert user‑uploaded OTG diagrams to JPEG to store them in a database that only supports raster image file formats.
 * 3. When a reporting tool has to embed vector‑based OTG charts into PDF reports that require JPEG raster images for compatibility using C# and Aspose.Imaging.
 * 4. When a mobile app needs to display OTG icons on devices that only support JPEG decoding, requiring on‑the‑fly conversion with default quality settings.
 * 5. When a document management system must create thumbnail images of OTG files using Aspose.Imaging’s vector rasterization options and save them as JPEG for quick browsing.
 */