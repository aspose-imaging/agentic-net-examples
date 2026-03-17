using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input EPS file path
        string epsPath = "input.eps";

        // Output file paths
        string pngOutput = "output.png";
        string pdfOutput = "output.pdf";

        // Load the EPS image and cast to the specific EpsImage type
        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsPath))
        {
            // Resize the EPS image to 800x600 using Lanczos resampling for high quality
            epsImage.Resize(800, 600, ResizeType.LanczosResample);

            // Rotate the image 90 degrees and flip it horizontally
            epsImage.RotateFlip(RotateFlipType.Rotate90FlipX);

            // Save the transformed image as PNG
            var pngOptions = new PngOptions();
            epsImage.Save(pngOutput, pngOptions);

            // Save the transformed image as PDF
            var pdfOptions = new PdfOptions();
            epsImage.Save(pdfOutput, pdfOptions);
        }
    }
}