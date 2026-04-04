using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        // Ensure input directory exists and create a dummy input file
        Directory.CreateDirectory(Path.GetDirectoryName(inputPath));
        if (!File.Exists(inputPath))
        {
            File.WriteAllBytes(inputPath, new byte[0]);
        }

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a memory stream to hold the BMP data
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Set up BMP options with the stream as the source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(memoryStream);

            // Create a 250x250 BMP image
            using (Image image = Image.Create(bmpOptions, 250, 250))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define a blue pen for the Bezier curve
                Pen pen = new Pen(Color.Blue, 2);

                // Draw Bezier curve with four control points
                graphics.DrawBezier(
                    pen,
                    new Point(20, 20),   // start point
                    new Point(80, 10),   // first control point
                    new Point(150, 200), // second control point
                    new Point(230, 230)  // end point
                );

                // Save the image data to the memory stream
                image.Save();
            }

            // At this point, memoryStream contains the BMP image bytes
            // (Optional) Reset position if further processing is needed
            memoryStream.Position = 0;
        }
    }
}