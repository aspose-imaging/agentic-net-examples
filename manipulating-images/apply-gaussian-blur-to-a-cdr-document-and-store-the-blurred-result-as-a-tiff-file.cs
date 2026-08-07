using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to treat the loaded image as a raster image
                RasterImage raster = image as RasterImage;

                if (raster != null)
                {
                    // Apply Gaussian blur directly
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                    raster.Save(outputPath);
                }
                else
                {
                    // If not raster, rasterize via an intermediate format (PNG) in memory
                    using (var tempStream = new MemoryStream())
                    {
                        // Save to PNG to force rasterization
                        image.Save(tempStream, new PngOptions());
                        tempStream.Position = 0;

                        // Load the rasterized image
                        using (RasterImage tempRaster = (RasterImage)Image.Load(tempStream))
                        {
                            // Apply Gaussian blur
                            tempRaster.Filter(tempRaster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                            // Save the final TIFF
                            tempRaster.Save(outputPath);
                        }
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
 * 1. When a designer wants to create a soft‑focus preview of a CorelDRAW (CDR) illustration for a marketing mock‑up, they can use this code to blur the vector artwork and export it as a high‑resolution TIFF.
 * 2. When an automated publishing pipeline needs to generate print‑ready TIFF files with a subtle blur effect from legacy CDR files, the snippet provides a C# solution that rasterizes the drawing and applies Gaussian blur.
 * 3. When a document management system must store confidential CDR drawings with reduced detail for external reviewers, developers can blur the content and save it as a TIFF using Aspose.Imaging.
 * 4. When a batch‑processing tool has to convert a collection of CDR logos into blurred TIFF watermarks for use in PDF reports, this code demonstrates the necessary steps in .NET.
 * 5. When a quality‑control script must compare the visual similarity of original CDR files to their blurred TIFF versions, the example shows how to apply a Gaussian blur filter and produce the TIFF output programmatically.
 */