using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG files
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Hardcoded output PNG file
        string outputPath = "merged.png";

        // Validate input files
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Lists to hold pixel data and sizes of flipped images
        List<int[]> pixelDataList = new List<int[]>();
        List<Size> sizeList = new List<Size>();

        // Load each JPEG, flip horizontally, and store its pixel data and size
        foreach (string inputPath in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(inputPath))
            {
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pixelDataList.Add(img.LoadArgb32Pixels(img.Bounds));
                sizeList.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal composition
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizeList)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight)
                newHeight = sz.Height;
        }

        // Create PNG canvas bound to the output file
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            for (int i = 0; i < pixelDataList.Count; i++)
            {
                Size sz = sizeList[i];
                Rectangle bounds = new Rectangle(offsetX, 0, sz.Width, sz.Height);
                canvas.SaveArgb32Pixels(bounds, pixelDataList[i]);
                offsetX += sz.Width;
            }

            // Save the bound canvas (output file already specified in options)
            canvas.Save();
        }
    }
}