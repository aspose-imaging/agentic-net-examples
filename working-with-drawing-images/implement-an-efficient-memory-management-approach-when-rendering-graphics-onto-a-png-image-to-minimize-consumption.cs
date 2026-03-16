using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.png";
        int width = 2000;
        int height = 2000;

        // Create a file source for the PNG output
        Source source = new FileCreateSource(outputPath, false);

        // Configure PNG options with a memory limit (in MB)
        PngOptions pngOptions = new PngOptions
        {
            Source = source,
            BufferSizeHint = 30 // Limit internal buffers to 30 MB
        };

        // Create the PNG image with the specified dimensions
        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.BeginUpdate();
            graphics.Clear(Color.LightSkyBlue);

            // Draw a dense grid of lines to simulate heavy drawing workload
            int step = 20;
            for (int x = 0; x < width; x += step)
            {
                graphics.DrawLine(new Pen(Color.Red, 1), new Point(x, 0), new Point(x, height));
            }
            for (int y = 0; y < height; y += step)
            {
                graphics.DrawLine(new Pen(Color.Blue, 1), new Point(0, y), new Point(width, y));
            }

            graphics.EndUpdate();

            // Save the bound image (no path needed because the source is already bound)
            image.Save();
        }
    }
}