using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string outputDir = @"C:\Temp\BatchImages";
            Directory.CreateDirectory(outputDir);

            Color[] backgroundColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Cyan
            };

            string[] fileNames = new string[]
            {
                "red.bmp",
                "green.bmp",
                "blue.bmp",
                "yellow.bmp",
                "cyan.bmp"
            };

            int canvasWidth = 500;
            int canvasHeight = 500;
            int ellipseWidth = 300;
            int ellipseHeight = 300;

            for (int i = 0; i < backgroundColors.Length; i++)
            {
                string outputPath = Path.Combine(outputDir, fileNames[i]);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (RasterImage canvas = (RasterImage)Image.Create(options, canvasWidth, canvasHeight))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(backgroundColors[i]);

                    int offsetX = (canvas.Width - ellipseWidth) / 2;
                    int offsetY = (canvas.Height - ellipseHeight) / 2;
                    graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(offsetX, offsetY, ellipseWidth, ellipseHeight));

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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to create a batch of BMP files with different solid background colors and a centered black ellipse for UI mock‑ups or design previews, this C# Aspose.Imaging code automates the generation.
 * 2. When an automated testing suite requires sample bitmap images of known dimensions and shapes to validate image processing algorithms, the code can produce the required BMP assets on the fly.
 * 3. When a game developer wants to generate placeholder textures with distinct color themes and a common ellipse marker for level design prototyping, the script creates the BMP resources programmatically.
 * 4. When a documentation team must embed example images showing color variations and vector drawing capabilities of the Aspose.Imaging library, this code quickly produces the BMP illustrations.
 * 5. When a batch‑processing pipeline needs to export a series of bitmap files to a specific folder structure for downstream reporting or printing workflows, the code handles file creation, background coloring, and ellipse drawing in one loop.
 */