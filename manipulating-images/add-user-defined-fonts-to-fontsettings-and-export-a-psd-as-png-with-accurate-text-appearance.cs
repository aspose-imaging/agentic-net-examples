using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var vectorOpts = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOpts
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When a web application uses Aspose.Imaging for .NET to generate thumbnail previews of PSD files that contain custom fonts, ensuring the PNG output matches the original design.
 * 2. When an e‑commerce platform leverages Aspose.Imaging for .NET to convert product mockups stored as PSDs into PNGs for fast loading, while preserving brand‑specific typography supplied via user‑defined fonts.
 * 3. When a digital asset management system batch‑processes PSD artwork with non‑standard fonts using Aspose.Imaging for .NET and exports them as PNGs for compatibility with downstream tools.
 * 4. When a desktop publishing workflow automates the creation of print‑ready PNG assets from PSD source files that rely on licensed fonts not installed on the server, by configuring FontSettings in Aspose.Imaging for .NET.
 * 5. When a mobile app backend renders user‑uploaded PSD designs containing custom typefaces into PNGs for preview on devices that only support raster images, using Aspose.Imaging for .NET’s vector rasterization options.
 */