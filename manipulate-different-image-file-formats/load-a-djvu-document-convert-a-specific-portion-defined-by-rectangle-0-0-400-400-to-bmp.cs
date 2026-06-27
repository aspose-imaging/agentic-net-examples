using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputPath = "output.bmp";

        try
        {
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
                // Define the rectangle area to extract (0,0,400,400)
                Rectangle bounds = new Rectangle(0, 0, 400, 400);

                // Set BMP save options
                BmpOptions bmpOptions = new BmpOptions();

                // Save the specified portion as BMP
                djvuImage.Save(outputPath, bmpOptions, bounds);
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
 * 1. When a developer needs to generate a thumbnail preview of the first page of a DjVu file for a web gallery, they can extract the top‑left 400×400 pixels and save it as a BMP using Aspose.Imaging for .NET.
 * 2. When integrating a document‑management system that stores scanned books as DjVu, a developer can quickly convert a specific region of a page to BMP for OCR preprocessing.
 * 3. When building a legacy Windows application that only accepts BMP images, a developer can crop a defined rectangle from a DjVu source and convert it to BMP for compatibility.
 * 4. When creating a batch‑processing tool that extracts a fixed‑size region from multiple DjVu files for quality‑control screenshots, the code can load each file, slice the (0,0,400,400) area, and output BMP files.
 * 5. When implementing a digital‑archive migration script that needs to preserve a preview image of each DjVu document, a developer can use this C# snippet to read the DjVu stream, select a 400×400 rectangle, and store it as a BMP thumbnail.
 */