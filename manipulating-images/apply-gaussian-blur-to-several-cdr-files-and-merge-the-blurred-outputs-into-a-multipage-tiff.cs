// HOW-TO: Apply Gaussian Blur to Multiple CDR Files and Merge into TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            string[] cdrPaths = new string[]
            {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF path
            string outputTiffPath = "output\\merged.tif";

            // Verify input files exist
            foreach (var path in cdrPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Prepare list for blurred raster images
            List<RasterImage> blurredImages = new List<RasterImage>();

            // Process each CDR file: rasterize, blur, store
            foreach (var cdrPath in cdrPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new CdrRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        };
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        RasterImage raster = (RasterImage)Image.Load(ms);
                        var blurOptions = new GaussianBlurFilterOptions(5, 1.5f);
                        raster.Filter(raster.Bounds, blurOptions);
                        blurredImages.Add(raster);
                    }
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // Create multipage TIFF and add blurred frames
            var tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, blurredImages[0].Width, blurredImages[0].Height))
            {
                // First frame
                tiff.SavePixels(tiff.Bounds, blurredImages[0].LoadPixels(blurredImages[0].Bounds));

                // Additional frames
                for (int i = 1; i < blurredImages.Count; i++)
                {
                    var frame = new TiffFrame(tiffOptions, blurredImages[i].Width, blurredImages[i].Height);
                    tiff.AddFrame(frame);
                    tiff.ActiveFrame = frame;
                    tiff.ActiveFrame.SavePixels(tiff.ActiveFrame.Bounds, blurredImages[i].LoadPixels(blurredImages[i].Bounds));
                }

                // Save the multipage TIFF
                tiff.Save(outputTiffPath);
            }

            // Dispose blurred raster images
            foreach (var img in blurredImages)
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
 * 1. When you must generate a soft‑focused multipage TIFF preview of several CorelDRAW (CDR) drawings for a client presentation using C#.
 * 2. When an automated workflow requires rasterizing CDR artwork, applying a Gaussian blur filter, and storing the results as a single multipage TIFF for archival purposes.
 * 3. When a document processing system needs to combine blurred versions of multiple vector designs into one TIFF file to reduce file size and simplify distribution.
 * 4. When you want to programmatically apply a consistent blur effect to a batch of CDR files before printing to ensure uniform background smoothing across all pages.
 * 5. When integrating Aspose.Imaging into a C# application to convert vector CDR files to raster images, apply image filters, and output a multi‑page TIFF for use in scanning or OCR pipelines.
 */
