using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\multipage.tif";
            string outputPath = @"C:\Images\page2.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multipage TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options to export only the second page (index 1)
                PngOptions pngOptions = new PngOptions
                {
                    MultiPageOptions = new MultiPageOptions(new int[] { 1 })
                };

                // Save the selected page as a PNG file
                image.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging system stores patient scans as multipage TIFFs and needs to extract the second slice as a PNG for quick preview in a web portal.
 * 2. When a document management workflow receives scanned contracts as multipage TIFF files and must generate a PNG thumbnail of the second page for indexing in a search engine.
 * 3. When a GIS application captures satellite imagery in a multipage TIFF and wants to convert only the second band to PNG for analysis in a C# data pipeline.
 * 4. When an e‑commerce platform receives product catalogs as multipage TIFFs and needs to display the second page as a PNG image on a mobile app.
 * 5. When an archival system processes historical newspapers stored as multipage TIFFs and extracts the second page as a PNG for OCR processing in a .NET service.
 */