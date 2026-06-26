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
        string inputPath = @"C:\Images\input.otg";
        string outputPath = @"C:\Images\output.bmp";

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
                // Prepare BMP save options with rasterization settings for OTG
                BmpOptions bmpOptions = new BmpOptions();
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // preserve original size
                };
                bmpOptions.VectorRasterizationOptions = otgRasterization;

                // Save the OTG image to a memory stream as a raster BMP
                using (MemoryStream ms = new MemoryStream())
                {
                    otgImage.Save(ms, bmpOptions);
                    ms.Position = 0; // reset stream position for reading

                    // Load the rasterized BMP from the memory stream
                    using (Image rasterImage = Image.Load(ms))
                    {
                        // Cast to RasterImage to access filtering methods
                        RasterImage raster = (RasterImage)rasterImage;

                        // Apply median filter with size 5 to the whole image
                        raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image to the final BMP file
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
 * 1. When a CAD application needs to convert an OTG vector drawing to a BMP thumbnail while removing speckle noise, this code can rasterize the OTG file, apply a median filter, and save a clean bitmap.
 * 2. When a document management system imports OTG schematics and must store them as BMP for legacy viewers, the median filter smooths isolated pixel artifacts before saving.
 * 3. When a medical imaging workflow receives OTG annotations and wants to embed them in a BMP report, the code rasterizes the vector layer and uses a median filter to reduce scanning noise.
 * 4. When a GIS tool exports OTG map overlays to BMP for use in raster‑based analysis, applying a median filter ensures the resulting bitmap has fewer outlier pixels that could affect analysis.
 * 5. When an e‑learning platform converts OTG technical diagrams to BMP for web delivery and needs to improve visual quality by eliminating salt‑and‑pepper noise, this code performs the rasterization, median filtering, and saving steps automatically.
 */