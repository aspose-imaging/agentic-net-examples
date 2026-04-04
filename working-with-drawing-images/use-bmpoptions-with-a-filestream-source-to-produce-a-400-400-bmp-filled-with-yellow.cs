using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a FileStream for the output BMP
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure BMP options with the stream as the source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(stream);

            // Create a 400×400 BMP image bound to the stream
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Fill the entire canvas with yellow
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Yellow);

                // Save the bound image
                image.Save();
            }
        }
    }
}