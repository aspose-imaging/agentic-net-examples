using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access AdjustContrast
                TiffImage tiffImage = (TiffImage)image;

                // Increase contrast by 30%
                tiffImage.AdjustContrast(30f);

                // Save the result as PDF
                tiffImage.Save(outputPath, new PdfOptions());
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
 * 1. When a medical imaging system uses Aspose.Imaging for .NET to enhance the visibility of details in scanned X‑ray TIFF files by raising contrast and then archives them as PDF reports.
 * 2. When a document management workflow employs Aspose.Imaging for .NET to improve the readability of old scanned contracts stored as TIFF, increases contrast by 30 % and converts them to PDF for electronic filing.
 * 3. When a publishing platform processes high‑resolution TIFF artwork, uses Aspose.Imaging for .NET to boost contrast to meet print standards, and outputs a PDF proof for client review.
 * 4. When a GIS application prepares satellite TIFF imagery, applies Aspose.Imaging for .NET to adjust contrast and highlight terrain features before saving the map sheet as a PDF.
 * 5. When an e‑learning content creator cleans up scanned textbook pages in TIFF format, leverages Aspose.Imaging for .NET to raise contrast for better on‑screen legibility and bundles the pages into a PDF handbook.
 */