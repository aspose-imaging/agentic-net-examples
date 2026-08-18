// HOW-TO: Convert First Three DjVu Pages to Dithered BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = "sample.djvu";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DjVu document
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var djvuImage = (DjvuImage)image;
                int pagesToProcess = Math.Min(3, djvuImage.PageCount);

                for (int i = 0; i < pagesToProcess; i++)
                {
                    var page = (DjvuPage)djvuImage.Pages[i];

                    // Apply Floyd‑Steinberg dithering with 1‑bit palette
                    page.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Define output BMP file path
                    string outputPath = Path.Combine("output", $"page{i + 1}.bmp");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the dithered page as BMP
                    page.Save(outputPath, new BmpOptions());
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
 * 1. When you need to extract the first few pages of a DjVu document and save them as BMP files for legacy systems that only support BMP.
 * 2. When you want to reduce the color depth of DjVu pages to 1‑bit using Floyd‑Steinberg dithering for printing on monochrome printers.
 * 3. When you are building a batch conversion tool that processes DjVu archives and creates low‑size BMP thumbnails for quick preview.
 * 4. When you must ensure consistent output by creating a dedicated output folder and handling missing input files gracefully in a C# application.
 * 5. When you are integrating Aspose.Imaging into a document‑processing pipeline that requires page‑by‑page manipulation and custom dithering before further analysis.
 */
