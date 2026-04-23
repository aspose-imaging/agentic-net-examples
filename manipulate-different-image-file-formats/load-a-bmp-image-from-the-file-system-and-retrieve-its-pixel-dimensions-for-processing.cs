using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.txt";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image using the BmpImage constructor that takes a file path
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Retrieve pixel dimensions
                int width = bmpImage.Width;
                int height = bmpImage.Height;

                // Output dimensions to console
                Console.WriteLine($"Width: {width} pixels");
                Console.WriteLine($"Height: {height} pixels");

                // Optionally write dimensions to a text file
                File.WriteAllText(outputPath, $"Width: {width} pixels{Environment.NewLine}Height: {height} pixels");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}