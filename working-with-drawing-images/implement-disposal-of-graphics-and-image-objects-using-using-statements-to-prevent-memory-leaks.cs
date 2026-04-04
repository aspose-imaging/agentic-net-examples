using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

        // Load the image inside a using block to ensure disposal
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics instance (Graphics does NOT implement IDisposable)
            Graphics graphics = new Graphics(image);

            // Example drawing operations
            graphics.Clear(Color.White);
            graphics.DrawLine(new Pen(Color.Black, 2), new Point(0, 0), new Point(100, 100));
            graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(20, 20, 150, 100));

            // Save the modified image with PNG options
            PngOptions saveOptions = new PngOptions();
            image.Save(outputPath, saveOptions);
        }
    }
}