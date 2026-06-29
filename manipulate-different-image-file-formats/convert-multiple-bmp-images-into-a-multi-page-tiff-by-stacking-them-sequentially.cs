using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input BMP files
            string[] inputPaths = new string[]
            {
                @"c:\temp\image1.bmp",
                @"c:\temp\image2.bmp",
                @"c:\temp\image3.bmp"
            };

            // Hard‑coded output TIFF file
            string outputPath = @"c:\temp\output.tif";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first BMP and create the initial TiffImage
            using (Image firstBmp = Image.Load(inputPaths[0]))
            {
                // Cast to RasterImage for the TiffFrame constructor
                var firstFrame = new TiffFrame((RasterImage)firstBmp);
                using (var tiffImage = new TiffImage(firstFrame))
                {
                    // Process remaining BMP files
                    for (int i = 1; i < inputPaths.Length; i++)
                    {
                        using (Image bmp = Image.Load(inputPaths[i]))
                        {
                            var frame = new TiffFrame((RasterImage)bmp);
                            tiffImage.AddFrame(frame);
                            // No need to dispose 'frame' explicitly; it will be disposed with the TiffImage
                        }
                    }

                    // Save the multi‑page TIFF
                    tiffImage.Save(outputPath);
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
 * 1. When a developer needs to combine scanned BMP pages of a document into a single multi‑page TIFF for archival, printing, or electronic distribution using Aspose.Imaging for .NET.
 * 2. When an application must generate a multi‑page TIFF report from a series of BMP charts produced by a C# data‑visualization module.
 * 3. When a medical imaging system stores individual BMP slices of a scan and must bundle them into a multi‑page TIFF for DICOM compatibility or radiology review.
 * 4. When a batch‑processing tool consolidates BMP screenshots captured during automated UI tests into one TIFF file for easy side‑by‑side comparison.
 * 5. When a GIS application exports multiple BMP raster tiles of a map and needs to create a multi‑page TIFF for distribution to cartographers or for further spatial analysis.
 */