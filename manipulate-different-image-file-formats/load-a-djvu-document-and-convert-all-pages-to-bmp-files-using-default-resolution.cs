using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = @"c:\temp\sample.djvu";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory (same as input directory in this example)
            string outputDir = @"c:\temp\";

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the DjVu document
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build the output BMP file name based on the page number
                        string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.bmp");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a BMP image using default options
                        djvuPage.Save(outputPath, new BmpOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Output any error message without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a document management system receives scanned archives in DjVu format and must generate BMP thumbnails for preview in a Windows application.
 * 2. When a batch processing tool needs to extract each page of a multi‑page DjVu file and save them as BMP images for compatibility with legacy imaging software.
 * 3. When a digital library wants to convert DjVu e‑books into BMP raster files to embed them in a PDF generation pipeline that only accepts BMP inputs.
 * 4. When an OCR workflow requires converting DjVu pages to BMP so that the OCR engine can read the bitmap data without additional format conversion.
 * 5. When a C# desktop utility must validate the integrity of a DjVu file by loading it and saving each page as a BMP to compare against expected raster output.
 */