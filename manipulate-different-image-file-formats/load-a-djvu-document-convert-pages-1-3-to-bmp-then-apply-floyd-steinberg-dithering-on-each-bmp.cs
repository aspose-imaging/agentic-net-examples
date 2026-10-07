// HOW-TO: Convert First Three DjVu Pages to Dithered BMP Images in C# (Aspose.Imaging for .NET)
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
                int pagesToProcess = Math.Min(3, djvu.Pages.Length);
                for (int i = 0; i < pagesToProcess; i++)
                {
                    RasterImage pageImage = (RasterImage)djvu.Pages[i];
                    pageImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                    string bmpPath = Path.Combine(outputDir, $"page_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        pageImage.Save(bmpPath, bmpOptions);
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
 * 1. When you need to extract the first few pages of a DjVu document and save them as BMP files with Floyd‑Steinberg dithering for printing on monochrome devices.
 * 2. When a legacy system only accepts BMP images and you must preprocess scanned DjVu pages to reduce file size while preserving visual detail using dithering.
 * 3. When creating thumbnails for a DjVu‑based e‑book reader that requires BMP output with dithering to improve contrast on low‑color displays.
 * 4. When automating batch conversion of DjVu archives to BMP for archival purposes, applying Floyd‑Steinberg dithering to maintain image quality after color depth reduction.
 * 5. When developing a C# tool that needs to process the first three pages of a multi‑page DjVu file and output dithered BMPs for further analysis in image‑processing pipelines.
 */
