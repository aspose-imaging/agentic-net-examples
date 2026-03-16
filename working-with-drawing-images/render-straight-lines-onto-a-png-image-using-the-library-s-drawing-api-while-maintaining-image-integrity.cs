using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging;
using Aspose.Imaging;

// Create a file stream for the output PNG
using (FileStream stream = new FileStream(@"C:\temp\lines_output.png", FileMode.Create))
{
    // Initialize PNG options and associate the stream as the source
    PngOptions pngOptions = new PngOptions();
    pngOptions.Source = new StreamSource(stream);

    // Create a 400x400 PNG image using the options
    using (Image image = Image.Create(pngOptions, 400, 400))
    {
        // Obtain a Graphics object for drawing on the image
        Graphics graphics = new Graphics(image);

        // Optional: clear the background with a light color
        graphics.Clear(Color.LightGray);

        // Define a pen (color and thickness) for the lines
        Pen blackPen = new Pen(Color.Black, 2);
        Pen redPen   = new Pen(Color.Red, 3);
        Pen bluePen  = new Pen(Color.Blue, 1);

        // Draw several straight lines using different coordinates
        graphics.DrawLine(blackPen, new Point(50, 50), new Point(350, 50));   // Top horizontal line
        graphics.DrawLine(redPen,   new Point(50, 100), new Point(350, 300)); // Diagonal line
        graphics.DrawLine(bluePen,  new Point(50, 350), new Point(350, 350)); // Bottom horizontal line
        graphics.DrawLine(blackPen, new Point(200, 50), new Point(200, 350)); // Vertical line

        // Save all changes to the PNG file
        image.Save();
    }
}