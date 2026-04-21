using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document
        using (Image image = Image.Load(inputPath))
        {
            // Define the rectangle area to export (x, y, width, height)
            Rectangle exportRect = new Rectangle(50, 50, 300, 300);

            // PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the specified portion as PNG
            using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
            {
                image.Save(outStream, pngOptions, exportRect);
            }
        }
    }
}