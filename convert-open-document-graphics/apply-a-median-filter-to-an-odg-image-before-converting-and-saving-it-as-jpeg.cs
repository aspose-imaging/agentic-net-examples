// HOW-TO: Apply Median Filter to ODG and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_filtered.jpg";

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

            // Load the ODG image
            using (Image odgImg = Image.Load(inputPath))
            {
                // Cast to OdgImage to access rasterization options
                OdgImage odgImage = (OdgImage)odgImg;

                // Set up rasterization options to convert vector ODG to raster
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = odgImage.Size
                };

                // Use PNG options as an intermediate raster format
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize ODG to a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    odgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0; // Reset stream position for reading

                    // Load the rasterized image
                    using (Image rasterImg = Image.Load(rasterStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImg;

                        // Apply median filter with size 5 to the whole image
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as JPEG
                        JpegOptions jpegOptions = new JpegOptions();
                        rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce noise in a vector ODG drawing before exporting it as a high‑quality JPEG for web publishing.
 * 2. When an automated batch process must convert multiple ODG files to JPEG while applying a median filter to improve visual clarity.
 * 3. When integrating Aspose.Imaging into a C# application that generates thumbnails of ODG diagrams with noise reduction.
 * 4. When preparing ODG artwork for inclusion in a PDF report and you require a filtered raster JPEG version.
 * 5. When building a server‑side service that receives ODG uploads, applies a median filter, and returns a compressed JPEG for mobile devices.
 */
