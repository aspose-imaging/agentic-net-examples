using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        string inputPath = "input.apng";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Add frame index as a text overlay on each frame before saving
            apng.PageExportingAction = (pageIndex, pageImage) =>
            {
                Graphics graphics = new Graphics(pageImage);
                Font font = new Font("Arial", 12);
                SolidBrush brush = new SolidBrush(Color.Yellow);
                graphics.DrawString($"Frame {pageIndex}", font, brush, new Point(5, 5));
                // No disposal of Graphics, Font, or Brush as per rules
            };

            GifOptions gifOptions = new GifOptions();
            apng.Save(outputPath, gifOptions);
        }
    }
}