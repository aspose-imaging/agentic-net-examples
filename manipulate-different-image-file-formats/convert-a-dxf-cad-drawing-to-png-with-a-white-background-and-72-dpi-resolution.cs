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
                PngOptions options = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(72, 72)
                };

                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White
                };
                options.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a construction firm needs to embed a CAD floor plan (DXF) into a web portal that only supports PNG images, they can use this code to convert the drawing to a 72‑DPI PNG with a white background.
 * 2. When an e‑learning platform wants to generate thumbnail previews of engineering schematics for course materials, the code converts the DXF files to PNGs at a standard screen resolution.
 * 3. When a GIS analyst must export vector map layers from AutoCAD to a raster format for inclusion in printed reports, this snippet rasterizes the DXF to a white‑background PNG at 72 DPI.
 * 4. When a mobile app displays user‑uploaded CAD drawings on devices that cannot render DXF, the developer can run this code to produce a compatible PNG image with consistent resolution.
 * 5. When an automated build pipeline processes design assets and needs to create low‑resolution PNG previews for quick review, the code provides a reliable way to convert DXF files with a white background and 72 DPI settings.
 */