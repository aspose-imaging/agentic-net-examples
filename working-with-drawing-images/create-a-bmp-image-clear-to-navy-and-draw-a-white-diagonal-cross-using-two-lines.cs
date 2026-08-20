// HOW-TO: Create BMP Image With Navy Background And White Diagonal Cross In C# (Aspose.Imaging for .NET)
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
            string outputPath = @"output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            int width = 500;
            int height = 500;
            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Navy);
                Pen whitePen = new Pen(Color.White, 1);
                graphics.DrawLine(whitePen, 0, 0, canvas.Width, canvas.Height);
                graphics.DrawLine(whitePen, 0, canvas.Height, canvas.Width, 0);
                canvas.Save();
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
 * 1. When you need to generate a simple BMP placeholder with a navy background and a white X for UI testing.
 * 2. When creating custom icons or markers for mapping applications that require a solid color background and a cross overlay in BMP format.
 * 3. When producing a watermark or logo element in BMP format for legacy systems that only support 24‑bit BMP files.
 * 4. When generating diagnostic graphics that highlight diagonal symmetry, such as a test pattern for display calibration.
 * 5. When automating batch creation of banner images for a game’s loading screen where a navy background with a white cross indicates a team symbol.
 */
