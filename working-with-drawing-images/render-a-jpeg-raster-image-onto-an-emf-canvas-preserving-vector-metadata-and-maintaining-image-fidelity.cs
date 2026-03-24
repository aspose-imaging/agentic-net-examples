using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG raster image
        using (JpegImage jpegImage = (JpegImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Define the EMF canvas size matching the JPEG dimensions
            Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, jpegImage.Width, jpegImage.Height);
            Aspose.Imaging.Size deviceSize = new Aspose.Imaging.Size(jpegImage.Width, jpegImage.Height);
            // Approximate device size in millimeters (1 pixel ≈ 0.01 mm)
            Aspose.Imaging.Size deviceSizeMm = new Aspose.Imaging.Size(jpegImage.Width / 100, jpegImage.Height / 100);

            // Create EMF recorder graphics (do NOT wrap in using)
            EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(frame, deviceSize, deviceSizeMm);

            // Draw the JPEG image onto the EMF canvas
            graphics.DrawImage(
                jpegImage,
                new Aspose.Imaging.Rectangle(0, 0, jpegImage.Width, jpegImage.Height),
                new Aspose.Imaging.Rectangle(0, 0, jpegImage.Width, jpegImage.Height),
                Aspose.Imaging.GraphicsUnit.Pixel);

            // Finalize recording and obtain the EMF image
            using (EmfImage emfImage = graphics.EndRecording())
            {
                // Save the EMF image to the output path
                emfImage.Save(outputPath);
            }
        }
    }
}