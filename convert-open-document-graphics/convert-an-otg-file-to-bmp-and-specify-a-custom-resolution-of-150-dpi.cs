// HOW-TO: Convert OTG to BMP with 150 DPI Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample_converted.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load OTG image and save as BMP using rasterization options
            using (Image otgImage = Image.Load(inputPath))
            {
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = otgImage.Size
                };

                var bmpSaveOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                otgImage.Save(outputPath, bmpSaveOptions);
            }

            // Reload the saved BMP to set custom resolution (150 DPI)
            using (Image bmpImage = Image.Load(outputPath))
            {
                var bmp = (BmpImage)bmpImage;
                bmp.SetResolution(150.0, 150.0);
                bmp.Save(outputPath);
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
 * 1. When you need to display vector OTG graphics in a Windows application that only supports BMP files, you can rasterize and convert them using C#.
 * 2. When preparing print‑ready assets, you may need to set a specific DPI (e.g., 150) on a BMP generated from an OTG source.
 * 3. When integrating legacy systems that require BMP images with a known resolution, this code converts and adjusts the image size automatically.
 * 4. When automating batch processing of engineering diagrams stored as OTG files, you can convert them to BMP and enforce a uniform DPI for downstream tools.
 * 5. When creating thumbnails or previews for OTG drawings in a web portal, converting to BMP with a set DPI ensures consistent scaling across browsers.
 */
