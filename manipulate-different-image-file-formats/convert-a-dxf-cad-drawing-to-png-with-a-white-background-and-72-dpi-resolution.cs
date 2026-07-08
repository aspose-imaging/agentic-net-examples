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
            string inputPath = "input.dxf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White
                    },
                    ResolutionSettings = new ResolutionSetting(72, 72)
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
 * 1. When a CAD engineer needs to embed a DXF drawing into a web page, they can convert the DXF to a PNG with a white background and 72 DPI using Aspose.Imaging for .NET.
 * 2. When an automated reporting system must generate printable thumbnails of architectural plans, the code rasterizes the DXF to a 72 DPI PNG so the images render correctly in PDF reports.
 * 3. When a GIS application imports vector drawings and requires a raster preview for quick display, the developer can use this C# snippet to transform the DXF into a white‑background PNG at screen resolution.
 * 4. When a document management workflow needs to store CAD files as lossless PNG previews for indexing and search, the code provides a reliable way to create 72 DPI PNG files from DXF sources.
 * 5. When a mobile app needs to show CAD schematics without installing a CAD viewer, the developer can pre‑process the DXF into a 72 DPI PNG with a white background for fast loading on the device.
 */