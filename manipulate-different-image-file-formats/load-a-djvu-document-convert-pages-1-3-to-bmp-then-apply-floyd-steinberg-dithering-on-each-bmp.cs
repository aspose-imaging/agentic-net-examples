using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDir = "output";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load DjVu document
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                DjvuImage djvu = (DjvuImage)image;

                // Process pages 1‑3 (indices 0‑2)
                int pagesToProcess = Math.Min(3, djvu.Pages.Length);
                for (int i = 0; i < pagesToProcess; i++)
                {
                    DjvuPage page = (DjvuPage)djvu.Pages[i];

                    // Apply Floyd‑Steinberg dithering with 1‑bit palette
                    page.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Prepare output BMP path
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.bmp");

                    // Ensure output directory for the file exists
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