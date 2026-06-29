using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample_converted.png";

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
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare PNG save options with OTG rasterization settings
                var pngOptions = new PngOptions();
                var otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // preserve original size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Save the rasterized PNG
                otgImage.Save(outputPath, pngOptions);
            }

            // Load the generated PNG to apply gamma correction
            using (Image pngImage = Image.Load(outputPath))
            {
                // Adjust gamma on the raster image
                if (pngImage is RasterImage raster)
                {
                    raster.AdjustGamma(2.2f); // example gamma value
                }

                // Overwrite the PNG with gamma‑corrected data
                pngImage.Save(outputPath, new PngOptions());
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
 * 1. When a .NET application must display OpenDocument graphics (OTG) in a web browser, a developer can use this code to convert the OTG file to a PNG image and apply gamma correction for accurate brightness.
 * 2. When generating printable assets from OpenDocument vector drawings, the code enables conversion of OTG to PNG with preserved page size and gamma‑adjusted colors to match the intended print output.
 * 3. When integrating legacy OTG diagrams into a modern C# reporting system, the snippet rasterizes the vector image to PNG and corrects gamma so the diagram appears consistent across different monitors.
 * 4. When automating batch processing of OTG assets for a mobile app, developers can employ this code to produce PNG thumbnails with proper gamma handling to ensure visual fidelity on low‑power devices.
 * 5. When building an image‑processing pipeline that ingests OpenDocument graphics and stores them in a PNG format for archival, the example shows how to load, rasterize, and gamma‑correct the image using Aspose.Imaging for .NET.
 */