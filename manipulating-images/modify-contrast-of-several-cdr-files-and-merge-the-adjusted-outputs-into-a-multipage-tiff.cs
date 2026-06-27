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
            // Hardcoded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\input\file1.cdr",
                @"C:\input\file2.cdr"
                // add more input files as needed
            };

            // Hardcoded output multipage TIFF file
            string outputPath = @"C:\output\merged.tif";

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

            TiffImage finalTiff = null;

            foreach (string inputPath in inputPaths)
            {
                // Load CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Iterate through all pages of the CDR file
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        // Export the page to a memory stream as a TIFF image
                        using (var ms = new MemoryStream())
                        {
                            var tiffExportOptions = new TiffOptions(TiffExpectedFormat.Default);
                            page.Save(ms, tiffExportOptions);
                            ms.Position = 0;

                            // Load the exported TIFF, adjust contrast, and collect the frame
                            using (TiffImage tiffPage = (TiffImage)Image.Load(ms))
                            {
                                // Adjust contrast (example value: 50)
                                tiffPage.AdjustContrast(50f);

                                if (finalTiff == null)
                                {
                                    // Initialize final multipage TIFF with the first frame
                                    finalTiff = new TiffImage(tiffPage.ActiveFrame);
                                }
                                else
                                {
                                    // Append subsequent frames
                                    finalTiff.AddFrame(tiffPage.ActiveFrame);
                                }
                            }
                        }
                    }
                }
            }

            // If at least one frame was processed, save the multipage TIFF
            if (finalTiff != null)
            {
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                finalTiff.Save(outputPath, saveOptions);
                finalTiff.Dispose();
            }
            else
            {
                Console.Error.WriteLine("No frames were processed; output TIFF not created.");
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
 * 1. When a graphic design studio needs to batch‑process CorelDRAW (CDR) artwork, increase the contrast for better print quality, and combine the pages into a single multipage TIFF for archival or client review.
 * 2. When an e‑learning platform converts lecture slides saved as CDR files, adjusts their contrast to improve readability on screens, and merges them into a multipage TIFF to embed in PDFs or LMS modules.
 * 3. When a legal firm receives scanned documents in CDR format, wants to enhance contrast for OCR accuracy, and bundles the enhanced pages into one TIFF file for easy storage and retrieval.
 * 4. When a publishing house prepares color‑corrected illustrations from multiple CDR sources and needs a single multipage TIFF to send to a pre‑press workflow that only accepts TIFF images.
 * 5. When an automation script processes product catalog pages stored as CDR files, applies contrast adjustments to match brand guidelines, and outputs a combined multipage TIFF for bulk printing.
 */