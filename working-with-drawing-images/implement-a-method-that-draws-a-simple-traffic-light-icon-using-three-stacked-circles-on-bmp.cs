using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set BMP options and bind the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 100x300 image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 100, 300))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background (black)
                graphics.Clear(Aspose.Imaging.Color.Black);

                // Circle size and horizontal position
                int diameter = 80;
                int x = (image.Width - diameter) / 2;

                // Draw red circle (top)
                using (SolidBrush redBrush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillEllipse(redBrush, new Aspose.Imaging.Rectangle(x, 10, diameter, diameter));
                }

                // Draw yellow circle (middle)
                using (SolidBrush yellowBrush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    graphics.FillEllipse(yellowBrush, new Aspose.Imaging.Rectangle(x, 110, diameter, diameter));
                }

                // Draw green circle (bottom)
                using (SolidBrush greenBrush = new SolidBrush(Aspose.Imaging.Color.Green))
                {
                    graphics.FillEllipse(greenBrush, new Aspose.Imaging.Rectangle(x, 210, diameter, diameter));
                }

                // Save the image (source already bound to file)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}