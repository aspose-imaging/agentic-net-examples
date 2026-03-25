using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = "Input";
        string outputDir = "Output";

        // Ensure directories exist
        Directory.CreateDirectory(inputDir);
        Directory.CreateDirectory(outputDir);

        // Process all BMP files in the input directory
        string[] files = Directory.GetFiles(inputDir, "*.bmp");
        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output PDF path
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                    raster.CacheData();

                // Load ARGB pixels
                var rect = raster.Bounds;
                int[] argbPixels = raster.LoadArgb32Pixels(rect);

                // Apply a simple color matrix (increase red channel by 20%)
                for (int i = 0; i < argbPixels.Length; i++)
                {
                    int pixel = argbPixels[i];
                    int a = (pixel >> 24) & 0xFF;
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;

                    // Increase red channel
                    int newR = (int)(r * 1.2);
                    if (newR > 255) newR = 255;

                    // Recompose pixel
                    argbPixels[i] = (a << 24) | (newR << 16) | (g << 8) | b;
                }

                // Save modified pixels back to the image
                raster.SaveArgb32Pixels(rect, argbPixels);

                // Save the transformed image as PDF
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}