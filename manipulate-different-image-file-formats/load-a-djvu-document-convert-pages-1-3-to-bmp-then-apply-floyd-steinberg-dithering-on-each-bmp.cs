using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.djvu";
        string outputFolder = @"C:\Images\Output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the DjVu document
        using (Image image = Image.Load(inputPath))
        {
            DjvuImage djvuImage = (DjvuImage)image;

            // Process pages 1‑3 (index 0‑2)
            for (int i = 0; i < 3 && i < djvuImage.Pages.Length; i++)
            {
                // Retrieve the page
                DjvuPage djvuPage = (DjvuPage)djvuImage.Pages[i];

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                djvuPage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Build output file path
                string outputPath = Path.Combine(outputFolder, $"page{i + 1}.bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the dithered page as BMP
                djvuPage.Save(outputPath, new BmpOptions());
            }
        }
    }
}