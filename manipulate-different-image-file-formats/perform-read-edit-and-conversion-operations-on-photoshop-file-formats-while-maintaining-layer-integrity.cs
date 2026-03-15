using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input PSD, edited PSD, and output PNG
        string inputPsdPath = "input.psd";
        string editedPsdPath = "edited.psd";
        string outputPngPath = "output.png";

        // Load the original PSD file
        using (Image psdImage = Image.Load(inputPsdPath))
        {
            // Draw a red rectangle on the image to demonstrate editing
            Graphics graphics = new Graphics(psdImage);
            Pen redPen = new Pen(Color.Red, 5);
            Rectangle rect = new Rectangle(50, 50, 200, 200);
            graphics.DrawRectangle(redPen, rect);

            // Save the edited image back to PSD, preserving layers
            PsdOptions psdSaveOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE
            };
            psdImage.Save(editedPsdPath, psdSaveOptions);
        }

        // Load the edited PSD and convert it to PNG
        using (Image editedImage = Image.Load(editedPsdPath))
        {
            PngOptions pngOptions = new PngOptions();
            editedImage.Save(outputPngPath, pngOptions);
        }

        Console.WriteLine("Editing and conversion completed.");
    }
}