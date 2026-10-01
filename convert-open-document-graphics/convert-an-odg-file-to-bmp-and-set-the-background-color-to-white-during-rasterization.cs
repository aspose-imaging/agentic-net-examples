// HOW-TO: Convert ODG to BMP with White Background Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };
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
 * 1. When you need to generate bitmap thumbnails of ODG drawings for a web gallery and require a solid white background.
 * 2. When converting LibreOffice Draw files to BMP for legacy Windows applications that only accept BMP images.
 * 3. When preparing ODG diagrams for printing on devices that support only raster formats and need a consistent white background.
 * 4. When automating batch conversion of ODG assets to BMP in a C# build pipeline while ensuring transparent areas become white.
 * 5. When integrating ODG content into a .NET reporting tool that expects BMP images with a white canvas.
 */
