// HOW-TO: Apply Gaussian Blur to CorelDRAW File and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "output\\result.bmp";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW (CDR) file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Render the vector image to a BMP in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save the CDR image as BMP to the memory stream
                    cdrImage.Save(ms, new BmpOptions());

                    // Reset stream position for reading
                    ms.Position = 0;

                    // Load the rendered BMP as a raster image
                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        // Apply Gaussian blur filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the processed image to the final BMP file
                        rasterImage.Save(outputPath);
                    }
                }
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
 * 1. When you need to convert a vector CorelDRAW design into a raster BMP while adding a soft blur for print previews.
 * 2. When generating blurred thumbnails of CDR artwork for web galleries without using external graphics tools.
 * 3. When preprocessing CorelDRAW illustrations with a Gaussian blur before feeding them into a machine‑learning model that expects bitmap input.
 * 4. When automating a batch workflow that renders CDR files to BMP and applies a uniform blur to meet branding guidelines.
 * 5. When creating a blurred background layer from a CorelDRAW logo to overlay on UI components in a C# application.
 */
