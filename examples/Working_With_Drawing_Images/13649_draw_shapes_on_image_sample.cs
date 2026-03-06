using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

// ------------------------------------------------------------
// Sample 1: Create a new PNG image and draw primitive shapes
// ------------------------------------------------------------
{
    // Create a file stream for the output PNG
    using (FileStream outStream = new FileStream(@"C:\temp\shapes_output.png", FileMode.Create))
    {
        // Configure PNG options and associate the stream as the source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new StreamSource(outStream);

        // Create a 500x500 image using the PNG options
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Fill the background with a light color
            graphics.Clear(Color.Wheat);

            // Draw various primitive shapes
            graphics.DrawArc(new Pen(Color.Black, 2), new Rectangle(200, 200, 100, 200), 0, 300);
            graphics.DrawBezier(new Pen(Color.Blue, 2),
                new Point(250, 100), new Point(300, 30), new Point(450, 100), new Point(235, 25));
            graphics.DrawCurve(new Pen(Color.Green, 2),
                new[] { new Point(100, 200), new Point(100, 350), new Point(200, 450) });
            graphics.DrawEllipse(new Pen(Color.Yellow, 2), new Rectangle(300, 300, 100, 100));
            graphics.DrawLine(new Pen(Color.Violet, 2), new Point(100, 100), new Point(200, 200));
            graphics.DrawPie(new Pen(Color.Silver, 2),
                new Rectangle(new Point(200, 20), new Size(200, 200)), 0, 45);
            graphics.DrawPolygon(new Pen(Color.Red, 2),
                new[] { new Point(20, 100), new Point(20, 200), new Point(220, 20) });
            graphics.DrawRectangle(new Pen(Color.Orange, 2),
                new Rectangle(new Point(250, 250), new Size(100, 100)));

            // Draw a text string using a solid brush and a font
            SolidBrush textBrush = new SolidBrush { Color = Color.Purple, Opacity = 100 };
            graphics.DrawString("Created with Aspose.Imaging", new Font("Times New Roman", 16), textBrush, new PointF(50, 400));

            // Persist the changes to the underlying stream
            image.Save();
        }
    }
}

// ------------------------------------------------------------
// Sample 2: Load an existing image, overlay another image, and save
// ------------------------------------------------------------
{
    // Load the base image (e.g., a JPEG) from disk
    using (Image baseImage = Image.Load(@"C:\temp\base_photo.jpg"))
    {
        // Load the overlay image (e.g., a PNG with transparency)
        using (RasterImage overlay = (RasterImage)Image.Load(@"C:\temp\logo.png"))
        {
            // Create a Graphics object for the base image
            Graphics graphics = new Graphics(baseImage);

            // Optionally clear the background (commented out to keep original)
            // graphics.Clear(Color.White);

            // Draw the overlay image at position (30,30) with its original size
            graphics.DrawImage(overlay, 30, 30);

            // Draw the same overlay scaled to a 150x50 rectangle at (200,200)
            graphics.DrawImage(overlay,
                new Rectangle(200, 200, 150, 50),
                new Rectangle(0, 0, overlay.Width, overlay.Height),
                GraphicsUnit.Pixel);

            // Add a caption below the overlay
            graphics.DrawString("Company Logo", new Font("Arial", 24, FontStyle.Bold),
                new SolidBrush { Color = Color.Black, Opacity = 255 },
                new PointF(200, 260));

            // Save the modified image as a new PNG file
            using (FileStream outStream = new FileStream(@"C:\temp\combined_output.png", FileMode.Create))
            {
                PngOptions saveOptions = new PngOptions();
                saveOptions.Source = new StreamSource(outStream);
                baseImage.Save(outStream, saveOptions);
            }
        }
    }
}