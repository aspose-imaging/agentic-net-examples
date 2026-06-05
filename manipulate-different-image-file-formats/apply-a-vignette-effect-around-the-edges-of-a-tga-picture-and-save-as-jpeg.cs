using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tga";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;
                int minDim = Math.Min(width, height);

                Graphics graphics = new Graphics(image);

                // Apply concentric ellipses with increasing opacity to simulate a vignette effect
                for (int i = 0; i < 5; i++)
                {
                    int inset = i * (minDim / 20);
                    int ellipseWidth = width - 2 * inset;
                    int ellipseHeight = height - 2 * inset;
                    if (ellipseWidth <= 0 || ellipseHeight <= 0) break;

                    byte opacity = (byte)(30 + i * 40); // increase opacity for outer ellipses
                    SolidBrush brush = new SolidBrush(Color.FromArgb(opacity, 0, 0, 0));
                    graphics.FillEllipse(brush, inset, inset, ellipseWidth, ellipseHeight);
                }

                JpegOptions jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When a game developer needs to convert legacy TGA textures to web‑friendly JPEGs while adding a subtle vignette to focus the viewer’s attention.
 * 2. When a photo‑editing application must batch‑process high‑resolution TGA screenshots and output them as JPEGs with a darkened border for a cinematic look.
 * 3. When an e‑commerce platform wants to display product mockups stored as TGA files with a soft vignette effect to blend them into the site’s design before saving as JPEG.
 * 4. When a scientific imaging tool requires converting TGA microscopy images to JPEG for reports, adding concentric ellipses to mask edge artifacts.
 * 5. When a digital asset pipeline needs to prepare TGA artwork for social media by applying a vignette and saving the result as a compressed JPEG using C# and Aspose.Imaging.
 */