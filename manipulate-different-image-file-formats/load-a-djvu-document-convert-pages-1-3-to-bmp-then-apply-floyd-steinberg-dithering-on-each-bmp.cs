using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.djvu";
            string outputDir = @"C:\temp\output";

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

                // Iterate over pages 1‑3
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    if (page.PageNumber < 1 || page.PageNumber > 3)
                        continue;

                    // Apply Floyd‑Steinberg dithering with 1‑bit palette
                    page.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1);

                    // Prepare output file path
                    string outputPath = Path.Combine(outputDir, $"page{page.PageNumber}.bmp");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as BMP
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