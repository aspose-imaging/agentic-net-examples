using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.jp2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create JPEG2000 options
            Jpeg2000Options createOptions = new Jpeg2000Options
            {
                Irreversible = true
            };

            // Create a new JPEG2000 image (200x200) with the options
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200, createOptions))
            {
                // Fill the image with red color
                Graphics graphics = new Graphics(jpeg2000Image);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);

                // Save the image
                jpeg2000Image.Save(outputPath);
            }

            // Load the saved image to verify it was created
            using (Image loadedImage = Image.Load(outputPath))
            {
                Console.WriteLine("Image saved and loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}