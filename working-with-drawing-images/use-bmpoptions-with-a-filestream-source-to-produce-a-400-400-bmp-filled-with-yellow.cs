using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a FileStream that will receive the BMP data
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure BMP options with the stream as the source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(stream);

            // Create a 400×400 BMP image bound to the stream
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 400))
            {
                // Obtain a Graphics object for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Fill the entire canvas with yellow
                graphics.Clear(Aspose.Imaging.Color.Yellow);

                // Save the bound image (writes to the stream)
                image.Save();
            }
        }
    }
}