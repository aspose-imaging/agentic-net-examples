using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/processed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
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
 * 1. When a web application needs to display scalable SVG icons as PNG thumbnails for browsers that do not support SVG, a developer can use this code to rasterize the SVG with a white background and save it to the output folder.
 * 2. When an email marketing system must embed company logos in PNG format to ensure consistent rendering across email clients, the code converts the source SVG to a PNG file using Aspose.Imaging in C#.
 * 3. When a mobile app requires pre‑rendered PNG assets derived from vector SVG illustrations to reduce runtime processing, developers can run this routine to generate the PNG files with the correct dimensions.
 * 4. When a batch job processes a repository of SVG diagrams and needs to archive them as PNG images for legacy systems, the code loads each SVG, applies rasterization options, and saves the result to a designated output directory.
 * 5. When a reporting tool must include vector charts in PDF reports that only accept raster images, the developer can use this snippet to convert the SVG chart to a PNG with a white background before embedding it.
 */