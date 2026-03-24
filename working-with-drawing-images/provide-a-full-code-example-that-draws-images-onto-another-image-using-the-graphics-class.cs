using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output paths
        string inputPath1 = "input/input1.png";
        string inputPath2 = "input/input2.png";
        string outputPath = "output/output.png";

        // Verify input files exist
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

        // Load source images
        using (RasterImage src1 = (RasterImage)Image.Load(inputPath1))
        using (RasterImage src2 = (RasterImage)Image.Load(inputPath2))
        {
            // Determine canvas size (width = max of sources, height = sum of heights)
            int canvasWidth = Math.Max(src1.Width, src2.Width);
            int canvasHeight = src1.Height + src2.Height;

            // Create output canvas bound to file
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outSource };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics for the canvas
                Graphics graphics = new Graphics(canvas);

                // Clear background
                graphics.Clear(Color.White);

                // Draw first image at (0,0)
                graphics.DrawImage(src1, 0, 0);

                // Draw second image below the first
                graphics.DrawImage(src2, 0, src1.Height);

                // Save the bound canvas
                canvas.Save();
            }
        }
    }
}