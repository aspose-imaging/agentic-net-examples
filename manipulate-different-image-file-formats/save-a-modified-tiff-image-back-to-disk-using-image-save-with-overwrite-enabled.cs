using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\temp\\input.tif";
            string outputPath = "C:\\temp\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Draw a red rectangle on the active frame
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Red, 5);
                graphics.DrawRectangle(pen, new RectangleF(10, 10, 100, 100));

                // Save the modified image, overwriting if the file exists
                image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}