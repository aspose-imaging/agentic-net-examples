using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Open input stream and load PNG image
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (PngImage pngImage = new PngImage(inputStream))
        {
            // Create Graphics object for subsequent drawing operations
            Graphics graphics = new Graphics(pngImage);

            // Example preparation step: clear the canvas (optional)
            // graphics.Clear(Color.White);

            // Save the image (no drawing performed yet)
            pngImage.Save(outputPath);
        }
    }
}