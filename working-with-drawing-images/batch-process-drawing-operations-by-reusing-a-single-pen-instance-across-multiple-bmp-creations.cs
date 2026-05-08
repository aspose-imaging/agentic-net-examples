using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Define the output BMP file paths (hard‑coded literals)
            string[] outputPaths = new string[]
            {
                @"C:\temp\output1.bmp",
                @"C:\temp\output2.bmp",
                @"C:\temp\output3.bmp"
            };

            // Create a single Pen instance that will be reused for all drawings
            Pen sharedPen = new Pen(Color.Blue, 3f);

            foreach (string outputPath in outputPaths)
            {
                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up BMP options with a FileCreateSource pointing to the output file
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create a new BMP image of size 400x400
                using (Image image = Image.Create(bmpOptions, 400, 400))
                {
                    // Initialize graphics for the image
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Draw several rectangles using the shared Pen
                    graphics.DrawRectangles(sharedPen, new[]
                    {
                        new Rectangle(50, 50, 100, 100),
                        new Rectangle(200, 50, 100, 100),
                        new Rectangle(125, 200, 150, 150)
                    });

                    // Save the image (FileCreateSource already points to the file)
                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}