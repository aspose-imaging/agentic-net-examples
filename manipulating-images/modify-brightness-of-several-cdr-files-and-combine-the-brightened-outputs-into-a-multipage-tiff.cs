// HOW-TO: Adjust Brightness of Multiple CDR Files and Merge into Multipage TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\temp\file1.cdr",
                @"C:\temp\file2.cdr",
                @"C:\temp\file3.cdr"
            };

            // Hard‑coded output multipage TIFF
            string outputPath = @"C:\temp\combined.tif";

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffImage combinedTiff = null;

            foreach (var inputPath in inputPaths)
            {
                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Prepare rasterization options for vector to raster conversion
                    var rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        PageWidth = cdrImage.Width,
                        PageHeight = cdrImage.Height
                    };

                    // TIFF save options that use the rasterization options above
                    var tiffSaveOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the rasterized page to a memory stream (as TIFF)
                    using (var ms = new MemoryStream())
                    {
                        cdrImage.Save(ms, tiffSaveOptions);
                        ms.Position = 0;

                        // Load the generated TIFF so we can adjust its brightness
                        using (TiffImage tiffPage = (TiffImage)Image.Load(ms))
                        {
                            // Adjust brightness (example value: 50)
                            tiffPage.AdjustBrightness(50);

                            // Add the adjusted frame to the combined TIFF
                            if (combinedTiff == null)
                            {
                                // First page creates the TiffImage instance
                                combinedTiff = new TiffImage(tiffPage.ActiveFrame);
                            }
                            else
                            {
                                // Subsequent pages are added as new frames
                                combinedTiff.AddFrame(tiffPage.ActiveFrame);
                            }
                        }
                    }
                }
            }

            // Save the combined multipage TIFF
            if (combinedTiff != null)
            {
                var finalSaveOptions = new TiffOptions(TiffExpectedFormat.Default);
                combinedTiff.Save(outputPath, finalSaveOptions);
                combinedTiff.Dispose();
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
 * 1. When you need to increase the visual clarity of several CorelDRAW (CDR) drawings before archiving them as a single multipage TIFF document.
 * 2. When an automated batch process must apply a uniform brightness adjustment to a collection of vector graphics and combine the results for printing or PDF conversion.
 * 3. When a desktop application imports CDR assets, brightens them to match a design theme, and saves them as a multi‑page TIFF for downstream workflows.
 * 4. When a server‑side service prepares image assets for a digital asset management system by rasterizing CDR files, adjusting brightness, and storing them in a single TIFF file.
 * 5. When you need to programmatically verify the existence of multiple CDR files, enhance their exposure, and consolidate them into one TIFF for easy distribution to clients.
 */
