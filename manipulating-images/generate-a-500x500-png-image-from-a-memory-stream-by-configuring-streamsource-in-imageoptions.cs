using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a memory stream to be used as the source
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configure PNG options with the stream source
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(memoryStream);

                // Create a 500x500 PNG image using the options
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
                {
                    // Draw on the image
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.Wheat);
                    graphics.DrawRectangle(
                        new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                        new Aspose.Imaging.Rectangle(50, 50, 400, 400));

                    // Save the image to the specified file
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}