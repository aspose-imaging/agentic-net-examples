using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string jpegPath = "input.jpg";
            string pngPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }

            if (!File.Exists(pngPath))
            {
                Console.Error.WriteLine($"File not found: {pngPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage jpegImage = (RasterImage)Image.Load(jpegPath))
            using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
            {
                int newWidth = jpegImage.Width + pngImage.Width;
                int newHeight = Math.Max(jpegImage.Height, pngImage.Height);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
                {
                    // Copy JPEG onto canvas at (0,0)
                    Rectangle jpegBounds = new Rectangle(0, 0, jpegImage.Width, jpegImage.Height);
                    canvas.SaveArgb32Pixels(jpegBounds, jpegImage.LoadArgb32Pixels(jpegImage.Bounds));

                    // Copy PNG onto canvas next to JPEG
                    Rectangle pngBounds = new Rectangle(jpegImage.Width, 0, pngImage.Width, pngImage.Height);
                    canvas.SaveArgb32Pixels(pngBounds, pngImage.LoadArgb32Pixels(pngImage.Bounds));

                    // Save the merged image
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}