using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load PNG image from a file stream
        using (FileStream stream = new FileStream(inputPath, FileMode.Open))
        {
            using (PngImage pngImage = new PngImage(stream))
            {
                // Create a Graphics instance for drawing operations
                Graphics graphics = new Graphics(pngImage);

                // Example drawing operation: clear the canvas to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Save the modified image to the output path
                pngImage.Save(outputPath);
            }
        }
    }
}