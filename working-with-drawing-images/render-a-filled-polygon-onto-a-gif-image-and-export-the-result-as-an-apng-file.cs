using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output\\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Ensure the GIF has at least one frame
            if (gif.PageCount == 0)
            {
                Console.Error.WriteLine("The GIF image contains no frames.");
                return;
            }

            // Activate the first frame for drawing
            gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];

            // Create a graphics object for the active frame (no using block)
            Graphics graphics = new Graphics(gif.ActiveFrame);

            // Define polygon vertices using Aspose.Imaging.PointF
            Aspose.Imaging.PointF[] polygonPoints = new Aspose.Imaging.PointF[]
            {
                new Aspose.Imaging.PointF(10, 10),
                new Aspose.Imaging.PointF(100, 20),
                new Aspose.Imaging.PointF(80, 80),
                new Aspose.Imaging.PointF(20, 70)
            };

            // Fill the polygon with a solid blue brush
            using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
            {
                graphics.FillPolygon(brush, polygonPoints);
            }

            // Save the modified image as a GIF file
            GifOptions saveOptions = new GifOptions();
            gif.Save(outputPath, saveOptions);
        }
    }
}