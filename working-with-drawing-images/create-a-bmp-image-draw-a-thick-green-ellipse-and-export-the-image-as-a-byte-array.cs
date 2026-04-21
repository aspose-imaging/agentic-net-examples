using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output file path (used to demonstrate directory creation and optional file write)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a memory stream to hold the BMP image data
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Configure BMP options with a stream source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new StreamSource(memoryStream);

            // Create a BMP image canvas of 500x500 pixels
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Create a thick green pen
                Pen greenPen = new Pen(Color.Green, 5);

                // Draw a thick green ellipse
                graphics.DrawEllipse(greenPen, new Rectangle(50, 50, 400, 400));

                // Save the image data to the bound stream
                image.Save();
            }

            // Export the image as a byte array
            byte[] imageBytes = memoryStream.ToArray();

            // Optional: write the byte array to a file for verification
            File.WriteAllBytes(outputPath, imageBytes);

            Console.WriteLine($"Image byte array length: {imageBytes.Length}");
        }
    }
}