// HOW-TO: Combine Multiple BMP Files Into a Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
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

            // Load BMP images and create corresponding TiffFrames
            List<TiffFrame> frames = new List<TiffFrame>();
            int firstWidth = 0;
            int firstHeight = 0;

            foreach (var inputPath in inputPaths)
            {
                using (Image bmpImage = Image.Load(inputPath))
                {
                    // Capture dimensions from the first image (used for creating the base TIFF)
                    if (frames.Count == 0)
                    {
                        firstWidth = bmpImage.Width;
                        firstHeight = bmpImage.Height;
                    }

                    // Create a TiffFrame from the loaded raster image
                    TiffFrame frame = new TiffFrame((RasterImage)bmpImage);
                    frames.Add(frame);
                }
            }

            // Configure TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create a base TIFF image (contains a default frame)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, firstWidth, firstHeight))
            {
                // Add all frames to the TIFF image
                foreach (var frame in frames)
                {
                    tiffImage.AddFrame(frame);
                }

                // Remove the initial default frame
                TiffFrame activeFrame = tiffImage.ActiveFrame;
                if (tiffImage.Frames.Length > 1)
                {
                    tiffImage.ActiveFrame = tiffImage.Frames[1];
                    tiffImage.RemoveFrame(0);
                }
                activeFrame.Dispose();

                // Save the multi‑page TIFF
                tiffImage.Save();
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
 * 1. When you need to archive a series of scanned BMP pages as a single multi‑page TIFF document for easy distribution.
 * 2. When a batch process must convert daily generated BMP screenshots into a multi‑page TIFF for inclusion in a report.
 * 3. When an application has to merge individual BMP assets, such as map tiles, into one TIFF file for GIS analysis.
 * 4. When a medical imaging workflow requires stacking BMP scans of tissue samples into a multi‑frame TIFF for archival compliance.
 * 5. When a printing system must combine separate BMP artwork layers into a single multi‑page TIFF before sending to a printer.
 */
