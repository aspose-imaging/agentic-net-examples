using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input JPG, temporary TGA, and output PDF
        string inputJpgPath = "input.jpg";
        string tempTgaPath = "temp.tga";
        string outputPdfPath = "output.pdf";

        // Load the JPG image and save it as TGA
        using (RasterImage jpgImage = (RasterImage)Image.Load(inputJpgPath))
        {
            jpgImage.Save(tempTgaPath, new TgaOptions());
        }

        // Load the TGA image
        using (RasterImage tgaImage = (RasterImage)Image.Load(tempTgaPath))
        {
            // Create a raster canvas (JPEG image) without binding to a file
            JpegOptions canvasOptions = new JpegOptions() { Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, tgaImage.Width, tgaImage.Height))
            {
                // Copy TGA pixels onto the canvas
                canvas.SaveArgb32Pixels(
                    new Rectangle(0, 0, tgaImage.Width, tgaImage.Height),
                    tgaImage.LoadArgb32Pixels(tgaImage.Bounds));

                // Save the canvas as a PDF document
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPdfPath, pdfOptions);
            }
        }

        // Clean up the temporary TGA file
        if (File.Exists(tempTgaPath))
        {
            File.Delete(tempTgaPath);
        }
    }
}