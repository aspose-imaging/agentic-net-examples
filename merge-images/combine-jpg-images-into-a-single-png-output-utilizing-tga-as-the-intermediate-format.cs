using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Folder for intermediate TGA files
        string tgaFolder = "temp_tga";
        Directory.CreateDirectory(tgaFolder);

        // Convert each JPG to TGA
        List<string> tgaPaths = new List<string>();
        foreach (string jpgPath in inputPaths)
        {
            string tgaPath = Path.Combine(tgaFolder, Path.GetFileNameWithoutExtension(jpgPath) + ".tga");
            using (RasterImage raster = (RasterImage)Image.Load(jpgPath))
            {
                raster.Save(tgaPath, new TgaOptions());
            }
            tgaPaths.Add(tgaPath);
        }

        // Verify each intermediate TGA file exists
        foreach (string path in tgaPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"Intermediate file not found: {path}");
                return;
            }
        }

        // Calculate canvas size for horizontal merge
        List<Size> sizes = new List<Size>();
        foreach (string tgaPath in tgaPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(tgaPath))
            {
                sizes.Add(img.Size);
            }
        }

        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Output PNG path
        string outputPath = "output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Create PNG canvas bound to output file
        PngOptions pngOptions = new PngOptions
        {
            Source = new FileCreateSource(outputPath, false)
        };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string tgaPath in tgaPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(tgaPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the bound canvas
            canvas.Save();
        }
    }
}