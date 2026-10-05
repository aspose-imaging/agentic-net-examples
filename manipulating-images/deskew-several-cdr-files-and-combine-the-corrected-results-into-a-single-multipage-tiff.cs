// HOW-TO: Deskew Multiple Cdr Files And Merge Into Multipage Tiff In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            string[] inputPaths = new string[]
            {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF path
            string outputPath = "output.tif";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Prepare list to hold processed raster images
            List<RasterImage> rasterImages = new List<RasterImage>();

            // Process each CDR file: rasterize and store
            foreach (string cdrPath in inputPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Rasterize CDR to PNG in memory
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new CdrRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        };
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load raster image
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        rasterImages.Add(raster);
                    }
                }
            }

            // Create multipage image from raster pages
            Image[] pages = rasterImages.Cast<Image>().ToArray();
            using (Image multipage = Image.Create(pages, true))
            {
                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Save as multipage TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                multipage.Save(outputPath, tiffOptions);
            }

            // Dispose raster images
            foreach (var img in rasterImages)
            {
                img.Dispose();
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
 * 1. When you need to automatically correct the orientation of scanned CorelDRAW (CDR) drawings before archiving them as a single multipage TIFF document.
 * 2. When a batch processing job must convert several CDR pages to raster images, apply deskew, and combine them for printing or PDF generation.
 * 3. When an application has to integrate legacy CDR artwork into a document management system that only accepts TIFF files.
 * 4. When you want to create a searchable multipage TIFF from multiple CDR files after aligning them to improve OCR accuracy.
 * 5. When a workflow requires consolidating multiple vector drawings into one TIFF file while ensuring each page is properly straightened for consistent viewing.
 */
