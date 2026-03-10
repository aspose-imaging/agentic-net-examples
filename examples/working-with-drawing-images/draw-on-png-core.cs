using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Path where the resulting PNG will be saved
        string outputPath = @"C:\temp\drawn_image.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options (default options are sufficient for this example)
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new PNG image with the desired dimensions (400x300)
            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                // Initialize Graphics object to draw on the image surface
                Graphics graphics = new Graphics(image);

                // Fill the background with a light gray color
                graphics.Clear(Color.LightGray);

                // Draw a blue rectangle
                graphics.DrawRectangle(
                    new Pen(Color.Blue, 3),
                    new Rectangle(50, 50, 300, 200));

                // Draw a red ellipse inside the rectangle
                graphics.DrawEllipse(
                    new Pen(Color.Red, 2),
                    new Rectangle(100, 80, 200, 140));

                // Draw a green diagonal line
                graphics.DrawLine(
                    new Pen(Color.Green, 4),
                    new Point(50, 50),
                    new Point(350, 250));

                // Load an external image (e.g., a BMP) to embed into the PNG
                // Ensure the source file exists; replace with a valid path as needed
                string embedImagePath = @"C:\temp\sample.bmp";
                if (File.Exists(embedImagePath))
                {
                    using (RasterImage embedImage = (RasterImage)Image.Load(embedImagePath))
                    {
                        // Draw the embedded image at position (150,100) with size 100x100
                        graphics.DrawImage(
                            embedImage,
                            new Rectangle(150, 100, 100, 100),
                            new Rectangle(0, 0, embedImage.Width, embedImage.Height),
                            GraphicsUnit.Pixel);
                    }
                }

                // Save all changes to the PNG file
                image.Save();
            }
        }

        Console.WriteLine("Image created successfully at: " + outputPath);
    }
}