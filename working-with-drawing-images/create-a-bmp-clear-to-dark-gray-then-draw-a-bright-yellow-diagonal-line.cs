// HOW-TO: Create BMP Image with Dark Gray Background and Yellow Diagonal Line in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.FromArgb(255, 64, 64, 64));

                Pen pen = new Pen(Color.Yellow, 1);
                graphics.DrawLine(pen, 0, 0, image.Width - 1, image.Height - 1);

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
 * 1. When you need to generate a simple placeholder BMP file with a custom background color and a visual marker for testing image rendering pipelines.
 * 2. When creating diagnostic graphics for hardware devices that only support BMP format and require a high‑contrast line to verify display alignment.
 * 3. When programmatically producing icons or UI elements that need a solid gray canvas with a bright accent line for branding or visual cues.
 * 4. When automating batch creation of sample images for documentation or tutorials that demonstrate basic drawing operations in Aspose.Imaging.
 * 5. When building a quick visual indicator in a BMP file to mark coordinates or paths in a computer‑vision preprocessing step.
 */
