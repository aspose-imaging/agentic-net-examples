using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    Compress = true
                };

                image.Save(outputPath, svgOptions);
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
 * 1. When a web developer needs to reduce the file size of an SVG logo before uploading it to a website, they can use this C# code with Aspose.Imaging to load the SVG, compress the path data, and save an optimized version.
 * 2. When a mobile app team wants to ensure vector icons load quickly on low‑bandwidth devices, they can run this code to rasterize the SVG at its original dimensions, apply compression, and generate a smaller SVG file.
 * 3. When a SaaS platform automatically generates custom charts in SVG format and must store them efficiently, the code can be invoked to simplify the SVG paths and save the compressed graphic to a storage folder.
 * 4. When a designer exports artwork from a vector editor and needs a production‑ready SVG without unnecessary metadata for print workflows, this snippet loads the file, sets a white background, and outputs a clean, optimized SVG.
 * 5. When an automated build pipeline processes a batch of SVG assets for an e‑learning course, the code can be used to programmatically load each file, compress its vector data, and write the optimized SVG to the output directory.
 */