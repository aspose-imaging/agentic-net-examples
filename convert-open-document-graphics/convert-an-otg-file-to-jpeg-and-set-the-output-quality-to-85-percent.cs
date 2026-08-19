// HOW-TO: Convert OTG Vector Image To JPEG With 85% Quality In C# (Aspose.Imaging for .NET)
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
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\Result\sample.jpg";

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
                // Prepare JPEG save options with quality set to 85%
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85
                };

                // Configure rasterization options for vector OTG content
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = image.Size
                };

                // Attach rasterization options to the JPEG options
                jpegOptions.VectorRasterizationOptions = otgRasterization;

                // Save the image as JPEG using the configured options
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
 * 1. When a developer needs to generate a JPEG preview of an OTG diagram for web display while controlling file size with 85% quality.
 * 2. When an application must batch‑convert OpenDocument graphics (OTG) to JPEG for inclusion in email attachments or reports.
 * 3. When a document management system stores vector OTG files but requires raster JPEG thumbnails for quick browsing.
 * 4. When a mobile app downloads OTG assets and needs to rasterize them to JPEG at a specific quality to balance clarity and bandwidth.
 * 5. When a legacy system only supports JPEG images and you must programmatically transform OTG files, preserving original dimensions and setting a defined compression level.
 */
