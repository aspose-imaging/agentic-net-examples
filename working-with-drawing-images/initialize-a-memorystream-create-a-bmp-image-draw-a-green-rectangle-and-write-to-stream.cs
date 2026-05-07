using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Ensure the output directory exists (required by path-safety rules)
            string outputPath = "output\\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a memory stream to hold the BMP image
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configure BMP options to write to the memory stream
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(memoryStream);

                // Create a 200x200 BMP image
                using (Image image = Image.Create(bmpOptions, 200, 200))
                {
                    // Obtain a Graphics object for drawing
                    Graphics graphics = new Graphics(image);

                    // Draw a green rectangle
                    graphics.DrawRectangle(new Pen(Color.Green, 5), new Rectangle(20, 20, 160, 160));

                    // Save changes (the image is bound to the stream)
                    image.Save();
                }

                // At this point, memoryStream contains the BMP data.
                // Example: write the stream to a file (optional)
                // File.WriteAllBytes(outputPath, memoryStream.ToArray());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}