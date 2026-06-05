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
        string inputPath = @"C:\Images\sample.djvu";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page and save as BMP with 32 bits per pixel
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as BMP using custom BmpOptions
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 32
                    };
                    page.Save(outputPath, bmpOptions);
                }
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
 * 1. When a developer needs to extract high‑color‑depth bitmap images from a multi‑page DjVu archive for use in a Windows desktop application, they can load the DjVu file and save each page as a 32‑bpp BMP.
 * 2. When a document‑management system must convert scanned DjVu documents into BMP files that preserve full RGBA information for downstream OCR processing, this code provides the required conversion.
 * 3. When a legacy printing workflow only accepts BMP files with 32 bits per pixel, a developer can batch‑convert each page of a DjVu e‑book into BMP to meet the printer’s format constraints.
 * 4. When an image‑analysis pipeline needs to work with uncompressed bitmap data from DjVu pages to apply pixel‑level algorithms in C#, the code loads the DjVu and outputs 32‑bpp BMPs for accurate analysis.
 * 5. When a web service generates thumbnails by first converting DjVu pages to high‑quality BMPs before resizing, this snippet handles the initial conversion while ensuring each BMP uses a 32‑bit color depth.
 */