// HOW-TO: Convert DjVu Document Pages To PNG Images In C# (Aspose.Imaging for .NET)
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
            string inputPath = "sample.djvu";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvuImage.Pages.Length; i++)
                {
                    var page = djvuImage.Pages[i];
                    string outputPath = $"output/page_{i + 1}.png";

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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as separate PNG files for web preview or further image processing.
 * 2. When an application must automate conversion of scanned documents stored in DjVu format into high‑resolution PNGs for inclusion in a digital archive.
 * 3. When a document management system requires converting DjVu pages to PNG thumbnails to display preview images in a user interface.
 * 4. When you are building a batch‑processing tool that reads DjVu files and outputs PNGs for each page to integrate with downstream graphics workflows.
 * 5. When you need to programmatically verify the existence of a DjVu file and generate PNG copies of its pages using Aspose.Imaging in a C# backend service.
 */
