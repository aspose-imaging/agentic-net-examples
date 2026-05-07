using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define canvas size
            int width = 400;
            int height = 300;

            // Create the BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Draw a thick black border
                Aspose.Imaging.Pen borderPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 10);
                graphics.DrawRectangle(borderPen, 0, 0, width, height);

                // Draw an inner rectangle inset from the border
                int inset = 20;
                Aspose.Imaging.Pen innerPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
                graphics.DrawRectangle(innerPen, inset, inset, width - 2 * inset, height - 2 * inset);

                // Save the image (source is already bound to the file)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}