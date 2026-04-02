using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG file paths (replace with actual network stream handling if needed)
        string inputPath1 = "input1.jpg";
        string inputPath2 = "input2.jpg";

        // Hardcoded output JPEG file path
        string outputPath = "output\\merged.jpg";

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
        List<Size> sizeList = new List<Size>();
        using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
        {
            sizeList.Add(img1.Size);
        }
        using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
        {
            sizeList.Add(img2.Size);
        }

        // Calculate canvas dimensions for vertical merge
        int canvasWidth = sizeList.Max(s => s.Width);
        int canvasHeight = sizeList.Sum(s => s.Height);

        // Create JPEG options with bound source
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 90
        };

        // Create bound JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            string[] inputPaths = new[] { inputPath1, inputPath2 };
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound image (no need to pass path again)
            canvas.Save();
        }
    }
}