// HOW-TO: Extract a 400x400 Region From DjVu and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Define the rectangle area to extract (x, y, width, height)
                Rectangle exportArea = new Rectangle(0, 0, 400, 400);

                // Set BMP save options (default options are sufficient)
                BmpOptions bmpOptions = new BmpOptions();

                // Save the specified portion as BMP
                djvuImage.Save(outputPath, bmpOptions, exportArea);
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
 * 1. When you need to generate a thumbnail of the first page of a DjVu document for a web preview, this code extracts a 400 × 400 area and saves it as a BMP file.
 * 2. When you want to extract a specific area of a scanned map stored in DjVu to embed in a report as a BMP image, this snippet crops the defined rectangle and writes it out.
 * 3. When converting a portion of a multi‑page DjVu file to BMP for OCR preprocessing, the code isolates the region and saves it in a bitmap format compatible with OCR engines.
 * 4. When creating a bitmap asset from a DjVu illustration to use in a Windows Forms application, the example loads the DjVu, crops the desired region, and outputs a BMP.
 * 5. When automating batch processing to crop and save sections of DjVu files as BMP for archival purposes, this routine provides a simple C# solution to extract and store each region.
 */
