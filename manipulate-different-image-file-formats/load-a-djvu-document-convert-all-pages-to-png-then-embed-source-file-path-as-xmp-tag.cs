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
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract each page of a multi‑page DjVu file (such as a scanned magazine) and save them as separate PNG images for inclusion in a digital archive.
 * 2. When an application must generate thumbnail previews of DjVu documents on the fly by converting each page to PNG format for display in a file‑manager UI.
 * 3. When a document‑processing pipeline requires converting DjVu pages to lossless PNG files before applying OCR or further image analysis in C#.
 * 4. When a web service needs to serve DjVu content to browsers that only support PNG, so the server converts all pages to PNG files on demand.
 * 5. When a developer automates batch conversion of a folder of DjVu files into PNG pages to prepare assets for a mobile app that only accepts PNG images.
 */