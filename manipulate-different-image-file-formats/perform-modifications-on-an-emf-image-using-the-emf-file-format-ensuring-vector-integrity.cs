using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output EMF file paths
        string dir = @"c:\temp\";
        string inputPath = Path.Combine(dir, "test.emf");
        string outputPath = Path.Combine(dir, "test.modified.emf");

        // Load the existing EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Create a graphics recorder that contains all records from the loaded EMF
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

            // Draw a red rectangle
            graphics.DrawRectangle(new Pen(Color.Red, 2), 50, 50, 200, 100);

            // Fill a blue rectangle
            graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(300, 50, 150, 100));

            // Draw a text string
            graphics.DrawString("Modified", new Font("Arial", 36, FontStyle.Bold), Color.Green, 100, 200);

            // Finalize the recording and obtain the modified EMF image
            using (EmfImage modifiedEmf = graphics.EndRecording())
            {
                // Save the modified EMF image, preserving vector data
                modifiedEmf.Save(outputPath);
            }
        }
    }
}