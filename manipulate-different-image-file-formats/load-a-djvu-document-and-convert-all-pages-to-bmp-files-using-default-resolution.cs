using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file and output directory
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the document
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output BMP file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.bmp");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as BMP using default resolution
                        djvuPage.Save(outputPath, new BmpOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a document management system needs to generate thumbnail previews of each page of a DjVu file for a web gallery, a developer can use this code to load the DjVu document and save every page as a BMP image.
 * 2. When an archival workflow requires converting scanned DjVu pages into a lossless bitmap format for further OCR processing, the code demonstrates how to read the DjVu stream and export each page to BMP using C#.
 * 3. When a printing service must rasterize DjVu pages into BMP files at the default resolution before sending them to a legacy printer that only accepts BMP input, this snippet shows the necessary steps.
 * 4. When a desktop application wants to display DjVu content in a Windows Forms picture box that only supports BMP, the developer can load the DjVu file and convert each page to BMP with this example.
 * 5. When a batch conversion tool needs to extract all pages from a multi‑page DjVu archive and store them as separate BMP files for downstream image analysis, the provided code performs the required page iteration and saving.
 */