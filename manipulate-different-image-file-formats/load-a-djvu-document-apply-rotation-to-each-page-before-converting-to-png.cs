using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.djvu";
        string outputDirectory = "Output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Rotate each page 90 degrees clockwise, resize proportionally, white background
                    page.Rotate(90f, true, Color.White);

                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    page.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document, rotate it for proper orientation, and save it as a high‑quality PNG for web preview.
 * 2. When an archival system must convert scanned DjVu files into PNG thumbnails while correcting a 90‑degree clockwise rotation caused by scanner misalignment.
 * 3. When a digital publishing workflow requires batch processing of DjVu e‑books to generate page‑by‑page PNG images with a white background for inclusion in a PDF or EPUB.
 * 4. When a document management application needs to programmatically read a DjVu file, rotate each page, and store the results as PNG files for downstream OCR processing.
 * 5. When a C# service must automate the conversion of DjVu lecture notes into PNG images with consistent orientation and background to ensure compatibility with mobile viewing apps.
 */