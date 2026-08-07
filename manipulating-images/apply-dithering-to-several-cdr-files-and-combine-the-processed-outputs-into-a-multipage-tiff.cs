// HOW-TO: Apply Dithering to Multiple CDR Files and Create Multipage TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\Input\file1.cdr",
                @"C:\Input\file2.cdr",
                @"C:\Input\file3.cdr"
            };

            // Hard‑coded output multipage TIFF
            string outputPath = @"C:\Output\combined.tif";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffImage finalTiff = null; // Will hold the combined TIFF

            foreach (string inputPath in inputPaths)
            {
                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Prepare rasterization options for TIFF conversion
                    var rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = cdrImage.Width,
                        PageHeight = cdrImage.Height,
                        BackgroundColor = Color.White
                    };

                    // TIFF export options using the rasterization settings above
                    var tiffExportOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Rasterize the CDR page to a TIFF image in memory
                    using (var ms = new MemoryStream())
                    {
                        cdrImage.Save(ms, tiffExportOptions);
                        ms.Position = 0; // Reset stream position for loading

                        // Load the rasterized TIFF image
                        using (TiffImage tiffImage = (TiffImage)Image.Load(ms))
                        {
                            // Apply Floyd‑Steinberg dithering with 1‑bit palette
                            tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                            // If this is the first processed image, initialise finalTiff
                            if (finalTiff == null)
                            {
                                // Clone the first image to start the multipage TIFF
                                finalTiff = (TiffImage)Image.Create(tiffExportOptions, tiffImage.Width, tiffImage.Height);
                                finalTiff.ActiveFrame = tiffImage.ActiveFrame;
                            }
                            else
                            {
                                // Add the current frame to the existing multipage TIFF
                                // The AddFrame method adds a new frame to the collection
                                finalTiff.AddFrame(tiffImage.ActiveFrame);
                            }
                        }
                    }
                }
            }

            // Save the combined multipage TIFF
            finalTiff?.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a batch of CorelDRAW (CDR) drawings into a single multipage TIFF for archival or printing purposes.
 * 2. When you want to rasterize CDR pages with single‑bit dithering to produce high‑contrast black‑and‑white images.
 * 3. When an application must automatically combine several design files into one TIFF document to simplify distribution to clients who only accept TIFF.
 * 4. When you are building a server‑side service that checks input file existence, applies consistent rendering settings, and generates a combined TIFF without manual steps.
 * 5. When you must ensure each TIFF page has uniform dimensions, a white background, and no smoothing to meet strict printing or OCR requirements.
 */
