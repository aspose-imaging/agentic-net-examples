using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "output.bmp";

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
            // Load the CorelDRAW (CDR) file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize the vector image to a PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    cdrImage.Save(ms, new PngOptions());
                    ms.Position = 0; // Reset stream position for reading

                    // Load the rasterized image
                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        // Apply Gaussian blur filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

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
 * 1. When a designer needs to convert a CorelDRAW (CDR) illustration into a BMP thumbnail with a soft‑focus Gaussian blur for a product catalog.
 * 2. When an automated batch job must rasterize vector CDR files, apply a Gaussian blur to obscure proprietary details, and save the result as BMP for legacy systems.
 * 3. When a web service receives CDR artwork, generates a blurred preview image in BMP format, and serves it quickly in a content‑management portal.
 * 4. When a migration script has to transform old CorelDRAW assets into BMP files with a consistent blur to match a new branding style across marketing materials.
 * 5. When a testing framework validates that applying a Gaussian blur filter to rasterized CDR content produces the expected BMP output for quality assurance.
 */