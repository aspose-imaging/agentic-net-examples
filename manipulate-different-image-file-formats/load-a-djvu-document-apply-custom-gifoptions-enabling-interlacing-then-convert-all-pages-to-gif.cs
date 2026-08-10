// HOW-TO: Convert DjVu Pages to Interlaced GIF Images in C# (Aspose.Imaging for .NET)
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

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.PageCount; i++)
                {
                    string outputPath = $"Output/page{i + 1}.gif";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };

                    Image page = djvu.Pages[i];
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
 * 1. When you need to extract each page of a multi‑page DjVu document and save them as web‑optimized interlaced GIF files for faster progressive loading.
 * 2. When converting scanned archival DjVu files into GIF images while preserving page separation for use in web galleries.
 * 3. When generating thumbnail previews of DjVu pages in GIF format with interlacing to improve visual quality on low‑bandwidth connections.
 * 4. When automating a batch process that transforms DjVu manuals into individual GIF images for inclusion in e‑learning platforms.
 * 5. When integrating Aspose.Imaging in a C# application to programmatically render DjVu pages as interlaced GIFs for downstream image processing pipelines.
 */
