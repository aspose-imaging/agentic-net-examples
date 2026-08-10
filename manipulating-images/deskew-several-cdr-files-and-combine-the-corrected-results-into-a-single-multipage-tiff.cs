// HOW-TO: Deskew Multiple CDR Files and Merge Into Multipage TIFF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input CDR files
            string[] inputPaths = {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF file
            string outputPath = "output\\combined.tif";

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare variables for the first image (used to create the TIFF canvas)
            int canvasWidth = 0;
            int canvasHeight = 0;
            bool firstImageProcessed = false;

            // TiffOptions with bound output file
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create the TIFF image placeholder (will be initialized after first raster is ready)
            TiffImage tiffImage = null;

            // Process each CDR file
            foreach (var inputPath in inputPaths)
            {
                // Load CDR image
                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    // Rasterize the CDR to a PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        cdr.Save(ms, new PngOptions());
                        ms.Position = 0;

                        // Load the rasterized image
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Deskew the rasterized image (do not resize canvas, fill background with white)
                            raster.NormalizeAngle(false, Color.White);

                            // Initialize TIFF canvas on first iteration
                            if (!firstImageProcessed)
                            {
                                canvasWidth = raster.Width;
                                canvasHeight = raster.Height;

                                tiffImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight);
                                tiffImage.AddPage(raster);
                                firstImageProcessed = true;
                            }
                            else
                            {
                                // Add subsequent pages
                                tiffImage.AddPage(raster);
                            }
                        }
                    }
                }
            }

            // Save the multipage TIFF
            if (tiffImage != null)
            {
                tiffImage.Save();
                tiffImage.Dispose();
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
 * 1. When you need to automatically correct the orientation of scanned CorelDRAW drawings and store them as a single searchable multipage TIFF for archiving.
 * 2. When a batch processing job must convert several CDR design files to a common raster format while applying deskew to each page before combining them for printing.
 * 3. When an application has to generate a consolidated TIFF report from multiple vector drawings, ensuring each page is properly aligned without manual intervention.
 * 4. When integrating CorelDRAW assets into a document management system that only accepts TIFF, and you must deskew and merge the files programmatically.
 * 5. When creating a digital archive of engineering schematics stored as CDR files, requiring automated deskew and multi‑page TIFF output for compliance.
 */
