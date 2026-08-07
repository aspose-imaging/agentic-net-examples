using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (TgaImage image = new TgaImage(inputPath))
            {
                int width = image.Width;
                int height = image.Height;

                // Center of the image
                double cx = width / 2.0;
                double cy = height / 2.0;

                // Maximum distance from center to a corner
                double maxDist = Math.Sqrt(cx * cx + cy * cy);

                // Apply a simple vignette by darkening pixels based on distance from center
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int argb = image.GetArgb32Pixel(x, y);

                        byte a = (byte)((argb >> 24) & 0xFF);
                        byte r = (byte)((argb >> 16) & 0xFF);
                        byte g = (byte)((argb >> 8) & 0xFF);
                        byte b = (byte)(argb & 0xFF);

                        double dx = x - cx;
                        double dy = y - cy;
                        double dist = Math.Sqrt(dx * dx + dy * dy);

                        // Vignette factor: 1.0 at center, decreasing towards edges
                        double factor = 1.0 - 0.5 * (dist / maxDist);
                        if (factor < 0.5) factor = 0.5; // clamp to avoid excessive darkening

                        r = (byte)(r * factor);
                        g = (byte)(g * factor);
                        b = (byte)(b * factor);

                        int newArgb = (a << 24) | (r << 16) | (g << 8) | b;
                        image.SetArgb32Pixel(x, y, newArgb);
                    }
                }

                // Save the processed image as JPEG
                image.Save(outputPath, new JpegOptions());
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
 * 1. When a game developer wants to convert high‑resolution TGA textures into web‑friendly JPEGs with a subtle vignette to focus player attention on the center of the sprite.
 * 2. When a digital artist needs to batch‑process TGA screenshots from a rendering pipeline, adding a darkened border effect and exporting them as JPEGs for portfolio presentation.
 * 3. When an e‑commerce platform receives product images in TGA format from manufacturers and wants to apply a vignette for a professional look before storing them as JPEG thumbnails.
 * 4. When a scientific imaging application must reduce file size of TGA microscopy images while emphasizing the region of interest by applying a vignette and saving the result as JPEG.
 * 5. When a mobile app developer prepares TGA assets for an iOS app, using C# and Aspose.Imaging to add a vignette effect and convert the files to JPEG for faster loading on devices.
 */