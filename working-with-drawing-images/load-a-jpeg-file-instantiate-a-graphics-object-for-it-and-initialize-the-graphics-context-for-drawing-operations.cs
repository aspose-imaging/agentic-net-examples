using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.jpg";
        string outputPath = @"C:\temp\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image using the JpegImage constructor
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Create a Graphics instance for the loaded image
            Graphics graphics = new Graphics(jpegImage);

            // Initialize the graphics context (e.g., clear the surface with white)
            graphics.Clear(Color.White);

            // Save the image after initializing the graphics context
            jpegImage.Save(outputPath);
        }
    }
}