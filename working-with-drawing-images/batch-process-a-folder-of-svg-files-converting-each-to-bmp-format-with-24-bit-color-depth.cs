// HOW-TO: Batch Convert SVG Files to 24‑Bit BMP Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input_svgs";
            string outputFolder = "output_bmps";

            // Ensure the root output directory exists
            Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        // Default rasterization settings; adjust if needed
                    };

                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24,
                        VectorRasterizationOptions = rasterizationOptions
                    };

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
 * 1. When you need to generate high‑resolution 24‑bit BMP thumbnails from a collection of vector SVG logos for a Windows desktop application.
 * 2. When a legacy system only accepts BMP files, and you must programmatically convert a folder of SVG assets to BMP before import.
 * 3. When preparing print‑ready raster images from SVG diagrams, converting them in bulk to BMP with true‑color depth using C#.
 * 4. When automating the migration of web‑optimized SVG icons to BMP format for use in embedded devices that require bitmap graphics.
 * 5. When creating a batch job that processes user‑uploaded SVG drawings and stores them as 24‑bit BMP files on the server for further analysis.
 */
