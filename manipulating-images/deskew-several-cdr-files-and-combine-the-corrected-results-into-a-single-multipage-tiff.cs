// HOW-TO: Deskew Multiple CDR Files and Combine Into a Single Multipage TIFF Using C# (Aspose.Imaging for .NET)
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

            // Load the first CDR file to obtain canvas dimensions
            using (CdrImage cdrCanvas = (CdrImage)Image.Load(inputPaths[0]))
            {
                int canvasWidth = cdrCanvas.Width;
                int canvasHeight = cdrCanvas.Height;

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create a TIFF image with the same dimensions as the CDR canvas
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    // Merge each input raster image onto the TIFF canvas
                    foreach (string rasterPath in inputPaths)
                    {
                        using (RasterImage raster = (RasterImage)Image.Load(rasterPath))
                        {
                            // Load pixel data as ARGB integers
                            int[] argbPixels = raster.LoadPixels(raster.Bounds).Select(c => c.ToArgb()).ToArray();

                            // Define the area to paste (top-left corner)
                            var pasteRect = new Rectangle(0, 0, raster.Width, raster.Height);

                            // Paste pixels onto the TIFF canvas
                            tiffImage.SaveArgb32Pixels(pasteRect, argbPixels);
                        }
                    }

                    // Save the final merged TIFF image
                    tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to automatically correct the orientation of several CorelDRAW (CDR) drawings and produce a single searchable multipage TIFF for archiving.
 * 2. When a batch processing tool must convert a collection of CDR files into a consolidated TIFF document for printing or document management systems.
 * 3. When integrating a C# application that prepares scanned artwork by deskewing each CDR page before merging them into one TIFF for easy distribution.
 * 4. When you want to generate a multipage TIFF report from multiple CDR design files without manual editing, using Aspose.Imaging in .NET.
 * 5. When a workflow requires programmatic handling of CDR images, applying deskew corrections and combining them into a single TIFF for compliance or archival purposes.
 */
