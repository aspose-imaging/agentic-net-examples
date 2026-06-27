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
            string inputPath = "Input/sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                foreach (Image img in djvu.Pages)
                {
                    using (DjvuPage page = (DjvuPage)img)
                    {
                        // Rotate each page 90 degrees clockwise, resize proportionally, white background
                        page.Rotate(90f, true, Color.White);

                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        page.Save(outputPath, new PngOptions());
                    }
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
 * 1. When a developer needs to display scanned archival documents originally saved as DjVu on a web page that only supports PNG images, they can rotate each page to correct orientation and convert it to PNG.
 * 2. When an e‑learning platform receives multi‑page DjVu lecture notes that are scanned upside‑down, the code can rotate every page 90° clockwise and export them as PNG thumbnails for quick preview.
 * 3. When a digital library wants to generate printable PNG versions of DjVu manuscripts while ensuring the pages are correctly oriented for printing, this routine rotates and saves each page as a high‑quality PNG.
 * 4. When an automated document processing pipeline must extract each page of a DjVu file, apply a standard rotation, and store the results in a PNG folder for downstream OCR analysis, the code provides the needed transformation.
 * 5. When a mobile app needs to cache rotated PNG images of DjVu comic book pages for faster rendering on devices that cannot render DjVu directly, this snippet rotates and converts each page to PNG files.
 */