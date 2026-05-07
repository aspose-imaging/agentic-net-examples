using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path for the BMP image
        string outputPath = @"C:\Temp\output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the created source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Define canvas size
            int canvasWidth = 400;
            int canvasHeight = 300;

            // Create the BMP canvas (bound image)
            using (Image canvas = Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Optional: fill background with white
                graphics.Clear(Color.White);

                // Create a thick pen for the bold border
                Pen borderPen = new Pen(Color.Black, 5);

                // Draw rectangle border around the entire canvas
                graphics.DrawRectangle(borderPen, 0, 0, canvasWidth, canvasHeight);

                // Save the bound image (output file)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}