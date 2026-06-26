using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.otg";
        string outputPath = @"C:\temp\output.jpg";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG vector content
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size
                };

                // Configure JPEG save options, including compression quality (1-100)
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80, // Example compression level
                    VectorRasterizationOptions = otgRasterizationOptions
                };

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
 * 1. When a .NET application must convert proprietary OTG vector drawings into web‑friendly JPEG thumbnails while controlling file size with a specific compression quality.
 * 2. When an automated reporting tool needs to render multi‑page OTG diagrams as high‑resolution raster images and store each page as a JPEG for inclusion in PDF reports.
 * 3. When a batch processing service processes a folder of OTG files and saves them as JPEGs with a consistent quality setting to meet archival storage guidelines.
 * 4. When a desktop utility allows users to preview OTG graphics and export the preview as a JPEG image with adjustable compression for faster sharing via email.
 * 5. When a cloud‑based image conversion API receives OTG uploads and must rasterize the vector content using Aspose.Imaging’s OtgRasterizationOptions before delivering a JPEG response with a predefined quality level.
 */