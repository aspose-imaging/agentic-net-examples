using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[]
        {
            @"C:\input\file1.cdr",
            @"C:\input\file2.cdr",
            @"C:\input\file3.cdr"
        };
        string outputPath = @"C:\output\combined.tif";

        try
        {
            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Prepare a list to hold processed TIFF frames
            List<TiffFrame> processedFrames = new List<TiffFrame>();

            // Process each CDR file
            foreach (var inputPath in inputPaths)
            {
                // Load the CDR file
                using (Image cdrImage = Image.Load(inputPath))
                {
                    // Rasterize CDR to TIFF using a memory stream
                    using (MemoryStream tiffStream = new MemoryStream())
                    {
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        cdrImage.Save(tiffStream, tiffOptions);
                        tiffStream.Position = 0;

                        // Load the rasterized TIFF
                        using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
                        {
                            // Apply gamma correction (example gamma value)
                            tiffImage.AdjustGamma(2.2f);

                            // Clone the active frame to keep it after disposing tiffImage
                            TiffFrame clonedFrame = new TiffFrame(tiffImage.ActiveFrame);
                            processedFrames.Add(clonedFrame);
                        }
                    }
                }
            }

            if (processedFrames.Count == 0)
            {
                Console.Error.WriteLine("No frames were processed.");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a multipage TIFF from the processed frames
            using (TiffImage multiPageTiff = new TiffImage(processedFrames[0]))
            {
                for (int i = 1; i < processedFrames.Count; i++)
                {
                    multiPageTiff.AddFrame(processedFrames[i]);
                }

                // Save the combined multipage TIFF
                multiPageTiff.Save(outputPath);
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
 * 1. When a graphic designer needs to batch‑process CorelDRAW (.cdr) drawings, adjust their brightness via gamma correction, and deliver the results as a single multipage TIFF for print‑ready proofing.
 * 2. When an archival system must normalize the visual appearance of vector artwork stored as CDR files before storing them in a TIFF‑based digital repository.
 * 3. When a publishing workflow requires converting multiple CDR illustrations to a high‑resolution TIFF, applying consistent gamma to match the paper’s color profile, and merging them into one file for easy pagination.
 * 4. When a quality‑control tool automatically checks product packaging mock‑ups saved as CDR, corrects their gamma to a standard 2.2 value, and bundles the images into a multipage TIFF for reviewer distribution.
 * 5. When a document‑management application needs to ingest several CDR files, perform gamma correction to ensure uniform contrast across pages, and output a single TIFF document for downstream OCR processing.
 */