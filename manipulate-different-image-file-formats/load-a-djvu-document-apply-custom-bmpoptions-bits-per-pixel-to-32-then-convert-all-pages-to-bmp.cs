using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine("output", $"page_{page.PageNumber}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions bmpOptions = new BmpOptions();
                    bmpOptions.BitsPerPixel = 32;

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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and save them as high‑color‑depth 32‑bit BMP files for archival or printing purposes.
 * 2. When an application must convert scanned DjVu files into BMP images to feed legacy Windows graphics tools that only accept BMP input.
 * 3. When a batch‑processing service has to read DjVu files from a stream, apply custom BmpOptions with 32 bits per pixel, and generate separate BMP files for each page for downstream OCR processing.
 * 4. When a digital library system wants to provide thumbnail previews of DjVu pages by converting them to BMP format with full color fidelity using Aspose.Imaging for .NET.
 * 5. When a developer is implementing a file‑format migration tool that reads DjVu documents, iterates through all pages, and saves them as BMP images with a specified BitsPerPixel setting to ensure consistent image quality across platforms.
 */