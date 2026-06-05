using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\inverted.pdf";

            // Verify input file exists
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
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Define the full image rectangle
                var rect = new Rectangle(0, 0, raster.Width, raster.Height);

                // Load ARGB pixels
                int[] pixels = raster.LoadArgb32Pixels(rect);

                // Invert colors (preserve alpha)
                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int a = (pixel >> 24) & 0xFF;
                    int rgb = pixel & 0x00FFFFFF;
                    int invRgb = (~rgb) & 0x00FFFFFF;
                    pixels[i] = (a << 24) | invRgb;
                }

                // Save modified pixels back to the image
                raster.SaveArgb32Pixels(rect, pixels);

                // Save the result as PDF
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}