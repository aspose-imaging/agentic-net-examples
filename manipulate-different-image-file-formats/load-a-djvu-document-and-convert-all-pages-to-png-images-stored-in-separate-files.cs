// HOW-TO: Convert DjVu Document to Separate PNG Files in C# (Aspose.Imaging for .NET)
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
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.MultiPageOptions = new DjvuMultiPageOptions(i);
                    djvu.Save(outputPath, pngOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file as individual PNG images for web publishing or thumbnail generation.
 * 2. When an application must batch‑process scanned DjVu archives and store each page as a lossless PNG for further editing in graphic tools.
 * 3. When a document management system requires conversion of DjVu reports into separate PNG files to display them in browsers that do not support DjVu.
 * 4. When you want to automate the creation of high‑resolution PNG assets from DjVu manuals for inclusion in mobile apps or e‑learning platforms.
 * 5. When a migration script has to move legacy DjVu documents to a PNG‑based workflow, preserving each page as an individual image file.
 */
