using System;
using System.Collections.Generic;
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
                @"C:\Input\file1.cdr",
                @"C:\Input\file2.cdr"
                // add more paths as needed
            };

            // Hard‑coded output multipage TIFF
            string outputPath = @"C:\Output\merged.tif";

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

            // Collect all adjusted TIFF frames
            List<TiffFrame> allFrames = new List<TiffFrame>();

            // Process each CDR file
            foreach (var inputPath in inputPaths)
            {
                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Iterate through each page of the CDR document
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        // Rasterize the page to a TIFF image in memory
                        using (MemoryStream ms = new MemoryStream())
                        {
                            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                            page.Save(ms, tiffOptions);
                            ms.Position = 0;

                            // Load the rasterized TIFF so we can adjust contrast
                            using (TiffImage tiffImage = (TiffImage)Image.Load(ms))
                            {
                                // Adjust contrast (example value: 50)
                                tiffImage.AdjustContrast(50f);

                                // Clone the active frame to keep it after disposing tiffImage
                                TiffFrame adjustedFrame = new TiffFrame(tiffImage.ActiveFrame);
                                allFrames.Add(adjustedFrame);
                            }
                        }
                    }
                }
            }

            if (allFrames.Count == 0)
            {
                Console.Error.WriteLine("No frames were processed.");
                return;
            }

            // Create a multipage TIFF from the collected frames
            using (TiffImage multiPageTiff = new TiffImage(allFrames.ToArray()))
            {
                // Save the final multipage TIFF
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                multiPageTiff.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to batch‑process a collection of CorelDRAW (.cdr) drawings, increase their contrast for better visual clarity, and archive the results as a single multipage TIFF for easy distribution.
 * 2. When an automated document‑management system must convert scanned CDR design files to high‑contrast TIFF pages and combine them into one file for long‑term storage or compliance reporting.
 * 3. When a print‑shop workflow requires adjusting the contrast of multiple CDR artwork pages before merging them into a multipage TIFF that can be sent directly to a RIP or printer.
 * 4. When a web application built with C# and Aspose.Imaging for .NET needs to generate a searchable PDF‑like preview by enhancing contrast of each CDR page and bundling them into a single TIFF for downstream conversion.
 * 5. When a digital asset‑management tool must programmatically improve the contrast of several CDR assets and create a consolidated multipage TIFF for quick thumbnail generation or preview in a gallery view.
 */