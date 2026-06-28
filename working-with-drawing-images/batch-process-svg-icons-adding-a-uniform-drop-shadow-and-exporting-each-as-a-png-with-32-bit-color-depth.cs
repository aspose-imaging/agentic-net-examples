using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputPngs";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };
                    image.Save(outputPath, options);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a developer needs to automatically convert a large collection of SVG icons into high‑quality 32‑bit PNG files for use on a website, they can use this C# batch‑processing code with Aspose.Imaging.
 * 2. When a build script must generate platform‑specific PNG assets from designer‑provided SVG files during continuous integration, this code provides a reliable way to rasterize the vectors and save them with correct dimensions.
 * 3. When a desktop application requires runtime conversion of user‑uploaded SVG graphics to PNG format for preview or printing, the example shows how to load, rasterize, and export each image using Aspose.Imaging in .NET.
 * 4. When a mobile app development team needs to create a set of PNG icons at exact pixel sizes from a master SVG library, the code demonstrates how to preserve the original SVG size while exporting to 32‑bit PNG.
 * 5. When an automated documentation generator must embed SVG diagrams as PNG images in PDF reports, this snippet can batch‑process the SVG files and produce PNG outputs compatible with the reporting engine.
 */