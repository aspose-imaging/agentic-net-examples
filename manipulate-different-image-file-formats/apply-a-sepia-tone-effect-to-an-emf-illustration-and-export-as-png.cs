using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.png";
        string tempPath = "temp.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Ensure temporary file directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        // Rasterize EMF to a temporary PNG
        using (Image emfImage = Image.Load(inputPath))
        {
            // Configure rasterization options
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = emfImage.Size
            };

            // Set PNG options with vector rasterization
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized image to temporary PNG
            emfImage.Save(tempPath, pngOptions);
        }

        // Apply sepia tone to the rasterized image and save final PNG
        using (RasterImage raster = (RasterImage)Image.Load(tempPath))
        {
            // Load ARGB pixels
            int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

            // Apply sepia transformation
            for (int i = 0; i < pixels.Length; i++)
            {
                int pixel = pixels[i];
                int a = (pixel >> 24) & 0xFF;
                int r = (pixel >> 16) & 0xFF;
                int g = (pixel >> 8) & 0xFF;
                int b = pixel & 0xFF;

                int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                r = tr > 255 ? 255 : tr;
                g = tg > 255 ? 255 : tg;
                b = tb > 255 ? 255 : tb;

                pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
            }

            // Save modified pixels back
            raster.SaveArgb32Pixels(raster.Bounds, pixels);

            // Save final PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}