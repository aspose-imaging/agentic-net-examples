using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string jpgPath = "input.jpg";
        string pngPath = "input.png";
        string outputPath = "output.emz";

        // Load the PNG image which will serve as the canvas
        using (RasterImage canvas = (RasterImage)Image.Load(pngPath))
        {
            // Load the JPG image to be merged onto the canvas
            using (RasterImage jpg = (RasterImage)Image.Load(jpgPath))
            {
                // Define the area where the JPG will be placed (top-left corner)
                Rectangle bounds = new Rectangle(0, 0, jpg.Width, jpg.Height);
                // Copy JPG pixels onto the canvas
                canvas.SaveArgb32Pixels(bounds, jpg.LoadArgb32Pixels(jpg.Bounds));
            }

            // Prepare EMZ (compressed EMF) save options
            EmfOptions emfOptions = new EmfOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Compress = true
            };

            // Save the merged image as EMZ
            canvas.Save(outputPath, emfOptions);
        }
    }
}