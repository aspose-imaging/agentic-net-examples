using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_filtered.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare rasterization options to convert ODG to raster PNG in memory
                var pngSaveOptions = new PngOptions();
                var odgRasterOptions = new OdgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = odgImage.Size,
                    BackgroundColor = Color.White
                };
                pngSaveOptions.VectorRasterizationOptions = odgRasterOptions;

                // Rasterize ODG to a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    odgImage.Save(memoryStream, pngSaveOptions);
                    memoryStream.Position = 0; // Reset stream position for reading

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        // Cast to RasterImage to access filtering methods
                        var raster = (RasterImage)rasterImage;

                        // Apply median filter with size 5 to the whole image
                        raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as PNG
                        raster.Save(outputPath);
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
 * 1. When a CAD or diagram file in OpenDocument Graphics (ODG) format contains speckle noise and must be displayed on a web page as a clean PNG, a developer can rasterize the ODG and apply a median filter to remove noise before saving.
 * 2. When generating printable assets from ODG drawings for marketing brochures, applying a median filter ensures smooth edges and reduces artifacting before converting to high‑resolution PNG.
 * 3. When an automated document‑processing pipeline extracts ODG charts from LibreOffice files and needs to embed them in a PDF as PNG images, the median filter helps improve visual quality by smoothing out compression artifacts.
 * 4. When a mobile app downloads ODG icons from a server and must cache them as PNG thumbnails, using the median filter removes stray pixels caused by vector‑to‑raster conversion, resulting in sharper thumbnails.
 * 5. When performing batch conversion of legacy ODG diagrams to PNG for archival purposes, applying a median filter programmatically guarantees consistent noise reduction across all converted images.
 */