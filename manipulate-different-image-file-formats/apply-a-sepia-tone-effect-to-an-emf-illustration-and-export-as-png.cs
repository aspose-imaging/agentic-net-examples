// HOW-TO: Apply Sepia Tone to EMF Image and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF illustration and rasterize to a temporary PNG
            using (Aspose.Imaging.Image emfImage = Aspose.Imaging.Image.Load(inputPath))
            {
                string tempPath = "temp.png";

                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Source = new FileCreateSource(tempPath, false)
                };

                emfImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG and apply sepia tone
            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load("temp.png"))
            {
                var bounds = raster.Bounds;
                int[] pixels = raster.LoadArgb32Pixels(bounds);

                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    byte a = (byte)(argb >> 24);
                    byte r = (byte)(argb >> 16);
                    byte g = (byte)(argb >> 8);
                    byte b = (byte)(argb);

                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    r = (byte)(tr > 255 ? 255 : tr);
                    g = (byte)(tg > 255 ? 255 : tg);
                    b = (byte)(tb > 255 ? 255 : tb);

                    pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }

                raster.SaveArgb32Pixels(bounds, pixels);

                var finalOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, finalOptions);
            }

            // Clean up temporary file
            if (File.Exists("temp.png"))
            {
                File.Delete("temp.png");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a vector EMF illustration to a web‑friendly PNG with a vintage sepia look.
 * 2. When generating printable reports that require EMF graphics to be displayed with a sepia filter for branding.
 * 3. When creating thumbnails of EMF icons with a sepia effect for a mobile app’s dark theme.
 * 4. When processing legacy EMF assets in a batch job to produce sepia‑toned PNGs for archival purposes.
 * 5. When integrating image transformation in a C# service that receives EMF files and returns sepia‑styled PNG responses.
 */
