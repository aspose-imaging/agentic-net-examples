using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the existing image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a Graphics object for the image
            Graphics graphics = new Graphics(image);

            // Clear the canvas to white while preserving dimensions
            graphics.Clear(Color.White);

            // Save the cleared image
            image.Save(outputPath);
        }

        Console.WriteLine("Canvas has been reset and saved to: " + outputPath);
    }
}