// HOW-TO: Create BMP Image With Thick Red Border Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Red, 5);
                graphics.DrawRectangle(pen, 0, 0, width - 1, height - 1);

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a blank BMP canvas and add a visible red frame for UI placeholders or testing.
 * 2. When creating simple graphics for embedded devices that require BMP format with a defined border for alignment.
 * 3. When programmatically producing thumbnail images with a colored outline to highlight selection in a Windows application.
 * 4. When generating printable assets where a red border indicates cut lines or safety margins in a BMP file.
 * 5. When automating batch creation of bordered BMP files for documentation or training material without using external editors.
 */
