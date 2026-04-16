using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = Path.Combine("Input", "sample.bmp");
        string outputPath = Path.Combine("Output", "inverted.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel manipulation
            RasterImage raster = (RasterImage)image;
            if (!raster.IsCached)
                raster.CacheData();

            // Load ARGB pixels
            int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

            // Invert colors (preserve alpha)
            for (int i = 0; i < pixels.Length; i++)
            {
                int argb = pixels[i];
                int a = argb & unchecked((int)0xFF000000);
                int rgb = argb & 0x00FFFFFF;
                int invRgb = (~rgb) & 0x00FFFFFF;
                pixels[i] = a | invRgb;
            }

            // Save inverted pixels back to the image
            raster.SaveArgb32Pixels(raster.Bounds, pixels);

            // Embed the inverted image into a PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}