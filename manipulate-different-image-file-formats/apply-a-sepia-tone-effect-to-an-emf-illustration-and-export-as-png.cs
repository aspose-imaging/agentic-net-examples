using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Prepare PNG save options with rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Color.White // optional background
                    }
                };

                // Save the EMF as a raster PNG (temporary file)
                string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                emfImage.Save(tempPngPath, pngOptions);

                // Load the raster PNG for pixel manipulation
                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    // Apply sepia tone to each pixel
                    for (int y = 0; y < raster.Height; y++)
                    {
                        for (int x = 0; x < raster.Width; x++)
                        {
                            Color original = raster.GetPixel(x, y);
                            double r = original.R;
                            double g = original.G;
                            double b = original.B;

                            int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                            int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                            int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                            tr = Math.Min(255, tr);
                            tg = Math.Min(255, tg);
                            tb = Math.Min(255, tb);

                            raster.SetPixel(x, y, Color.FromArgb(original.A, (byte)tr, (byte)tg, (byte)tb));
                        }
                    }

                    // Save the final sepia PNG to the desired output path
                    raster.Save(outputPath, new PngOptions());
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
                }
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
 * 1. When a developer needs to convert a vector EMF logo into a web‑friendly PNG thumbnail with a vintage sepia look for a marketing website.
 * 2. When an application must generate printable reports that embed EMF charts but require a sepia‑toned PNG version for archival or branding consistency.
 * 3. When a desktop tool processes legacy EMF icons and outputs sepia‑styled PNG assets for use in a themed UI skin.
 * 4. When an automated pipeline transforms EMF diagrams into PNG images with a sepia filter to match a corporate retro visual style before publishing to a documentation portal.
 * 5. When a C# service rasterizes EMF drawings, applies pixel‑level color manipulation, and saves the result as a sepia PNG for inclusion in email newsletters.
 */