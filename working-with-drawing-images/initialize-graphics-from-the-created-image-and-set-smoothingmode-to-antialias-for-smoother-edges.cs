using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set up PNG options with the stream as source
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a new image (500x500)
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
                {
                    // Initialize Graphics from the created image
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                    // Set smoothing mode for anti-aliasing
                    graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                    // Optional: clear background
                    graphics.Clear(Aspose.Imaging.Color.Wheat);

                    // Save the image (stream is already bound)
                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}