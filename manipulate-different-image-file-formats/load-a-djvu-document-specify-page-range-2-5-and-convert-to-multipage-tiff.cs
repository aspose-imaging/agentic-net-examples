using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputPath = @"C:\Temp\sample.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Deflate,
                    BitsPerSample = new ushort[] { 1 } // optional: convert to B/W
                };

                // Specify page range 2‑5 (zero‑based indexes 1‑4)
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 1, 2, 3, 4 });

                // Save as multipage TIFF
                djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When a legal firm needs to archive pages 2‑5 of a scanned DjVu case file as a compressed multipage TIFF for long‑term storage and easy viewing in Windows.
 * 2. When a publishing company wants to extract a subset of pages from a DjVu manuscript and convert them to a single TIFF file to feed into an OCR pipeline that only accepts TIFF input.
 * 3. When a medical records system must transform specific pages of a DjVu patient scan into a lossless, single‑file TIFF to attach to an EMR that requires TIFF attachments.
 * 4. When a government agency automates the conversion of particular pages of historic DjVu documents into a multipage TIFF with Deflate compression for inclusion in a searchable digital archive.
 * 5. When a C# desktop application uses Aspose.Imaging to load a DjVu file, select pages 2‑5, and save them as a black‑and‑white multipage TIFF for printing on low‑resolution printers.
 */