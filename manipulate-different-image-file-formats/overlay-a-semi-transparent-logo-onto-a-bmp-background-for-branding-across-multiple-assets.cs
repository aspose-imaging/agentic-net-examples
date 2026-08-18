// HOW-TO: Overlay Semi Transparent PNG Logo onto BMP Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            string backgroundPath = "background.bmp";
            string logoPath = "logo.png";
            string outputPath = "output.bmp";

            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source outputSource = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = outputSource };

            using (BmpImage background = (BmpImage)Image.Load(backgroundPath))
            {
                using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, background.Width, background.Height))
                {
                    // Copy background onto canvas
                    canvas.SaveArgb32Pixels(new Rectangle(0, 0, background.Width, background.Height),
                                            background.LoadArgb32Pixels(background.Bounds));

                    // Load logo
                    using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                    {
                        // Overlay logo at position (50,50) with 50% opacity
                        canvas.Blend(new Point(50, 50), logo, 128);
                    }

                    // Save the bound image
                    canvas.Save();
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
 * 1. When you need to brand a series of BMP product images by stamping a semi‑transparent PNG logo at a fixed position using C# and Aspose.Imaging.
 * 2. When you want to add a watermark to legacy BMP files without converting them to another format, preserving the original dimensions and color depth.
 * 3. When you are generating printable assets that require a consistent logo overlay on BMP backgrounds for marketing materials.
 * 4. When you must programmatically combine a high‑resolution PNG logo with a BMP canvas while controlling opacity for a corporate branding pipeline.
 * 5. When you need to automate the creation of BMP files with a logo overlay for use in embedded systems that only support BMP graphics.
 */
