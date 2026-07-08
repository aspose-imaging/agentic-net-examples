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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "output.tiff";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                // Define the export rectangle (x, y, width, height)
                var area = new Rectangle(100, 100, 200, 200);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Export only the first page (index 0) and the defined area
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(0, area);

                // Save the selected portion as TIFF
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
 * 1. When a developer needs to extract a defined 200 × 200 pixel region (starting at coordinates 100,100) from a DjVu document and save it as a TIFF file for high‑quality printing or archival.
 * 2. When a C# application must convert only a selected page area of a multi‑page DjVu scan into a TIFF image to embed in a PDF report without processing the entire document.
 * 3. When a document‑management system requires converting a specific rectangular portion of a DjVu file into a TIFF thumbnail for preview generation in a web portal.
 * 4. When a developer wants to isolate a diagram or signature located at a known position within a DjVu file and export it as a lossless TIFF for further analysis or OCR.
 * 5. When an automated workflow needs to batch‑process DjVu files, extracting the same rectangular region from each and storing the results as TIFF images for downstream image‑processing pipelines.
 */