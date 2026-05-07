using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\sharpPolygon.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with a file source
            var bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                var graphics = new Aspose.Imaging.Graphics(image);

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Create a pen with a high MiterLimit to preserve sharp angles
                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                pen.MiterLimit = 10f; // high value for sharp‑angled joins

                // Define points of a sharp‑angled polygon (star‑like shape)
                var points = new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(250, 10),
                    new Aspose.Imaging.Point(260, 200),
                    new Aspose.Imaging.Point(400, 210),
                    new Aspose.Imaging.Point(280, 300),
                    new Aspose.Imaging.Point(300, 490),
                    new Aspose.Imaging.Point(250, 380),
                    new Aspose.Imaging.Point(200, 490),
                    new Aspose.Imaging.Point(220, 300),
                    new Aspose.Imaging.Point(100, 210),
                    new Aspose.Imaging.Point(240, 200)
                };

                // Draw the polygon with the configured pen
                graphics.DrawPolygon(pen, points);

                // Save the image (output file is already bound via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}