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
            string inputPath = "sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

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
 * 1. When a digital archive needs to preserve scanned DjVu documents as lossless PNG images while adding the original file path as an XMP metadata tag for traceability.
 * 2. When an e‑learning platform converts multi‑page DjVu lecture notes into separate PNG slides for web display and embeds the source path to link back to the original material.
 * 3. When a legal firm extracts each page of a DjVu case file into PNG thumbnails for quick preview in a document management system and stores the source location in XMP for audit purposes.
 * 4. When a publishing workflow automates the transformation of DjVu manuscripts into PNG assets for print‑ready pipelines, embedding the source path to maintain version control.
 * 5. When a mobile app pre‑processes DjVu comics by converting each page to PNG and tagging the images with the original file path in XMP so the app can reference the source during offline viewing.
 */