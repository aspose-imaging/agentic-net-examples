using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = @"C:\temp\img1.png";
        string inputPath2 = @"C:\temp\img2.png";
        string outputPath = @"C:\temp\output.bmp";

        // Validate input files
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
        {
            sizes.Add(new Aspose.Imaging.Size(img1.Width, img1.Height));
        }
        using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
        {
            sizes.Add(new Aspose.Imaging.Size(img2.Width, img2.Height));
        }

        // Calculate canvas dimensions (horizontal layout)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create BMP canvas with bound output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);
        bmpOptions.BitsPerPixel = 24;

        using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
        {
            // Clear background
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Draw each image onto the canvas
            int offsetX = 0;
            foreach (string path in new[] { inputPath1, inputPath2 })
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                    graphics.DrawImage(img, destRect);
                    offsetX += img.Width;
                }
            }

            // Save the bound BMP image
            canvas.Save();
        }
    }
}