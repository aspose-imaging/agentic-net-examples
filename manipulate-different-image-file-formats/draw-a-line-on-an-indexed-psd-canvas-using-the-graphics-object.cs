using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Drawing; // For Pen, Color, Point

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.psd";
        string outputPath = @"C:\Images\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image (indexed canvas)
        using (Image img = Image.Load(inputPath))
        {
            // Cast to PSD image type for safety
            PsdImage psdImage = img as PsdImage;
            if (psdImage == null)
            {
                Console.Error.WriteLine("The loaded file is not a PSD image.");
                return;
            }

            // Create Graphics object for drawing
            using (Graphics graphics = new Graphics(psdImage))
            {
                // Define a red pen with width 5
                Pen pen = new Pen(Color.Red, 5);

                // Draw a line from (10,10) to (200,200)
                graphics.DrawLine(pen, new Point(10, 10), new Point(200, 200));
            }

            // Save the modified image
            psdImage.Save(outputPath);
        }
    }
}