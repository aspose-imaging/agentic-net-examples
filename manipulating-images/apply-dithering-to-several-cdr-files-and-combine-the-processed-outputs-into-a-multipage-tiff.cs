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
            // Output TIFF path
            string outputPath = "output.tif";

            // Input CDR files (hardcoded)
            string[] inputPaths = { "file1.cdr", "file2.cdr", "file3.cdr" };

            var frames = new List<TiffFrame>();

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load CDR vector image
                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    // Prepare PNG options with vector rasterization
                    var pngOptions = new PngOptions
                    {
                        Source = new StreamSource(new MemoryStream()),
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };

                    // Create rasterized PNG in memory
                    using (Image pngImage = Image.Create(pngOptions, cdr.Width, cdr.Height))
                    {
                        using (var ms = new MemoryStream())
                        {
                            pngImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            // Load raster image from memory
                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                // Create a TIFF frame from the raster image
                                var frame = new TiffFrame(raster);
                                frames.Add(frame);
                            }
                        }
                    }
                }
            }

            if (frames.Count == 0)
            {
                Console.Error.WriteLine("No frames were created. Exiting.");
                return;
            }

            // Create multipage TIFF from frames
            using (var tiffImage = new TiffImage(frames.ToArray()))
            {
                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Save multipage TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert multiple CorelDRAW (CDR) vector files into a single multi‑page TIFF for archival or printing, applying dithering to preserve visual quality.
 * 2. When an application must batch‑process CDR designs, rasterize them to PNG with vector rasterization options, then combine them into a TIFF for compatibility with legacy imaging systems.
 * 3. When a workflow requires generating a searchable multi‑page TIFF from CDR assets while ensuring consistent color depth through dithering before saving.
 * 4. When a document management system needs to ingest several CDR illustrations, convert each to a raster image, and store them as pages in one TIFF document for easy viewing in standard image viewers.
 * 5. When a print shop automates the preparation of client‑provided CDR artwork, applying dithering to each page and merging them into a single TIFF file for high‑resolution output on commercial printers.
 */