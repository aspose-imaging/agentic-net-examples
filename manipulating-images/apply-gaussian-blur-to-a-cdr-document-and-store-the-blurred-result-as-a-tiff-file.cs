using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
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
            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Rasterize CDR to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    cdr.Save(ms, new PngOptions());
                    ms.Position = 0;

                    // Load raster image from memory
                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        // Apply Gaussian blur filter (radius 5, sigma 4.0)
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                        // Prepare TIFF save options
                        TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

                        // Save the blurred image as TIFF
                        raster.Save(outputPath, tiffOptions);
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
 * 1. When a printing service needs to generate a soft‑focus preview of a CorelDRAW (CDR) artwork for client approval, they can rasterize the CDR, apply a Gaussian blur, and export it as a high‑resolution TIFF.
 * 2. When a document management system must create a blurred background version of a vector logo stored in CDR to use as a watermark behind confidential text in a TIFF report.
 * 3. When an e‑learning platform wants to produce blurred thumbnail images of CDR‑based diagrams for faster page loading, converting them to TIFF after applying a Gaussian blur filter.
 * 4. When a digital archiving solution requires a low‑contrast TIFF copy of a CDR illustration to meet archival standards that discourage sharp edges, using Gaussian blur to soften the image.
 * 5. When a marketing automation tool needs to generate a stylized, blurred version of a CDR banner for background use in email templates, saving the result as a TIFF file for compatibility with legacy email clients.
 */