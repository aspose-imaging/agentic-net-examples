using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG file and output EMF file paths
        string inputJpegPath = "input.jpg";
        string outputEmfPath = "output.emf";

        // Load the JPEG raster image
        using (RasterImage jpegImage = (RasterImage)Image.Load(inputJpegPath))
        {
            int width = jpegImage.Width;
            int height = jpegImage.Height;

            // Define the EMF canvas size matching the JPEG dimensions
            Rectangle frame = new Rectangle(0, 0, width, height);
            Size deviceSize = new Size(width, height);
            // Approximate device size in millimeters (1 pixel ≈ 0.01 mm for this example)
            Size deviceSizeMm = new Size((int)(width / 100f), (int)(height / 100f));

            // Create EMF recorder graphics (do NOT wrap in using)
            EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(frame, deviceSize, deviceSizeMm);

            // Draw the JPEG onto the EMF canvas, preserving full fidelity
            graphics.DrawImage(
                jpegImage,
                new Rectangle(0, 0, width, height),   // Destination rectangle
                new Rectangle(0, 0, width, height),   // Source rectangle
                GraphicsUnit.Pixel);                  // Unit

            // Finalize recording and obtain the EMF image
            using (EmfImage emfImage = graphics.EndRecording())
            {
                // Save the EMF image, preserving any metadata
                emfImage.Save(outputEmfPath);
            }
        }
    }
}