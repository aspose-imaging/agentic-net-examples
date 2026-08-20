// HOW-TO: Apply Median Filter to OTG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
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
                // Rasterize OTG to a temporary PNG file
                string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_otg.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = otgImage.Size
                    }
                };
                otgImage.Save(tempPngPath, pngOptions);

                // Load the rasterized PNG, apply median filter, and save as JPEG
                using (Image rasterImage = Image.Load(tempPngPath))
                {
                    var raster = (RasterImage)rasterImage;
                    // Apply median filter with size 5 to the whole image
                    raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                    var jpegOptions = new JpegOptions();
                    raster.Save(outputPath, jpegOptions);
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    try { File.Delete(tempPngPath); } catch { /* ignore cleanup errors */ }
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
 * 1. When you need to remove noise from a vector OTG drawing before exporting it as a compressed JPEG for web publishing.
 * 2. When you must convert a multi‑page OTG file to a raster format, apply a median filter, and generate a single JPEG thumbnail for preview.
 * 3. When an application processes user‑uploaded OTG graphics and requires a filtered JPEG output to improve visual quality on mobile devices.
 * 4. When automating a batch job that rasterizes OTG files, applies a 5‑pixel median filter, and stores the results as JPEGs for archival.
 * 5. When integrating Aspose.Imaging in a C# service to clean up OTG images with median filtering before saving them in JPEG format for downstream image‑analysis pipelines.
 */
