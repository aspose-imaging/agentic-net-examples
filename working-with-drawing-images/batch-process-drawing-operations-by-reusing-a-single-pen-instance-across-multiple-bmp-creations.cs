using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file paths
        string[] outputPaths = {
            @"C:\Temp\output1.bmp",
            @"C:\Temp\output2.bmp",
            @"C:\Temp\output3.bmp"
        };

        // Reuse a single Pen instance for all drawings
        Aspose.Imaging.Pen sharedPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3f);

        foreach (string outputPath in outputPaths)
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with a FileCreateSource bound to the output file
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw a rectangle using the shared Pen
                graphics.DrawRectangle(sharedPen, new Aspose.Imaging.Rectangle(20, 20, 160, 160));

                // Save the image (output path already bound)
                image.Save();
            }
        }
    }
}