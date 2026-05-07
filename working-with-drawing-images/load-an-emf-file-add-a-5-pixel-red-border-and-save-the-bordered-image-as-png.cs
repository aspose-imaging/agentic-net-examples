using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                int borderSize = 5;

                // Expand the canvas to accommodate the border
                emfImage.ResizeCanvas(new Aspose.Imaging.Rectangle(
                    -borderSize,
                    -borderSize,
                    emfImage.Width + 2 * borderSize,
                    emfImage.Height + 2 * borderSize));

                // Obtain a graphics object to draw on the EMF
                EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

                // Draw a red rectangle as the border
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, borderSize),
                    0,
                    0,
                    emfImage.Width,
                    emfImage.Height);

                // Finalize the recording and obtain the modified EMF image
                using (EmfImage borderedEmf = graphics.EndRecording())
                {
                    // Save the result as PNG
                    borderedEmf.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}