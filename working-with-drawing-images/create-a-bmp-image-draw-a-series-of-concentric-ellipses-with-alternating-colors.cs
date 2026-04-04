using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Define output path
        string outputPath = @"c:\temp\concentric_ellipses.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Canvas size
        int width = 500;
        int height = 500;

        // Create image bound to the output file
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Parameters for concentric ellipses
            int ellipseCount = 10;
            int marginStep = 20;
            Aspose.Imaging.Color[] colors = new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Blue
            };

            // Draw ellipses from outermost to innermost
            for (int i = 0; i < ellipseCount; i++)
            {
                int margin = i * marginStep;
                int ellipseWidth = width - 2 * margin;
                int ellipseHeight = height - 2 * margin;
                int x = margin;
                int y = margin;

                // Alternate colors
                Aspose.Imaging.Color penColor = colors[i % colors.Length];
                Pen pen = new Pen(penColor, 2);

                graphics.DrawEllipse(pen, x, y, ellipseWidth, ellipseHeight);
            }

            // Save the image (already bound to the file)
            image.Save();
        }
    }
}