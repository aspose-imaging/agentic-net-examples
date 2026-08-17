// HOW-TO: Adjust Contrast Of Multiple CDR Files And Combine Into Multi‑Page TIFF In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input CDR files
            string[] inputPaths = {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF file
            string outputPath = "output.tif";

            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // List to hold processed raster images
            List<RasterImage> rasterImages = new List<RasterImage>();

            // Process each CDR file: rasterize, adjust contrast, store raster
            foreach (string cdrPath in inputPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Rasterize CDR to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        };
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load raster image from memory stream
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        // Adjust contrast (example value: 0.5f)
                        raster.AdjustContrast(0.5f);
                        rasterImages.Add(raster);
                    }
                }
            }

            // Use dimensions of the first raster image for the TIFF canvas
            int canvasWidth = rasterImages[0].Width;
            int canvasHeight = rasterImages[0].Height;

            // Prepare TIFF save options with a bound file source
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            // Create multi-page TIFF canvas
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
            {
                // Add each processed raster as a new page
                foreach (RasterImage raster in rasterImages)
                {
                    tiff.AddPage(raster);
                }

                // Save the TIFF (output path already bound)
                tiff.Save();
            }

            // Dispose raster images after they are no longer needed
            foreach (RasterImage raster in rasterImages)
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
 * 1. When you need to batch‑process several CorelDRAW (CDR) drawings, increase their contrast and store them as a single multi‑page TIFF for printing or archival.
 * 2. When an application must convert vector CDR files to raster images, apply a contrast boost, and combine the results into one TIFF to reduce file handling overhead.
 * 3. When generating a multi‑page document from individual design assets, you can adjust each CDR page’s contrast for visual consistency before merging them into a TIFF for distribution.
 * 4. When automating the preparation of scanned‑like images from CDR sources, you can programmatically enhance contrast and bundle the pages into a TIFF for use in document management systems.
 * 5. When creating a searchable image archive, you may need to rasterize CDR files, improve their contrast for OCR accuracy, and compile them into a single TIFF file for easier indexing.
 */
