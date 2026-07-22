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
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    page.Save(outputPath, new PngOptions());
                    pageIndex++;
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and generate high‑resolution PNG thumbnails for a web preview gallery.
 * 2. When an archival system must convert scanned DjVu files into lossless PNG images to preserve visual fidelity while enabling downstream image processing.
 * 3. When a digital publishing workflow requires batch conversion of DjVu chapters into PNG assets that can be embedded in e‑books or online articles.
 * 4. When a document management application needs to programmatically read DjVu files in C# and store each page as a separate PNG file for indexing and search.
 * 5. When a developer wants to automate the transformation of DjVu manuals into PNG images that can be annotated with XMP metadata for compliance tracking.
 */