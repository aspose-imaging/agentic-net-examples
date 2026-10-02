// HOW-TO: Apply Anti-Alias Smoothing to BMP Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to improve the visual quality of shapes drawn on a BMP image by applying anti‑alias smoothing before saving it in a .NET application.
 * 2. When generating bitmap thumbnails for a user interface and want smoother edges to eliminate jagged lines.
 * 3. When adding vector annotations to scanned BMP documents and require anti‑aliased lines to keep the text and graphics crisp.
 * 4. When creating game sprites or UI assets in BMP format and need smoother outlines for a polished appearance on high‑resolution displays.
 * 5. When batch‑processing BMP files and want to apply a consistent anti‑alias filter to each image to maintain a uniform visual style.
 */
