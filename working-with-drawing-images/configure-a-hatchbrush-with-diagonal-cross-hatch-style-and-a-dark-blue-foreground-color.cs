using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Configure HatchBrush with diagonal cross style and dark blue foreground
                HatchBrush brush = new HatchBrush();
                brush.HatchStyle = HatchStyle.DiagonalCross;          // Diagonal cross hatch
                brush.ForegroundColor = Color.DarkBlue;               // Dark blue lines
                brush.BackgroundColor = Color.White;                  // Optional background color

                // Use the brush in a pen to draw a rectangle
                Pen pen = new Pen(brush, 5f);
                graphics.DrawRectangle(pen, new Rectangle(new Point(50, 50), new Size(200, 200)));

                // Save the modified image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}