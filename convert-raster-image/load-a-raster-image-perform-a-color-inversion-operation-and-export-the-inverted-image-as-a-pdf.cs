using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.png";
        string outputPath = "Output\\inverted.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel manipulation
            RasterImage raster = (RasterImage)image;

            // Cache data if not already cached
            if (!raster.IsCached)
                raster.CacheData();

            // Define the full image rectangle
            var rect = new Rectangle(0, 0, raster.Width, raster.Height);

            // Load ARGB pixels
            int[] pixels = raster.LoadArgb32Pixels(rect);

            // Invert colors (preserve alpha)
            for (int i = 0; i < pixels.Length; i++)
            {
                int argb = pixels[i];
                int a = (argb >> 24) & 0xFF;
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;

                int invR = 255 - r;
                int invG = 255 - g;
                int invB = 255 - b;

                pixels[i] = (a << 24) | (invR << 16) | (invG << 8) | invB;
            }

            // Write the modified pixels back to the image
            raster.SaveArgb32Pixels(rect, pixels);

            // Save the inverted image as PDF
            using (var pdfOptions = new PdfOptions())
            {
                raster.Save(outputPath, pdfOptions);
            }
        }
    }
}