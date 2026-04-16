using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // For raster image types if needed

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"input.png";
        string outputPdfPath = @"output.pdf";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load the raster image
        using (Image img = Image.Load(inputPath))
        {
            // Cast to RasterImage to access pixel‑level methods
            RasterImage raster = img as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("The loaded image is not a raster image.");
                return;
            }

            // Invert colors pixel by pixel
            for (int y = 0; y < raster.Height; y++)
            {
                for (int x = 0; x < raster.Width; x++)
                {
                    int argb = raster.GetArgb32Pixel(x, y);
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;

                    int invR = 255 - r;
                    int invG = 255 - g;
                    int invB = 255 - b;

                    int invArgb = (a << 24) | (invR << 16) | (invG << 8) | invB;
                    raster.SetArgb32Pixel(x, y, invArgb);
                }
            }

            // Save the inverted image directly as a PDF
            raster.Save(outputPdfPath);
        }
    }
}