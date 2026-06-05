using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.djvu";
            string outputPath = "output/output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Define the export rectangle (x, y, width, height)
                Rectangle exportRect = new Rectangle(100, 100, 200, 200);

                // Export only the first page (index 0) with the specified area
                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(0, exportRect);
                tiffOptions.MultiPageOptions = multiPageOptions;

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
 * 1. When a legal firm needs to extract a specific page region from a scanned DjVu contract and store it as a high‑resolution TIFF for archival or e‑discovery purposes.
 * 2. When a publishing company wants to generate a thumbnail TIFF of a selected illustration area inside a multi‑page DjVu manuscript for preview in an online catalog.
 * 3. When a medical records system must isolate a diagnostic image region from a DjVu scan and convert it to TIFF to comply with DICOM‑compatible image workflows.
 * 4. When a GIS analyst extracts a defined map segment from a DjVu file and saves it as a TIFF to overlay on other spatial data layers.
 * 5. When an educational platform needs to crop a particular diagram from a DjVu textbook page and convert it to TIFF for inclusion in printable study guides.
 */