using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Memory stream that will act as the source for the PNG image
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configure PNG options with a StreamSource pointing to the memory stream
                PngOptions pngOptions = new PngOptions
                {
                    Source = new StreamSource(memoryStream)
                };

                // Create a 500x500 PNG image using the configured options
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Optional: fill the image with a solid color
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.LightBlue);

                    // Save the image to the hardcoded output path
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}