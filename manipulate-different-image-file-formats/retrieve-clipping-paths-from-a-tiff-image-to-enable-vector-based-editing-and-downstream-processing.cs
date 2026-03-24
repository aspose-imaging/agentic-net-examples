using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Sample.tif";
        string outputPath = "SampleWithRedBorder.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (var image = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve and display clipping path names
            foreach (var path in image.ActiveFrame.PathResources)
            {
                Console.WriteLine(path.Name);
            }

            // Create a GraphicsPath from the clipping paths
            var graphicsPath = PathResourceConverter.ToGraphicsPath(
                image.ActiveFrame.PathResources.ToArray(),
                image.ActiveFrame.Size);

            // Draw the path onto the image
            var graphics = new Graphics(image);
            graphics.DrawPath(new Pen(Color.Red, 10), graphicsPath);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}