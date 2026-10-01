// HOW-TO: Convert OTG Vector File to PNG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.otg";
        string outputPath = "Output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
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
 * 1. When you need to display an OTG diagram on a web page that only supports PNG images, you can rasterize it with a white background using C#.
 * 2. When generating thumbnails for OTG drawings in a document management system, converting them to PNG ensures fast loading and a consistent background.
 * 3. When integrating vector OTG assets into a reporting tool that expects raster images, you can programmatically set the background color before saving as PNG.
 * 4. When automating batch conversion of OTG files to PNG for archival purposes, the code lets you control the background color to avoid transparency issues.
 * 5. When creating printable previews of OTG graphics in a Windows application, converting them to PNG with a solid white background guarantees correct rendering on all printers.
 */
