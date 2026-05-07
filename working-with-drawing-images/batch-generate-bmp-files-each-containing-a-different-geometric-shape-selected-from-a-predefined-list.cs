using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output directory and ensure it exists
            string outputDir = @"C:\temp\Shapes";
            Directory.CreateDirectory(outputDir);

            // Define image size
            int width = 300;
            int height = 300;

            // Rectangle
            string rectPath = Path.Combine(outputDir, "rectangle.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(rectPath));
            CreateBmpWithShape(rectPath, width, height, (graphics) =>
            {
                graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 50, 200, 150));
            });

            // Ellipse
            string ellipsePath = Path.Combine(outputDir, "ellipse.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(ellipsePath));
            CreateBmpWithShape(ellipsePath, width, height, (graphics) =>
            {
                graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(50, 50, 200, 150));
            });

            // Line
            string linePath = Path.Combine(outputDir, "line.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(linePath));
            CreateBmpWithShape(linePath, width, height, (graphics) =>
            {
                graphics.DrawLine(new Pen(Color.Red, 2), new Point(50, 50), new Point(250, 250));
            });

            // Polygon (triangle)
            string polygonPath = Path.Combine(outputDir, "polygon.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(polygonPath));
            CreateBmpWithShape(polygonPath, width, height, (graphics) =>
            {
                Point[] points = new Point[]
                {
                    new Point(150, 50),
                    new Point(250, 200),
                    new Point(50, 200)
                };
                graphics.DrawPolygon(new Pen(Color.Green, 2), points);
            });

            // Filled Rectangle
            string filledRectPath = Path.Combine(outputDir, "filled_rectangle.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(filledRectPath));
            CreateBmpWithShape(filledRectPath, width, height, (graphics) =>
            {
                using (SolidBrush brush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillRectangle(brush, new Rectangle(60, 60, 180, 120));
                }
                graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(60, 60, 180, 120));
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper to create a BMP image and execute drawing actions
    static void CreateBmpWithShape(string outputPath, int width, int height, Action<Graphics> drawAction)
    {
        // Ensure output directory exists (already called before, but safe)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with file source
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Perform custom drawing
            drawAction(graphics);

            // Save bound image
            image.Save();
        }
    }
}