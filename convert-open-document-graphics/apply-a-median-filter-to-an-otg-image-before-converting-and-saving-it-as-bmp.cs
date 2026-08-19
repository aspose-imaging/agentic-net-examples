// HOW-TO: Apply Median Filter to OTG Image and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample_filtered.bmp";

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

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare BMP save options with OTG rasterization settings
                BmpOptions bmpOptions = new BmpOptions();
                OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // Preserve original size
                };
                bmpOptions.VectorRasterizationOptions = otgRaster;

                // Rasterize OTG to a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    otgImage.Save(rasterStream, bmpOptions);
                    rasterStream.Position = 0; // Reset stream position for reading

                    // Load the rasterized BMP as a RasterImage
                    using (Image rasterImageWrapper = Image.Load(rasterStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageWrapper;

                        // Apply median filter with size 5 to the whole image
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as BMP
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
 * 1. When you need to clean up noise in a vector OTG file before converting it to a BMP for legacy Windows applications.
 * 2. When you want to preprocess scanned engineering drawings in OTG format with a median filter to improve edge clarity before rasterizing them to bitmap images.
 * 3. When an automated batch job must convert OTG graphics to BMP while applying a 5‑pixel median filter to ensure consistent visual quality across all output files.
 * 4. When integrating Aspose.Imaging in a C# service that receives OTG uploads and must deliver noise‑reduced BMP thumbnails for web preview.
 * 5. When preparing OTG artwork for printing on devices that only accept BMP, and you need to remove speckles using a median filter during the conversion process.
 */
