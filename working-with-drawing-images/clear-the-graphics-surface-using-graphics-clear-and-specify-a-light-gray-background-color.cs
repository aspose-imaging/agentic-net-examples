// HOW-TO: Create PNG Image With Light Gray Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.png";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            var options = new PngOptions();
            using (Image image = Image.Create(options, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);
                image.Save(outputPath, options);
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
 * 1. When you need to generate a blank PNG placeholder with a light gray canvas for web thumbnails or UI mockups.
 * 2. When creating report PDFs that embed a solid‑color background image generated on the fly with Aspose.Imaging in C#.
 * 3. When programmatically preparing a background layer for overlaying graphics or text in automated image composition.
 * 4. When initializing a drawing surface for a game sprite sheet where a uniform light gray background simplifies later processing.
 * 5. When building a batch process that creates template images for email newsletters, ensuring each PNG starts with a consistent light gray background.
 */
