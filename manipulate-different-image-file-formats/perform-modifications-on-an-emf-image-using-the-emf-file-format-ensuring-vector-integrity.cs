using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Create a graphics recorder that contains all existing records
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

            // Draw a blue rectangle around the image border
            graphics.DrawRectangle(new Pen(Color.Blue, 2), 0, 0, emfImage.Width, emfImage.Height);

            // Add a text watermark at the top-left corner
            graphics.DrawString(
                "Modified",
                new Font("Arial", 48, FontStyle.Regular),
                Color.Red,
                10,
                10);

            // Finalize the recording and obtain the modified EMF image
            using (EmfImage modifiedEmf = graphics.EndRecording())
            {
                // Save the modified EMF image to the output path
                modifiedEmf.Save(outputPath);
            }
        }
    }
}