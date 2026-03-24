using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Obtain a graphics object that contains all records from the loaded EMF
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

            // Example manipulation: draw a watermark text on the image
            float fontSize = 48f;
            graphics.DrawString(
                "WATERMARK",
                new Font("Arial", fontSize),
                Color.LightPink,
                0,
                0);

            // Finalize recording to get a new EMF image with the modifications
            using (EmfImage modifiedEmf = graphics.EndRecording())
            {
                // Save the modified EMF image
                modifiedEmf.Save(outputPath);
            }
        }
    }
}