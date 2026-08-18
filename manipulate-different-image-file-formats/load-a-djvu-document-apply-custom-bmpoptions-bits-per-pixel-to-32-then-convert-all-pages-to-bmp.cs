// HOW-TO: Convert DjVu Document to 32‑Bit BMP Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (will be created for each page as needed)
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Prepare BMP save options with 32 bits per pixel
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 32
                    };

                    // Iterate through each page and save as BMP
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as BMP using the specified options
                        page.Save(outputPath, bmpOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract each page of a multi‑page DjVu file as a high‑color BMP for printing or archival.
 * 2. When a legacy Windows application only accepts 32‑bit BMP files and you must convert scanned DjVu documents for compatibility.
 * 3. When you want to generate bitmap thumbnails from a DjVu ebook to display in a custom viewer built with C#.
 * 4. When processing scientific diagrams stored in DjVu and you require lossless BMP output for further image analysis.
 * 5. When automating a batch workflow that converts scanned contracts in DjVu format to BMP for OCR engines that work best with 32‑bit bitmaps.
 */
