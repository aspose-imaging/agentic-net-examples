using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\Inverted.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel access
            var raster = (RasterImage)image;

            // Invert colors pixel by pixel
            for (int y = 0; y < raster.Height; y++)
            {
                for (int x = 0; x < raster.Width; x++)
                {
                    // Get current ARGB value
                    int argb = raster.GetArgb32Pixel(x, y);

                    // Extract components
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;

                    // Invert RGB channels
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    // Reassemble ARGB
                    int invertedArgb = (a << 24) | (r << 16) | (g << 8) | b;

                    // Set the inverted pixel back
                    raster.SetArgb32Pixel(x, y, invertedArgb);
                }
            }

            // Save the inverted image directly as a PDF
            var pdfOptions = new PdfOptions(); // Aspose.Imaging PDF export options
            raster.Save(outputPath, pdfOptions);
        }
    }
}