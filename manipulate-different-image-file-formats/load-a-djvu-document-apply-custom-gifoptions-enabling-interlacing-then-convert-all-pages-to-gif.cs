// HOW-TO: Convert DjVu Pages to Interlaced GIF Images in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    var page = djvu.Pages[i];
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.gif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };
                    page.Save(outputPath, gifOptions);
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
 * 1. When you need to extract every page from a multi‑page DjVu file and save them as interlaced GIFs for progressive display on websites.
 * 2. When a C# service processes uploaded DjVu manuals and converts each page to GIF format with interlacing to reduce perceived loading time.
 * 3. When you are building a document preview feature that generates lightweight GIF thumbnails from DjVu pages using Aspose.Imaging.
 * 4. When migrating legacy DjVu archives to a format supported by older browsers, converting each page to an interlaced GIF for compatibility.
 * 5. When automating batch conversion of DjVu slideshows into GIF images that can be embedded in email newsletters without requiring external plugins.
 */
