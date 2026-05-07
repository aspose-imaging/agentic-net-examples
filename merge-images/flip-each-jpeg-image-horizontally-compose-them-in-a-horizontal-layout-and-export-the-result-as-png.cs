using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG files and output PNG file
            string[] inputPaths = new string[]
            {
                "Input/image1.jpg",
                "Input/image2.jpg",
                "Input/image3.jpg"
            };
            string outputPath = "Output/merged.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Load, flip, and store pixel data of each image
            var imagesData = new List<(int Width, int Height, int[] Pixels)>();
            int totalWidth = 0;
            int maxHeight = 0;

            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Flip horizontally
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    // Store dimensions and pixel data
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    imagesData.Add((img.Width, img.Height, pixels));

                    totalWidth += img.Width;
                    if (img.Height > maxHeight) maxHeight = img.Height;
                }
            }

            // Create PNG canvas with the calculated size
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = src };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var data in imagesData)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, data.Width, data.Height);
                    canvas.SaveArgb32Pixels(bounds, data.Pixels);
                    offsetX += data.Width;
                }

                // Save the merged image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}