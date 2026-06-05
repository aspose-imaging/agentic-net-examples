using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Set up vector rasterization options
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size
                };

                // Configure PNG options with vector rasterization
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save EMF as PNG (rasterized)
                emfImage.Save(outputPath, pngOptions);
            }

            // Load the generated PNG to adjust opacity
            using (RasterImage raster = (RasterImage)Image.Load(outputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                var rect = new Rectangle(0, 0, width, height);

                // Load ARGB pixels
                int[] pixels = raster.LoadArgb32Pixels(rect);

                // Adjust alpha to 80% (204 out of 255)
                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int alpha = (pixel >> 24) & 0xFF;
                    int newAlpha = (int)(alpha * 0.8);
                    if (newAlpha > 255) newAlpha = 255;
                    pixels[i] = (newAlpha << 24) | (pixel & 0x00FFFFFF);
                }

                // Save modified pixels back
                raster.SaveArgb32Pixels(rect, pixels);
                raster.Save();
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
 * 1. When a developer needs to convert a vector‑based EMF logo into a semi‑transparent PNG for use as an overlay on web pages or marketing materials.
 * 2. When a software solution must rasterize technical drawings from EMF files and reduce line opacity to 80 % so they appear as subtle background guides in a reporting dashboard.
 * 3. When an application generates printable PDFs and requires EMF charts to be saved as PNG images with reduced opacity to act as watermarks without obscuring underlying content.
 * 4. When a UI designer wants to create scalable icons from EMF assets and apply 80 % line transparency before embedding the PNGs into a Windows Forms or WPF application.
 * 5. When a document‑processing pipeline needs to batch‑process EMF diagrams, rasterize them to PNG, and uniformly lower the alpha channel to 80 % for consistent visual styling across all generated assets.
 */