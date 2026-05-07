using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDirectory);

            // List of image sizes (width, height)
            var sizes = new (int width, int height)[]
            {
                (200, 200),
                (300, 150),
                (400, 400)
            };

            foreach (var size in sizes)
            {
                string fileName = $"image_{size.width}x{size.height}.bmp";
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // BMP creation options
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(bmpOptions, size.width, size.height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    using (SolidBrush brush = new SolidBrush(Color.Red))
                    {
                        graphics.FillEllipse(brush, new Rectangle(0, 0, size.width, size.height));
                    }

                    // Save the image (output path already bound)
                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}