// HOW-TO: Convert OTG to BMP with White Background Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to display vector OTG graphics in a Windows application that only supports BMP images, you can rasterize them with a white background.
 * 2. When preparing OTG files for printing on white paper, converting them to BMP ensures the background appears solid white.
 * 3. When integrating legacy systems that accept BMP files, you can programmatically transform OTG diagrams to BMP while preserving layout.
 * 4. When creating thumbnails for OTG drawings in a gallery, converting to BMP with a white background provides consistent visual appearance.
 * 5. When automating batch processing of OTG assets for a game engine that requires BMP textures, this code rasterizes each file with a white backdrop.
 */
