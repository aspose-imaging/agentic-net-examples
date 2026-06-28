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
                @"C:\temp\input1.cdr",
                @"C:\temp\input2.cdr"
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffImage finalTiff = null;

            foreach (var inputPath in inputPaths)
            {
                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Export the first page of the CDR to a temporary TIFF
                    string tempTiffPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(tempTiffPath));

                    var exportOptions = new TiffOptions(TiffExpectedFormat.Default);
                    cdrImage.Save(tempTiffPath, exportOptions);

                    // Load the temporary TIFF, adjust its brightness, and keep the frame
                    using (TiffImage tiff = (TiffImage)Image.Load(tempTiffPath))
                    {
                        // Adjust brightness (example value: 50)
                        tiff.AdjustBrightness(50);

                        // Add the adjusted frame to the final multipage TIFF
                        if (finalTiff == null)
                        {
                            // First frame creates the TiffImage instance
                            finalTiff = new TiffImage(tiff.ActiveFrame);
                        }
                        else
                        {
                            // Subsequent frames are appended
                            finalTiff.AddFrame(tiff.ActiveFrame);
                        }
                    }

                    // Clean up the temporary file
                    try { File.Delete(tempTiffPath); } catch { /* ignore cleanup errors */ }
                }
            }

            // Save the combined multipage TIFF
            if (finalTiff != null)
            {
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                finalTiff.Save(outputPath, saveOptions);
                finalTiff.Dispose();
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
 * 1. When a developer needs to batch‑process CorelDRAW (CDR) artwork, increase its brightness, and archive the results as a single multipage TIFF for easy distribution or review.
 * 2. When an automated workflow must convert multiple CDR design files into a printable multipage TIFF while applying a uniform brightness boost to ensure consistent visual appearance across all pages.
 * 3. When a document management system requires ingesting several CDR diagrams, normalizing their exposure, and storing them as a combined TIFF document for long‑term archival and quick preview.
 * 4. When a web service generates a PDF‑like preview by brightening each CDR page and stitching them into a multipage TIFF that can be rendered in browsers without needing CorelDRAW installed.
 * 5. When a quality‑control tool needs to load a set of CDR files, adjust their brightness to meet printing standards, and output a single TIFF file that can be sent to a RIP or print server.
 */