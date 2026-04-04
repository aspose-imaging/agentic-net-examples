using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Output path for the high‑resolution TIFF
        string outputPath = @"C:\Temp\vector_illustration.tif";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure TIFF options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;

        // Desired image size (high resolution)
        int width = 2000;
        int height = 2000;

        // Create the TIFF image bound to the output file
        using (Image image = Image.Create(tiffOptions, width, height))
        {
            Graphics graphics = new Graphics(image);

            // Fill background with solid white brush
            using (SolidBrush backgroundBrush = new SolidBrush(Color.White))
            {
                graphics.FillRectangle(backgroundBrush, image.Bounds);
            }

            // Create a vector illustration using GraphicsPath
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(400f, 400f, 800f, 800f)));

            // Add an ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(1200f, 400f, 800f, 800f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the vector path with a red pen
            Pen redPen = new Pen(Color.Red, 5);
            graphics.DrawPath(redPen, path);

            // Save the image (output file is already bound)
            image.Save();
        }
    }
}