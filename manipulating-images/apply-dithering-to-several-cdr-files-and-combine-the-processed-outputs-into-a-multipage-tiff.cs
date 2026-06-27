using System;
using System.IO;
using System.Collections.Generic;
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
            if (!File.Exists(cdrPath1))
            {
                Console.Error.WriteLine($"File not found: {cdrPath1}");
                return;
            }
            if (!File.Exists(cdrPath2))
            {
                Console.Error.WriteLine($"File not found: {cdrPath2}");
                return;
            }
            if (!File.Exists(cdrPath3))
            {
                Console.Error.WriteLine($"File not found: {cdrPath3}");
                return;
            }

            // Output TIFF path
            string outputPath = "output.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect frames after processing each CDR
            List<TiffFrame> frames = new List<TiffFrame>();

            // Process each CDR file
            foreach (string cdrPath in new[] { cdrPath1, cdrPath2, cdrPath3 })
            {
                // Load CDR vector image
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Rasterize CDR to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        cdr.Save(ms, new PngOptions());
                        ms.Position = 0;

                        // Load rasterized image
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Apply simple threshold dithering
                            Color[] pixels = raster.LoadPixels(raster.Bounds);
                            for (int i = 0; i < pixels.Length; i++)
                            {
                                Color c = pixels[i];
                                double luminance = 0.299 * c.R + 0.587 * c.G + 0.114 * c.B;
                                pixels[i] = luminance > 128 ? Color.White : Color.Black;
                            }
                            raster.SavePixels(raster.Bounds, pixels);

                            // Create a TIFF frame from the raster
                            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                            TiffFrame frame = new TiffFrame(tiffOptions, raster.Width, raster.Height);
                            frame.SavePixels(frame.Bounds, raster.LoadPixels(raster.Bounds));
                            frames.Add(frame);
                        }
                    }
                }
            }

            if (frames.Count > 0)
            {
                // Create TIFF image from collected frames and save
                using (TiffImage tiff = new TiffImage(frames[0]))
                {
                    for (int i = 1; i < frames.Count; i++)
                    {
                        tiff.AddPage(frames[i]);
                    }
                    tiff.Save(outputPath);
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
 * 1. When a publishing workflow needs to convert multiple CorelDRAW (CDR) illustrations into a single multipage TIFF for high‑resolution print production, this code rasterizes, dithers, and merges the pages automatically.
 * 2. When an archival system must store vector artwork as lossless, page‑by‑page TIFF files that preserve color fidelity through dithering, developers can use this snippet to batch‑process CDR files into a consolidated TIFF.
 * 3. When a document‑management application requires generating a fax‑compatible multipage TIFF from several CDR designs, the code applies dithering to meet the limited‑color constraints and bundles the results.
 * 4. When a quality‑control tool needs to create preview TIFFs of CDR assets with consistent dithering for visual inspection across multiple pages, this routine streamlines the conversion.
 * 5. When an OCR pipeline must ingest scanned‑style images of vector drawings, developers can convert CDR files to dithered TIFF frames to improve text recognition accuracy in a single multipage file.
 */