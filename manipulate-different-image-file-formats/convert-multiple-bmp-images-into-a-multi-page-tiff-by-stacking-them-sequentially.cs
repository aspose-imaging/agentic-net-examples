using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hard‑coded input BMP files and output TIFF file
        string[] inputPaths = new string[]
        {
            @"c:\temp\image1.bmp",
            @"c:\temp\image2.bmp",
            @"c:\temp\image3.bmp"
        };
        string outputPath = @"c:\temp\output.tif";

        try
        {
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

            // Load BMP images and convert them to TiffFrames
            List<TiffFrame> frames = new List<TiffFrame>();
            foreach (string inputPath in inputPaths)
            {
                // Load the BMP image
                using (Image bmpImage = Image.Load(inputPath))
                {
                    // Create a TiffFrame from the loaded raster image
                    TiffFrame frame = new TiffFrame((RasterImage)bmpImage);
                    frames.Add(frame);
                }
            }

            // Create a multi‑page TIFF image from the frames
            using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
            {
                // Save the TIFF to the specified output path
                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to combine several BMP scans of a document into a single multi‑page TIFF for archival or printing workflows.
 * 2. When an application must programmatically generate a multi‑frame TIFF from a series of bitmap images to support fax transmission or OCR preprocessing.
 * 3. When a batch‑processing tool has to convert a set of BMP screenshots into a compact TIFF file for easier storage and distribution.
 * 4. When a .NET service is required to validate the existence of input BMP files, load them as RasterImage objects, and stack them sequentially into a multi‑page TIFF for medical imaging records.
 * 5. When an automated reporting system needs to merge individual BMP charts into one multi‑page TIFF document that can be opened by standard image viewers.
 */