using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path and image dimensions
        string outputPath = "output.j2k";
        int width = 800;
        int height = 600;

        // Configure JPEG2000 options with a memory limit (BufferSizeHint in MB)
        Jpeg2000Options jp2Options = new Jpeg2000Options
        {
            BufferSizeHint = 20, // Limit internal buffers to 20 MB
            Source = new FileCreateSource(outputPath, false),
            Irreversible = true,
            Codec = Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Codec.J2K
        };

        // Create the JPEG2000 canvas using the options
        using (Image canvas = Image.Create(jp2Options, width, height))
        {
            // Draw a solid rectangle covering the entire canvas
            Graphics graphics = new Graphics(canvas);
            SolidBrush brush = new SolidBrush(Color.Blue);
            graphics.FillRectangle(brush, canvas.Bounds);

            // Save the image; since the source is bound to a file, call Save()
            canvas.Save();
        }
    }
}