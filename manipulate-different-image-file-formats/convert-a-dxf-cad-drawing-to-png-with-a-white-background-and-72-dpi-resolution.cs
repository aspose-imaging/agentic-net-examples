// HOW-TO: Convert DXF CAD Drawing to PNG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "drawing.dxf");
            string outputPath = Path.Combine(baseDir, "Output", "drawing.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    options.ResolutionSettings = new ResolutionSetting(72, 72);
                    image.Save(outputPath, options);
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
 * 1. When you need to generate preview images of engineering DXF files for web galleries, you can rasterize them to PNG with a white background using C#.
 * 2. When a CAD‑to‑document workflow requires consistent 72 DPI PNG assets for printing or reporting, this code converts the DXF while setting the resolution.
 * 3. When integrating a .NET application with a content management system that only accepts PNG, you can automatically transform uploaded DXF drawings to PNG with a solid background.
 * 4. When creating thumbnails for a design review portal, you can use this snippet to render DXF vectors as white‑background PNGs at a fixed size and DPI.
 * 5. When automating batch processing of architectural plans, the code lets you convert each DXF to a high‑contrast PNG suitable for OCR or image analysis tools.
 */
