// HOW-TO: Convert SVG to BMP in ASP.NET Core Controller Using Aspose Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    var rasterOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    bmpOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, bmpOptions);
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
 * 1. When a web application needs to serve rasterized BMP versions of user‑uploaded SVG icons for legacy Windows applications.
 * 2. When an API endpoint must dynamically convert vector graphics to BMP for printing on devices that only accept bitmap files.
 * 3. When a reporting service generates BMP charts from SVG diagrams to embed in PDF reports that require bitmap images.
 * 4. When a mobile backend converts scalable SVG logos to BMP thumbnails for faster loading on low‑power clients.
 * 5. When a document management system stores BMP previews of SVG files to maintain compatibility with older image viewers.
 */
