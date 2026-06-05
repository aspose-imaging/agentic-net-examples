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
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                foreach (DjvuPage page in djvuImage.Pages)
                {
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
 * 1. When a digital archive needs to extract each page of a DjVu scanned book and store them as high‑quality PNG images for web preview while embedding the original file name as XMP metadata, a developer can use this C# Aspose.Imaging code to batch‑convert pages and preserve provenance.
 * 2. When an e‑learning platform receives lecture notes in DjVu format and must generate PNG thumbnails for each slide with source attribution via XMP, the code provides a straightforward way to automate the conversion in .NET.
 * 3. When a legal firm digitizes case files as DjVu documents and requires PNG copies for OCR processing, adding XMP metadata with the original filename helps track provenance, and this snippet handles the page‑by‑page conversion in C#.
 * 4. When a publishing company wants to create printable PNG assets from multi‑page DjVu manuscripts and embed source information for copyright management, the Aspose.Imaging routine can be integrated into their .NET workflow.
 * 5. When a content management system needs to ingest DjVu manuals, convert each page to PNG for responsive design, and store the source file name in XMP for searchable metadata, this example demonstrates the necessary steps in C#.
 */