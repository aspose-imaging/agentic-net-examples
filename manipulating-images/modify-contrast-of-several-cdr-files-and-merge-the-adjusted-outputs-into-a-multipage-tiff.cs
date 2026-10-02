// HOW-TO: Adjust Contrast of Multiple CDR Files and Merge Into Multipage TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            List<string> cdrPaths = new List<string>
            {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF path (ensure directory part exists)
            string outputTiffPath = "output\\merged.tif";

            // Validate input files
            foreach (var path in cdrPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // List to hold processed raster images
            List<RasterImage> rasterImages = new List<RasterImage>();

            // Process each CDR file: rasterize and adjust contrast
            foreach (var cdrPath in cdrPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
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
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        raster.AdjustContrast(30f); // Adjust contrast by 30
                        rasterImages.Add(raster);
                    }
                }
            }

            if (rasterImages.Count == 0)
            {
                Console.Error.WriteLine("No images were processed.");
                return;
            }

            // Create multipage TIFF
            int width = rasterImages[0].Width;
            int height = rasterImages[0].Height;
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);

            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // First frame
                Color[] firstPixels = rasterImages[0].LoadPixels(rasterImages[0].Bounds);
                tiff.SavePixels(tiff.Bounds, firstPixels);

                // Subsequent frames
                for (int i = 1; i < rasterImages.Count; i++)
                {
                    tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                    tiff.ActiveFrame = tiff.Frames[tiff.Frames.Count() - 1];
                    Color[] pixels = rasterImages[i].LoadPixels(rasterImages[i].Bounds);
                    tiff.SavePixels(tiff.ActiveFrame.Bounds, pixels);
                }

                tiff.Save(outputTiffPath);
            }

            // Dispose raster images
            foreach (var raster in rasterImages)
            {
                raster.Dispose();
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
 * 1. When you need to batch‑process CorelDRAW (CDR) drawings, enhance their contrast, and combine them into a single multipage TIFF for archival or printing.
 * 2. When an application must convert several CDR pages to raster images, apply image‑level adjustments, and output a multi‑page TIFF for use in document management systems.
 * 3. When a workflow requires automated preparation of high‑contrast preview files from multiple CDR sources before sending them to a print shop that only accepts TIFF.
 * 4. When you want to programmatically generate a composite TIFF report that includes contrast‑optimized screenshots of different CDR designs using Aspose.Imaging for .NET.
 * 5. When integrating a C# service that consolidates edited CDR artwork into a single TIFF document for downstream processing such as OCR or digital asset management.
 */
