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
            string inputPath = "input\\sample.djvu";
            string outputPath = "output\\combined.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                // Optional: convert to 1‑bit B/W if needed
                tiffOptions.BitsPerSample = new ushort[] { 1 };

                // Select pages 5‑7 (zero‑based indexes 4,5,6)
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 4, 5, 6 });

                // Save combined multipage TIFF
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
 * 1. When a legal firm needs to archive selected pages (5‑7) of a scanned DjVu case file as a compressed multi‑page TIFF for long‑term storage and easy retrieval.
 * 2. When a publishing company wants to extract specific illustration pages from a DjVu manuscript and combine them into a single TIFF for print‑ready proofing.
 * 3. When a medical records system must convert particular pages of a DjVu radiology report into a 1‑bit black‑and‑white multipage TIFF to meet DICOM archival standards.
 * 4. When a government agency automates the conversion of confidential DjVu documents, selecting only the relevant pages and saving them as a deflate‑compressed TIFF for secure distribution.
 * 5. When a digital archiving workflow extracts pages 5‑7 from a DjVu archive and creates a single TIFF file to be indexed by OCR software that only supports TIFF input.
 */