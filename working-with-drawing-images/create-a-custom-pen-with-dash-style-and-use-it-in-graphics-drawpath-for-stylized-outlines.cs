using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main()
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\Temp\styled_path.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PNG options with a bound FileCreateSource
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Build a GraphicsPath containing a single rectangle figure
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
            path.AddFigure(figure);

            // Create a custom Pen with dash style and pattern
            Pen dashPen = new Pen(Color.Blue, 5f);
            dashPen.DashStyle = DashStyle.Dash;               // dashed line style
            dashPen.DashPattern = new float[] { 10f, 5f };    // 10 units dash, 5 units space

            // Draw the path using the custom dash pen
            graphics.DrawPath(dashPen, path);

            // Save the image (output file already bound to the source)
            image.Save();
        }
    }
}