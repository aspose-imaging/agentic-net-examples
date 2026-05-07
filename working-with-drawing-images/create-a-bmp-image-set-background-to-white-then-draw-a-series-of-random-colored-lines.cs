using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a BMP canvas of size 800x600
            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, 800, 600))
            {
                // Initialize graphics for the canvas
                Graphics graphics = new Graphics(canvas);

                // Set background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw random colored lines
                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int x1 = rand.Next(canvas.Width);
                    int y1 = rand.Next(canvas.Height);
                    int x2 = rand.Next(canvas.Width);
                    int y2 = rand.Next(canvas.Height);

                    Aspose.Imaging.Color lineColor = Aspose.Imaging.Color.FromArgb(
                        255,
                        rand.Next(256),
                        rand.Next(256),
                        rand.Next(256));

                    Pen pen = new Pen(lineColor, 2);
                    graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                }

                // Save the bound image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}