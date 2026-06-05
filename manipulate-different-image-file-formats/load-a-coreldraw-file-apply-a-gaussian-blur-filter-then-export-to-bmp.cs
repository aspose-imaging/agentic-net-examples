using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "output.bmp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the CorelDRAW (CDR) file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Export the CDR image to a raster format (PNG) in memory
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    cdrImage.Save(rasterStream, new PngOptions());
                    rasterStream.Position = 0;

                    // Load the raster image from the memory stream
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Apply Gaussian blur filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the processed image as BMP
                        rasterImage.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) illustration into a BMP thumbnail while softening edges with a Gaussian blur for a preview gallery.
 * 2. When an application must ingest vector CDR artwork, rasterize it to PNG in memory, apply a blur effect, and save the result as a BMP for legacy Windows printing.
 * 3. When a batch processing tool has to validate the existence of CDR files, apply a uniform blur filter to reduce detail, and export them to BMP for use in low‑resolution device simulations.
 * 4. When a graphics pipeline requires loading a CDR design, applying a Gaussian blur with a radius of 5 and sigma 4.0, and outputting a BMP file for integration into a game’s texture atlas.
 * 5. When a document management system needs to generate blurred BMP previews of uploaded CorelDRAW files to protect sensitive details while still showing the overall layout.
 */