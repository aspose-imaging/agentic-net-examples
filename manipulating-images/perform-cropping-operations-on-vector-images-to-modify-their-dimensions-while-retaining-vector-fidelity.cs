using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf; // Example vector format
using Aspose.Imaging.FileFormats.Svg; // Example vector format

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_cropped.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Process only vector images
            if (image is VectorImage vectorImage)
            {
                // Define a central cropping rectangle (50% of original size)
                int left = vectorImage.Width / 4;
                int top = vectorImage.Height / 4;
                int width = vectorImage.Width / 2;
                int height = vectorImage.Height / 2;

                var cropArea = new Aspose.Imaging.Rectangle(left, top, width, height);

                // Perform cropping while preserving vector fidelity
                vectorImage.Crop(cropArea);

                // Save the cropped vector image
                vectorImage.Save(outputPath);
            }
            else
            {
                Console.Error.WriteLine("The loaded image is not a vector image.");
            }
        }
    }
}