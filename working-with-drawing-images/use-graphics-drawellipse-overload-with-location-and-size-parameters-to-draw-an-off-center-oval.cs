using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Ensure any runtime exception is reported without crashing
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear the surface (optional, keep original background if not needed)
                // graphics.Clear(Color.Wheat);

                // Define a pen for the ellipse
                Pen pen = new Pen(Color.Black, 2);

                // Draw an off‑center oval using location and size parameters
                // x = 100, y = 150 define the upper‑left corner of the bounding rectangle
                // width = 200, height = 100 define the size of the oval
                graphics.DrawEllipse(pen, 100f, 150f, 200f, 100f);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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