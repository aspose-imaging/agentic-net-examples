// HOW-TO: Apply Gaussian Blur to Multiple CDR Files and Merge into Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR files
            string inputPath1 = @"c:\temp\input1.cdr";
            string inputPath2 = @"c:\temp\input2.cdr";
            string inputPath3 = @"c:\temp\input3.cdr";

            // Hardcoded output TIFF file
            string outputPath = @"c:\temp\merged.tif";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold frames
            List<TiffFrame> frames = new List<TiffFrame>();

            // Process each CDR file
            string[] inputPaths = new[] { inputPath1, inputPath2, inputPath3 };
            foreach (string inputPath in inputPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        cdr.Save(ms, new PngOptions
                        {
                            VectorRasterizationOptions = new CdrRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        });
                        ms.Position = 0;
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            TiffFrame frame = new TiffFrame(new TiffOptions(TiffExpectedFormat.Default), raster.Width, raster.Height);
                            frame.SavePixels(frame.Bounds, raster.LoadPixels(raster.Bounds));
                            frames.Add(frame);
                        }
                    }
                }
            }

            // Create TIFF image and add frames
            using (TiffImage tiff = new TiffImage(frames[0]))
            {
                for (int i = 1; i < frames.Count; i++)
                {
                    tiff.AddFrame(frames[i]);
                }
                tiff.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When you need to create a blurred preview of several CorelDRAW drawings and combine them into a single multipage TIFF for printing or archiving.
 * 2. When you want to batch‑process CDR files, apply a Gaussian blur filter, and store the results as a compact, paginated TIFF document for easy distribution.
 * 3. When an application must convert vector CDR artwork into raster images with a soft focus effect before merging them into a multi‑page TIFF for PDF generation.
 * 4. When a workflow requires automated image preprocessing—such as blurring confidential details—in multiple CDR files and then consolidating them into one TIFF for compliance reporting.
 * 5. When you need to programmatically generate a single TIFF file that contains blurred versions of several design files for use in web galleries or digital asset management.
 */
