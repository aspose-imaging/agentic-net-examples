// HOW-TO: Increase WMF Canvas Size By 10% And Export To SVG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\enlarged.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = (int)(image.Width * 1.1);
                int newHeight = (int)(image.Height * 1.1);

                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = newWidth,
                        PageHeight = newHeight
                    }
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
 * 1. When you need to embed a WMF diagram in a web page that only supports SVG, you can enlarge the canvas and convert it to SVG.
 * 2. When preparing print‑ready assets, scaling the original WMF by a small percentage ensures higher resolution while keeping vector quality in SVG format.
 * 3. When integrating legacy WMF icons into a modern UI, increasing their size avoids pixelation after conversion to scalable SVG.
 * 4. When automating batch processing of WMF files for a documentation pipeline, you may want to uniformly enlarge each image before saving as SVG.
 * 5. When a client requires vector graphics with a specific page size, you can programmatically adjust the WMF dimensions and output an SVG with the new canvas.
 */
