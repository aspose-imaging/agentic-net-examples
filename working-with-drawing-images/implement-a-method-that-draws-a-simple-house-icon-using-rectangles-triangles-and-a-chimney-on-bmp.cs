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
            // Output file path
            string outputPath = @"C:\temp\house.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define canvas size
            int canvasWidth = 200;
            int canvasHeight = 200;

            // Create the image canvas (bound to the file)
            using (Image image = Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for outlines
                Pen outlinePen = new Pen(Color.Black, 2);

                // Draw house body (rectangle)
                Rectangle houseBody = new Rectangle(50, 100, 100, 80);
                graphics.DrawRectangle(outlinePen, houseBody);
                using (SolidBrush bodyBrush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillRectangle(bodyBrush, houseBody);
                }

                // Draw roof (triangle) using polygon
                Point[] roofPoints = new Point[]
                {
                    new Point(50, 100),          // left corner of house body
                    new Point(150, 100),         // right corner of house body
                    new Point(100, 50)           // peak of roof
                };
                graphics.DrawPolygon(outlinePen, roofPoints);
                using (SolidBrush roofBrush = new SolidBrush(Color.DarkRed))
                {
                    graphics.FillPolygon(roofBrush, roofPoints);
                }

                // Draw chimney (small rectangle)
                Rectangle chimney = new Rectangle(115, 55, 15, 30);
                graphics.DrawRectangle(outlinePen, chimney);
                using (SolidBrush chimneyBrush = new SolidBrush(Color.DarkGray))
                {
                    graphics.FillRectangle(chimneyBrush, chimney);
                }

                // Save the bound image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}