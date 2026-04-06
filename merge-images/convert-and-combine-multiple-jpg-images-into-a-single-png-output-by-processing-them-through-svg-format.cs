using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Gather JPG files
        string[] allFiles = Directory.GetFiles(inputDirectory, "*.*");
        string[] jpgFiles = allFiles
            .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
            .ToArray();

        if (jpgFiles.Length == 0)
        {
            Console.WriteLine("No JPG files found in the input directory.");
            return;
        }

        // Collect image sizes and validate each file
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        List<string> imagePaths = new List<string>();

        foreach (string filePath in jpgFiles)
        {
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            using (RasterImage img = (RasterImage)Image.Load(filePath))
            {
                sizes.Add(img.Size);
                imagePaths.Add(filePath);
            }
        }

        // Calculate canvas dimensions (horizontal concatenation)
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Prepare temporary SVG path
        string tempSvgPath = Path.Combine(outputDirectory, "combined.svg");
        Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));

        // Create SVG canvas
        Source svgSource = new FileCreateSource(tempSvgPath, false);
        SvgOptions svgOptions = new SvgOptions { Source = svgSource };

        using (SvgImage svgCanvas = (SvgImage)Image.Create(svgOptions, totalWidth, maxHeight))
        {
            Graphics graphics = new Graphics(svgCanvas);
            int offsetX = 0;
            for (int i = 0; i < imagePaths.Count; i++)
            {
                using (RasterImage img = (RasterImage)Image.Load(imagePaths[i]))
                {
                    graphics.DrawImage(img, new Rectangle(offsetX, 0, img.Width, img.Height));
                    offsetX += img.Width;
                }
            }

            // Rasterize SVG to PNG
            string outputPngPath = Path.Combine(outputDirectory, "combined.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = new SizeF(totalWidth, maxHeight)
                }
            };

            svgCanvas.Save(outputPngPath, pngOptions);
        }
    }
}