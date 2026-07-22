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
                    pngOptions.ResolutionSettings = new ResolutionSetting(72, 72);
                    pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

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
 * 1. When a civil engineering firm needs to embed a DXF site plan into a PDF report, they can convert the CAD drawing to a high‑resolution PNG with a white background at 72 DPI using Aspose.Imaging in C#.
 * 2. When a web application must display user‑uploaded DXF files as thumbnails on a browser, the code can rasterize the vector drawing to a PNG image with a white background and standard screen resolution.
 * 3. When an automated build pipeline generates documentation and requires all CAD drawings to be converted to PNG for inclusion in HTML pages, this C# snippet provides a reliable way to produce 72 DPI PNGs with consistent background color.
 * 4. When a GIS system needs to overlay a CAD map onto satellite imagery, converting the DXF to a PNG with a white background and known DPI ensures proper alignment and rendering in the mapping software.
 * 5. When a mobile app needs to preview architectural DXF files without installing a CAD viewer, the code can pre‑process the files into lightweight PNG images at 72 DPI with a white background for fast loading.
 */