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
            // Output BMP path (hardcoded)
            string outputPath = @"output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file create source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define canvas size
            int width = 400;
            int height = 300;

            // Create the image (canvas) bound to the output file
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen with custom dash style
                Pen pen = new Pen(Color.Black, 5f);
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 10f, 5f }; // dash length 10, space length 5

                // Draw a diagonal dashed line across the canvas
                graphics.DrawLine(pen, 0, 0, width, height);

                // Save the image (output is already bound via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}