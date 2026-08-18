// HOW-TO: Convert DjVu To GIF With Floyd Steinberg Dithering In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                DjvuImage djvu = (DjvuImage)image;

                foreach (DjvuPage page in djvu.Pages)
                {
                    page.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);
                }

                GifOptions gifOptions = new GifOptions();
                djvu.Save(outputPath, gifOptions);
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
 * 1. When a web application must display DjVu files in browsers that only support GIF, this code converts each page to a dithered GIF to preserve visual quality.
 * 2. When creating thumbnails or previews of DjVu books for mobile devices, applying Floyd‑Steinberg dithering before saving as GIF reduces file size while keeping detail.
 * 3. When archiving scanned documents and you want a lossless‑looking GIF representation, the code loads each DjVu page, dithers it, and outputs a GIF for easy viewing.
 * 4. When building an e‑learning platform that bundles DjVu lecture notes into GIF slideshows, this routine ensures each slide is dithered for consistent color rendering.
 * 5. When automating batch conversion of DjVu archives to GIF for email distribution, the snippet processes all pages, applies dithering, and saves a single GIF file.
 */
