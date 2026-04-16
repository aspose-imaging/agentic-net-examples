using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel manipulation
            RasterImage raster = (RasterImage)image;

            // Apply a simple invert color filter
            for (int y = 0; y < raster.Height; y++)
            {
                for (int x = 0; x < raster.Width; x++)
                {
                    Color original = raster.GetPixel(x, y);
                    Color inverted = Color.FromArgb(
                        original.A,
                        255 - original.R,
                        255 - original.G,
                        255 - original.B);
                    raster.SetPixel(x, y, inverted);
                }
            }

            // Save the filtered image as PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}