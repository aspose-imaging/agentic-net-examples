using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output.jp2";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Image dimensions and bits per sample
            int width = 200;
            int height = 100;
            int bitsCount = 8; // bits per sample

            // Create a JPEG2000 image with specified bits per sample
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(width, height, bitsCount))
            {
                // Fill the image with a solid color (e.g., blue)
                Graphics graphics = new Graphics(jpeg2000Image);
                SolidBrush brush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);

                // Save the image
                jpeg2000Image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}