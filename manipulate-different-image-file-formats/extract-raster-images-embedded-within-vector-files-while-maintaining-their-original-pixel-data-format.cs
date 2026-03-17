using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Path to the vector file that may contain embedded raster images (e.g., .cdr, .svg, .pdf)
        string inputFile = "test.cdr";

        // Load the file using Aspose.Imaging's generic loader
        using (Image image = Image.Load(inputFile))
        {
            // Cast the loaded image to VectorImage to access vector‑specific members
            var vectorImage = image as VectorImage;
            if (vectorImage == null)
            {
                Console.WriteLine("The provided file is not a supported vector format.");
                return;
            }

            // Retrieve all embedded raster images
            EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

            int index = 0;
            foreach (EmbeddedImage embedded in embeddedImages)
            {
                // Build an output file name that preserves the original image format
                string extension = "." + embedded.Image.FileFormat.ToString().ToLower();
                string outputFile = $"image{index}{extension}";

                // Save the embedded raster image using its native format
                // (Save(string) keeps the original pixel data format)
                embedded.Image.Save(outputFile);

                // Dispose the EmbeddedImage instance as required by the lifecycle rule
                embedded.Dispose();

                Console.WriteLine($"Extracted embedded image saved to: {outputFile}");
                index++;
            }
        }
    }
}