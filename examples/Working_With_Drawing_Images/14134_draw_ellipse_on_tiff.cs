using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Create a file stream for the TIFF image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Configure TIFF options
                TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                tiffOptions.Source = new StreamSource(stream);

                // Create a new image with specified dimensions
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(tiffOptions, 500, 500))
                {
                    // Initialize graphics object
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Build graphics path with an ellipse shape
                    Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                    Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                    figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(100f, 100f, 300f, 200f)));
                    path.AddFigure(figure);

                    // Draw the ellipse using a pen
                    graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3), path);

                    // Save the image (stream is already bound)
                    image.Save();
                }
            }
        }
    }
}