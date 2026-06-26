using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.otg";
            string outputPath = @"C:\temp\sample.filtered.jpg";

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
                // Prepare PNG options with OTG rasterization settings
                var pngOptions = new PngOptions();
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // preserve original size
                };
                pngOptions.VectorRasterizationOptions = otgRasterOptions;

                // Rasterize OTG to a memory stream (PNG)
                using (var rasterStream = new MemoryStream())
                {
                    otgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0; // reset for reading

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(rasterStream))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Apply median filter with size 5 to the whole image
                        raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as JPEG
                        var jpegOptions = new JpegOptions();
                        raster.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to clean up noise in a vector‑based OTG diagram before delivering it as a compressed JPEG for web publishing.
 * 2. When an application must convert proprietary OTG artwork to a raster format, apply a median filter to smooth edges, and store the result as a JPEG thumbnail.
 * 3. When a batch‑processing service processes CAD‑style OTG files, removes speckle artifacts with a size‑5 median filter, and saves the output for email attachment in JPEG.
 * 4. When a mobile‑first workflow requires rasterizing an OTG logo, denoising it with a median filter, and exporting a JPEG that meets size constraints.
 * 5. When a document‑generation tool needs to embed a filtered, rasterized version of an OTG image into a PDF by first saving it as a JPEG after noise reduction.
 */