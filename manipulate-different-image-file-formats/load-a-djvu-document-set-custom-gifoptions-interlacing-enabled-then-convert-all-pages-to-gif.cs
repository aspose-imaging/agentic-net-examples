// HOW-TO: Convert DjVu Document Pages to Interlaced GIF Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "document.djvu");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    using (RasterImage pageImage = (RasterImage)djvu.Pages[i])
                    {
                        string outputPath = Path.Combine("Output", $"page_{i + 1}.gif");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        GifOptions gifOptions = new GifOptions
                        {
                            Interlaced = true
                        };

                        pageImage.Save(outputPath, gifOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file and create web‑friendly interlaced GIFs for faster progressive loading.
 * 2. When a digital archive requires converting scanned DjVu documents into animated‑compatible GIF frames while preserving page quality.
 * 3. When building a C# application that generates thumbnail previews of DjVu pages as interlaced GIFs for email attachments.
 * 4. When migrating legacy DjVu manuals to a format that can be displayed on browsers without plug‑ins by saving each page as an interlaced GIF.
 * 5. When automating a batch process that reads DjVu files and outputs interlaced GIFs for use in slide shows or presentations.
 */
