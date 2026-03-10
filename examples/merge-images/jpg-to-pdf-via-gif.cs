using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG file path
        string jpgPath = @"C:\temp\input.jpg";
        // Output PDF file path
        string pdfPath = @"C:\temp\output.pdf";

        // Load the JPG image as a raster image
        using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
        {
            // Create a temporary GIF canvas with the same dimensions as the JPG
            Source gifSource = new FileCreateSource(Path.GetTempFileName(), false);
            GifOptions gifOptions = new GifOptions() { Source = gifSource };
            using (RasterImage gifCanvas = (RasterImage)Image.Create(gifOptions, jpgImage.Width, jpgImage.Height))
            {
                // Draw the JPG onto the GIF canvas
                Graphics graphics = new Graphics(gifCanvas);
                graphics.DrawImage(jpgImage, new Rectangle(0, 0, jpgImage.Width, jpgImage.Height));

                // Save the GIF canvas as a PDF
                PdfOptions pdfOptions = new PdfOptions();
                gifCanvas.Save(pdfPath, pdfOptions);
            }
        }
    }
}