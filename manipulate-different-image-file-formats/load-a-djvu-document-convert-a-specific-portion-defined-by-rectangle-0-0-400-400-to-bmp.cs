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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.djvu";
            string outputPath = @"C:\temp\output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the DjVu file stream and load the image
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Define the rectangle area to extract (0,0,400,400)
                var exportRect = new Aspose.Imaging.Rectangle(0, 0, 400, 400);

                // Set BMP save options
                BmpOptions bmpOptions = new BmpOptions();

                // Save the specified portion as a BMP file
                djvuImage.Save(outputPath, bmpOptions, exportRect);
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
 * 1. When a developer needs to generate a thumbnail preview of the first page of a scanned DjVu document for a web gallery, they can extract the top‑left 400×400 pixels and save it as a BMP image.
 * 2. When integrating a document management system that stores legacy DjVu files, a developer can use this code to pull a specific region of a page for OCR preprocessing by converting that region to BMP.
 * 3. When creating a print‑ready raster version of a selected area of a multi‑page DjVu file for a desktop publishing workflow, the code extracts the defined rectangle and outputs a BMP that can be imported into layout software.
 * 4. When building a digital archiving tool that needs to compare visual sections of DjVu scans against reference images, a developer can extract the same 400×400 pixel area and save it as BMP for pixel‑by‑pixel analysis.
 * 5. When developing a Windows application that allows users to select a portion of a DjVu map and export it for offline use, the code can capture the chosen rectangle and store it as a BMP file for easy viewing on any device.
 */