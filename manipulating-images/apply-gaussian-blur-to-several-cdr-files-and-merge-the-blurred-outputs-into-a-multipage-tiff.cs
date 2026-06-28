using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            string cdrPath1 = "input1.cdr";
            string cdrPath2 = "input2.cdr";
            string cdrPath3 = "input3.cdr";

            // Verify input files exist
            if (!File.Exists(cdrPath1)) { Console.Error.WriteLine($"File not found: {cdrPath1}"); return; }
            if (!File.Exists(cdrPath2)) { Console.Error.WriteLine($"File not found: {cdrPath2}"); return; }
            if (!File.Exists(cdrPath3)) { Console.Error.WriteLine($"File not found: {cdrPath3}"); return; }

            // Output multipage TIFF path
            string outputPath = "merged_output.tif";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Tiff options for the output file
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffJpegRgb);

            TiffImage tiffImage = null;
            bool first = true;

            foreach (string cdrPath in new[] { cdrPath1, cdrPath2, cdrPath3 })
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Rasterize CDR to PNG in memory
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

                        // Load rasterized PNG
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            if (first)
                            {
                                // Create TiffImage with first frame size
                                tiffImage = (TiffImage)Image.Create(tiffOptions, raster.Width, raster.Height);
                                first = false;
                            }
                            else
                            {
                                // Add a new frame for subsequent images
                                TiffFrame newFrame = new TiffFrame(tiffOptions, raster.Width, raster.Height);
                                tiffImage.AddFrame(newFrame);
                                tiffImage.ActiveFrame = newFrame;
                            }

                            // Copy pixel data to the active frame
                            var pixels = raster.LoadPixels(raster.Bounds);
                            tiffImage.ActiveFrame.SavePixels(tiffImage.ActiveFrame.Bounds, pixels);
                        }
                    }
                }
            }

            // Save the multipage TIFF
            tiffImage?.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a publishing workflow needs to generate a preview booklet by applying a Gaussian blur to multiple CorelDRAW (CDR) pages and combining them into a single multipage TIFF for quick client review.
 * 2. When an e‑learning platform must batch‑process course slide assets in CDR format, soften the graphics with Gaussian blur, and store the results as a compressed TIFF for efficient streaming.
 * 3. When a digital archiving system requires converting several vector CDR illustrations into a blurred, rasterized TIFF document to preserve visual fidelity while reducing file size for long‑term storage.
 * 4. When a print shop wants to create a proof PDF by first blurring confidential design elements in multiple CDR files and then merging the pages into a multipage TIFF before final PDF conversion.
 * 5. When a marketing automation tool needs to apply a uniform Gaussian blur filter to a series of CDR logos, rasterize them, and bundle the outputs into a single TIFF file for batch uploading to a content management system.
 */