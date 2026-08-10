// HOW-TO: Convert DjVu Document to Multipage TIFF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare TIFF save options with default settings
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                // Use DjvuMultiPageOptions to include all pages
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save all pages as a multipage TIFF
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
 * 1. When you need to archive scanned books stored as DjVu files into a single multipage TIFF for long‑term preservation or printing.
 * 2. When a document management system requires all pages of a DjVu manuscript to be bundled into one TIFF file for compatibility with legacy workflows.
 * 3. When you are building a C# application that extracts every page from a DjVu report and saves it as a multipage TIFF for easy viewing in standard image viewers.
 * 4. When converting DjVu technical manuals into TIFF format to embed them into PDF portfolios that only accept TIFF images.
 * 5. When automating batch processing of DjVu files on a server and need to generate default‑quality multipage TIFFs without manually handling each page.
 */
