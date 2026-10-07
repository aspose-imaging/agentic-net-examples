// HOW-TO: Load JPEG2000, Invert Colors, and Save as JPEG with 85% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jp2";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions { BufferSizeHint = 1024 * 1024 };
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var raster = image as RasterImage;
                if (raster != null)
                {
                    int width = raster.Width;
                    int height = raster.Height;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixel = raster.GetPixel(x, y);
                            Color inverted = Color.FromArgb(pixel.A, 255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                            raster.SetPixel(x, y, inverted);
                        }
                    }
                }

                var jpegOptions = new JpegOptions
                {
                    Quality = 85,
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to read a large JPEG2000 file into a limited‑size memory buffer, apply a pixel‑wise transformation such as color inversion, and output a smaller JPEG for web display.
 * 2. When converting archival JPEG2000 scans of documents into compressed JPEGs while adjusting image quality to 85 % to balance file size and visual fidelity.
 * 3. When building a C# service that processes satellite or medical imagery stored as JPEG2000, modifies each pixel (e.g., inverting colors for analysis), and saves the result as a standard JPEG.
 * 4. When creating a batch job that loads JPEG2000 assets, performs custom per‑pixel operations using Aspose.Imaging, and generates JPEG previews with a specific quality setting.
 * 5. When developing a desktop application that must handle JPEG2000 images with a 1 MB buffer hint, apply custom pixel effects, and export the edited image as a JPEG with controlled compression.
 */
