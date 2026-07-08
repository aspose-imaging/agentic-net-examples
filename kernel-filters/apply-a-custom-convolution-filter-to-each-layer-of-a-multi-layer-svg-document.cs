using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Input file is not an SVG image.");
                    return;
                }

                PngOptions pngOptions = new PngOptions();
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a web application must generate high‑resolution PNG thumbnails from multi‑layer SVG logos on the fly, a developer can use this C# code with Aspose.Imaging to load the SVG and save each rendered layer as a PNG file.
 * 2. When an e‑commerce platform needs to convert product vector illustrations (SVG) into raster images for PDF invoices, the code provides a reliable way to load the SVG and export it as a PNG using Aspose.Imaging in .NET.
 * 3. When a mobile game studio wants to pre‑process SVG assets into PNG sprites for faster rendering on devices, this snippet demonstrates how to programmatically load the SVG and rasterize it with Aspose.Imaging.
 * 4. When an email marketing system must embed SVG icons as PNG attachments to ensure compatibility with all email clients, the developer can employ this code to convert the SVG files to PNG format on the server.
 * 5. When a reporting tool needs to include vector diagrams (multi‑layer SVG) in generated PNG charts for PDF export, the example shows how to load the SVG and save it as a PNG using C# and Aspose.Imaging.
 */