// HOW-TO: Convert DXF CAD Drawing to PNG with White Background at 72 DPI in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.dxf";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    var rasterOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;
                    pngOptions.ResolutionSettings = new ResolutionSetting(72, 72);

                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate thumbnail previews of engineering DXF files for a web portal, converting them to PNG with a white background and 72 DPI ensures consistent display across browsers.
 * 2. When exporting CAD drawings to embed in PDF reports, rasterizing the DXF to a 72 DPI PNG with a solid white background preserves layout while keeping file size low.
 * 3. When creating printable documentation that requires raster images instead of vector files, converting DXF to PNG at 72 DPI guarantees the image matches standard screen resolution.
 * 4. When integrating legacy CAD data into a C# desktop application that only supports bitmap formats, this code transforms the DXF into a PNG with a white canvas for easy rendering.
 * 5. When automating batch processing of CAD drawings for a GIS system, converting each DXF to a 72 DPI PNG with a white background simplifies layer handling and improves compatibility with map tiles.
 */
