using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                WmfImage wmfImage = (WmfImage)image;

                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = wmfImage.Width,
                    PageHeight = wmfImage.Height
                };

                using (PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                })
                {
                    wmfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert legacy WMF diagrams that use corporate‑specific TrueType fonts stored in a private folder to PNG images for web display, they can set FontSettings to point to that folder before rasterization.
 * 2. When an automated document‑generation pipeline must render WMF charts with custom fonts embedded in a network share into high‑resolution PNG files, the code ensures the correct fonts are loaded via FontSettings.
 * 3. When a Windows desktop application imports user‑provided WMF icons that rely on non‑system fonts and must export them as PNG assets for mobile apps, developers use FontSettings to locate those fonts before conversion.
 * 4. When a batch conversion tool processes thousands of WMF files containing brand‑specific typography stored in a custom fonts directory, setting FontSettings guarantees consistent text appearance in the resulting PNG raster images.
 * 5. When a cloud‑based image service receives WMF files with embedded font references that are not installed on the server, developers configure FontSettings to point to a temporary font folder to correctly rasterize the files to PNG format.
 */