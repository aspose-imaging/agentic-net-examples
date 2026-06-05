using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image emfImage = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = emfImage.Width,
                    PageHeight = emfImage.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                emfImage.Save(outputPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(outputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                var rect = new Aspose.Imaging.Rectangle(0, 0, width, height);

                int[] pixels = raster.LoadArgb32Pixels(rect);

                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    byte a = (byte)((argb >> 24) & 0xFF);
                    byte b = (byte)(argb & 0xFF);
                    byte g = (byte)((argb >> 8) & 0xFF);
                    byte r = (byte)((argb >> 16) & 0xFF);

                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    tr = tr > 255 ? 255 : tr;
                    tg = tg > 255 ? 255 : tg;
                    tb = tb > 255 ? 255 : tb;

                    pixels[i] = (a << 24) | (tr << 16) | (tg << 8) | tb;
                }

                raster.SaveArgb32Pixels(rect, pixels);
                raster.Save(outputPath);
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
 * 1. When a developer needs to convert legacy EMF vector illustrations into web‑ready PNG thumbnails with a nostalgic sepia tone for an online archive.
 * 2. When a reporting tool must embed stylized EMF charts into PDF or HTML reports and requires the images to be pre‑processed to sepia before saving as PNG for consistent branding.
 * 3. When an e‑learning platform wants to display historical engineering drawings stored as EMF with a sepia filter to match a vintage lesson theme, exporting them as PNG for fast loading.
 * 4. When a desktop application automates batch processing of EMF icons, applying a sepia effect and saving them as PNG files to create a cohesive UI skin.
 * 5. When a digital asset management system ingests vector EMF assets, applies sepia tone for preview generation, and stores the resulting PNGs for quick preview rendering.
 */