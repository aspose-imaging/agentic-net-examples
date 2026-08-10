// HOW-TO: Extract a Rectangle from DjVu and Save as TIFF in C# (Aspose.Imaging for .NET)
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Define the rectangle area to extract (x, y, width, height)
            var area = new Rectangle(100, 100, 200, 200);

            // Configure TIFF save options with DjvuMultiPageOptions for page 0 and the defined area
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                MultiPageOptions = new DjvuMultiPageOptions(0, area)
            };

            // Load the DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Save the specified portion as a TIFF file
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
 * 1. When a developer needs to extract a specific region of a scanned DjVu document for inclusion in a report, they can crop the area and convert it to a high‑resolution TIFF file using C#.
 * 2. When building a document‑processing pipeline that isolates logos or signatures located at known coordinates in DjVu files, this code lets you programmatically capture that rectangle and store it as a TIFF image.
 * 3. When integrating legacy DjVu archives with modern imaging systems that require TIFF input, developers can select a page and region to convert without loading the entire document.
 * 4. When creating thumbnails or preview images of a particular section of a DjVu map or blueprint, the snippet can be extracted and saved as a TIFF for further editing.
 * 5. When automating quality‑control checks that compare a defined area of a DjVu page against a reference TIFF, this snippet provides the exact cropping and format conversion needed.
 */
