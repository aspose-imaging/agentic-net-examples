using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output directories
        string inputDir = @"C:\Input";
        string outputDir = @"C:\Output";

        // Process fifteen DjVu files named file1.djvu … file15.djvu
        for (int i = 1; i <= 15; i++)
        {
            string inputPath = Path.Combine(inputDir, $"file{i}.djvu");
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDir, $"file{i}.bmp");
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document, apply default dithering, and save as BMP
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Apply default Floyd‑Steinberg dithering with 8‑bit palette
                djvuImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Save the processed image as BMP
                djvuImage.Save(outputPath, new BmpOptions());
            }
        }
    }
}