using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"c:\temp\concentric_circles.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int centerX = 250;
                int centerY = 250;
                int maxRadius = 200;
                int step = 20;
                bool useRed = true;

                // Draw concentric circles with alternating colors
                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    Aspose.Imaging.Color penColor = useRed ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;
                    Pen pen = new Pen(penColor, 2);
                    graphics.DrawEllipse(pen, new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2));
                    useRed = !useRed;
                }

                // Save the image (output path already bound)
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
 * 1. When a developer needs to generate a BMP file with a visual pattern of concentric circles for a printable test page or calibration sheet, they can use this Aspose.Imaging C# code to draw alternating red and blue rings.
 * 2. When creating custom UI assets such as loading spinners or background textures that require precise control over circle radii and color alternation, this code demonstrates how to programmatically render them into a 24‑bit BMP image.
 * 3. When building automated documentation or reports that embed simple geometric diagrams, the example shows how to produce a BMP illustration of concentric circles using Aspose.Imaging’s Graphics and Pen objects.
 * 4. When a software product must export diagnostic graphics—like radar‑style range rings—for engineering analysis, the snippet provides a straightforward way to generate the BMP image with adjustable radius steps and colors.
 * 5. When a game developer wants to pre‑render sprite sheets containing circular patterns for particle effects, this code illustrates how to create and save a BMP canvas with alternating colored circles using C# and Aspose.Imaging.
 */