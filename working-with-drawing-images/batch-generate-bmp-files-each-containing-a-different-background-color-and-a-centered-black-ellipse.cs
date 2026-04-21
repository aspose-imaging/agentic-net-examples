using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output directory
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Image dimensions
        int width = 400;
        int height = 300;

        // Background colors and corresponding file names
        Aspose.Imaging.Color[] colors = { Aspose.Imaging.Color.Red, Aspose.Imaging.Color.Green, Aspose.Imaging.Color.Blue };
        string[] fileNames = { "red.bmp", "green.bmp", "blue.bmp" };

        for (int i = 0; i < colors.Length; i++)
        {
            string outputPath = Path.Combine(outputDir, fileNames[i]);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image (output file is already bound)
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with the background color
                graphics.Clear(colors[i]);

                // Define a centered ellipse rectangle
                int ellipseWidth = width / 2;
                int ellipseHeight = height / 2;
                int ellipseX = (width - ellipseWidth) / 2;
                int ellipseY = (height - ellipseHeight) / 2;
                Rectangle ellipseRect = new Rectangle(ellipseX, ellipseY, ellipseWidth, ellipseHeight);

                // Draw the black ellipse
                Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawEllipse(pen, ellipseRect);

                // Save the image (file is already bound to the source)
                image.Save();
            }
        }
    }
}