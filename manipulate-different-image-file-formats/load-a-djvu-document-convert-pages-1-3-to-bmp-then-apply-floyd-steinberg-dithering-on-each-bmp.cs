using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file path
        string inputPath = @"C:\Images\sample.djvu";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DjVu file stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load DjVu document
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Process pages 1‑3 (indices 0‑2)
                int pagesToProcess = Math.Min(3, djvuImage.PageCount);
                for (int i = 0; i < pagesToProcess; i++)
                {
                    // Build output BMP file path
                    string outputPath = $@"C:\Images\output\page{i + 1}.bmp";

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Retrieve the specific page
                    DjvuPage page = (DjvuPage)djvuImage.Pages[i];

                    // Apply Floyd‑Steinberg dithering with 1‑bit palette (black & white)
                    page.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                    // Save the dithered page as BMP
                    page.Save(outputPath, new BmpOptions());
                }
            }
        }
    }
}