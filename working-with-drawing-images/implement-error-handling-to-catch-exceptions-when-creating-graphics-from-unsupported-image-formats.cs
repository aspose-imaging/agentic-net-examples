using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            try
            {
                // Attempt to create a Graphics object
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Simple drawing operations
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                    new Aspose.Imaging.Rectangle(10, 10, 100, 100));
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.Error.WriteLine($"Failed to create Graphics: {ex.Message}");
                return;
            }

            // Save the modified image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}